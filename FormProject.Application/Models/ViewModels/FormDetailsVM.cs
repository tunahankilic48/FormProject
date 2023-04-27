using FormProject.Domain.Entities;

namespace FormProject.Application.Models.ViewModels
{
    public class FormDetailsVM
    { 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Field> Fields{ get; set; }
    }
}
