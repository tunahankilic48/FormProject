using FormProject.Application.Models.DTOs;

namespace FormProject.Application.Services
{
    public interface IFieldService
    {
        Task<bool> Create(CreteFieldDTO model);
        Task<CreteFieldDTO> CreateField();


    }
}
