using AutoMapper;
using FormProject.Application.Models.DTOs;
using FormProject.Application.Models.ViewModels;
using FormProject.Domain.Entities;
using FormProject.Domain.Repositories;

namespace FormProject.Application.Services
{
    internal class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public FormService(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateFormDTO model)
        {
            Form newForm = _mapper.Map<Form>(model);
            return await _formRepository.Add(newForm);
        }

        public async Task<bool> Delete(int id)
        {
            Form deleteForm = await _formRepository.GetDefault(x => x.Id == id);
            return await _formRepository.Delete(deleteForm);
        }

        public async Task<UpdateFormDTO> GetById(int id)
        {
            Form form = await _formRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateFormDTO>(form);
        }

        public async Task<List<FormVM>> GetForms()
        {
            var forms = await _formRepository.GetFilteredList(
                select: x => new FormVM
                {
                    Id = x.Id,
                    Name = x.Name
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
                    Id = x.Id,
                    Name = x.Name,
                },
                where: null,
                include: null
                );

            return form;
        }

        public async Task<bool> Update(UpdateFormDTO model)
        {
            Form form = _mapper.Map<Form>(model);
            return await _formRepository.Update(form);
        }
    }
}
