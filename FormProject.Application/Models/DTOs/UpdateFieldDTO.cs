using FormProject.Domain.Enum;

namespace FormProject.Application.Models.DTOs
{
    public class UpdateFieldDTO
    {
        //ToDo: Data Annotations

        public int Id { get; set; }
        public bool Required { get; set; }
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public int FormId { get; set; }

    }
}
