using FormProject.Application.Models.DTOs;
using FormProject.Application.Models.ViewModels;

namespace FormProject.Application.Services
{
    internal interface IFormService
    {
        Task<bool> Create(CreateFormDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateFormDTO model);
        Task<UpdateFormDTO> GetById(int id);
        Task<List<FormVM>> GetForms();
        Task<FormDetailsVM> GetFormDetails(int id);
    }
}
