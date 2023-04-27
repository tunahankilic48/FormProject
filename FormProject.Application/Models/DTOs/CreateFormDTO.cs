using FormProject.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FormProject.Application.Models.DTOs
{
    public class CreateFormDTO
    {
        public CreateFormDTO()
        {
            Fields = new List<Field>();
        }

        [Display(Name = "Form Name")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CreatedAt = DateTime.Now;
        public int CreatedBy { get; set; }
        [Display(Name = "Fields")]
        public List<Field> Fields { get; set; }
    }
}
