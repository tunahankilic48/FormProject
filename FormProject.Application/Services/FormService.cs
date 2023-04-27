using AutoMapper;
using FormProject.Application.Models.DTOs;
using FormProject.Application.Models.ViewModels;
using FormProject.Domain.Entities;
using FormProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FormProject.Application.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;

        public FormService(IFormRepository formRepository, IMapper mapper, IFieldRepository fieldRepository)
        {
            _formRepository = formRepository;
            _mapper = mapper;
            _fieldRepository = fieldRepository;
        }

        public async Task<bool> Create(CreateFormDTO model)
        {
            Form newForm = _mapper.Map<Form>(model);
            bool result = await _formRepository.Add(newForm);
            return result;
        }

        public async Task<CreateFormDTO> AssignFieldToForm(CreateFormDTO model, CreteFieldDTO field)
        {
            Field newField = _mapper.Map<Field>(field);
            model.Fields.Add(newField);
            return model;
        }

        public async Task<List<FormVM>> GetForms()
        {
            var forms = await _formRepository.GetFilteredList(
                select: x => new FormVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedBy = x.User.UserName

                },
                where: null,
                orderby: x => x.OrderBy(x => x.Name)
                );

            return forms;

        }

        public async Task<FormDetailsVM> GetFormDetails(int id)
        {
            var form = await _formRepository.GetFilteredFirstOrDefault(
                select: x => new FormDetailsVM
                {
                    Name = x.Name,
                    Description = x.Description,
                    Fields = x.Fields
                },
                where: x=> x.Id == id,
                include: x=>x.Include(x=>x.Fields)
                );

            return form;
        }

        public async Task<List<FormVM>> GetForms(string name)
        {
            var forms = await _formRepository.GetFilteredList(
                select: x => new FormVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedBy = x.User.UserName

                },
                where: x=>x.Name.Contains(name),
                orderby: x => x.OrderBy(x => x.Name)
                );

            return forms;
        }
    }
}
