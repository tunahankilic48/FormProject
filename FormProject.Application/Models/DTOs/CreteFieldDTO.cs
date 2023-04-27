using System.ComponentModel.DataAnnotations;

namespace FormProject.Application.Models.DTOs
{
    public class CreteFieldDTO
    {
        public CreteFieldDTO()
        {
            DataTypes = new List<FormProject.Domain.Enum.DataType>();
        }

        public bool Required { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public FormProject.Domain.Enum.DataType DataType { get; set; }
        public int FormId { get; set; }

        public List<FormProject.Domain.Enum.DataType> DataTypes { get; set; }
    }
}
