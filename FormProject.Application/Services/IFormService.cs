using FormProject.Application.Models.DTOs;
using FormProject.Application.Models.ViewModels;
using FormProject.Domain.Entities;

namespace FormProject.Application.Services
{
    public interface IFormService
    {
        Task<bool> Create(CreateFormDTO model);
        Task<CreateFormDTO> AssignFieldToForm(CreateFormDTO model, CreteFieldDTO field);
        Task<List<FormVM>> GetForms(string name);
        Task<List<FormVM>> GetForms();
        Task<FormDetailsVM> GetFormDetails(int id);
    }
}
