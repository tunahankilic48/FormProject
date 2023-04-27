using System.ComponentModel.DataAnnotations;

namespace FormProject.Application.Models.ViewModels
{
    public class FormVM
    {
        [Display(Name = "Id")]
        public int? Id { get; set; }
        [Display(Name = "Form Name")]
        public string? Name { get; set; }
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }
    }
}
