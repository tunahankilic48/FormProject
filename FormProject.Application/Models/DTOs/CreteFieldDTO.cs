using FormProject.Domain.Enum;

namespace FormProject.Application.Models.DTOs
{
    public class CreteFieldDTO
    {
        //ToDo: Data Annotations

        public bool Required { get; set; }
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public int FormId { get; set; }

    }
}
