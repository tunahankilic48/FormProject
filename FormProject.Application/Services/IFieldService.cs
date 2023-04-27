using FormProject.Application.Models.DTOs;

namespace FormProject.Application.Services
{
    public interface IFieldService
    {
        Task<bool> Create(CreteFieldDTO model);
        Task<CreteFieldDTO> CreateField();
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateFieldDTO model);
        Task<UpdateFieldDTO> GetById(int id);

    }
}
