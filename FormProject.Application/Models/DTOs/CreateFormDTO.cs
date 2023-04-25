namespace FormProject.Application.Models.DTOs
{
    public class CreateFormDTO
    {
        //ToDo: Data Annotations

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
