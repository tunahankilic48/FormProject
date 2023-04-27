using AutoMapper;
using FormProject.Application.Models.DTOs;
using FormProject.Domain.Entities;
using FormProject.Domain.Enum;
using FormProject.Domain.Repositories;

namespace FormProject.Application.Services
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;

        public FieldService(IFieldRepository fieldRepository, IMapper mapper)
        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreteFieldDTO model)
        {
            Field newForm = _mapper.Map<Field>(model);
            return await _fieldRepository.Add(newForm);
        }



        public async Task<CreteFieldDTO> CreateField()
        {
            CreteFieldDTO creteFieldDTO = new CreteFieldDTO();
            foreach (DataType e in Enum.GetValues(typeof(DataType)))
            {
                creteFieldDTO.DataTypes.Add(e);
            }
            return creteFieldDTO;
        }

        public async Task<bool> Delete(int id)
        {
            Field deleteForm = await _fieldRepository.GetDefault(x => x.Id == id);
            return await _fieldRepository.Delete(deleteForm);
        }

        public async Task<UpdateFieldDTO> GetById(int id)
        {
            Field form = await _fieldRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateFieldDTO>(form);
        }

        public async Task<bool> Update(UpdateFieldDTO model)
        {
            Field form = _mapper.Map<Field>(model);
            return await _fieldRepository.Update(form);
        }
    }
}
