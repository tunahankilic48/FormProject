using FormProject.Application.Models.DTOs;

namespace FormProject.Application.Services
{
    internal interface IFieldService
    {
        Task<bool> Create(CreteFieldDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateFieldDTO model);
        Task<UpdateFieldDTO> GetById(int id);

    }
}
