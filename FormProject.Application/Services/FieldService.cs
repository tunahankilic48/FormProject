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
        /// <summary>
        /// Form için gerekli alanın oluşturulması sağlanır
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Create(CreteFieldDTO model)
        {
            Field newForm = _mapper.Map<Field>(model);
            return await _fieldRepository.Add(newForm);
        }

        /// <summary>
        /// Form için alan oluşturulurken gerekli verinin view'a taşınması sağlanır
        /// </summary>
        /// <returns></returns>

        public async Task<CreteFieldDTO> CreateField()
        {
            CreteFieldDTO creteFieldDTO = new CreteFieldDTO();
            foreach (DataType e in Enum.GetValues(typeof(DataType)))
            {
                creteFieldDTO.DataTypes.Add(e);
            }
            return creteFieldDTO;
        }

    }
}
