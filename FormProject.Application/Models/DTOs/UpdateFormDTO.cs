namespace FormProject.Application.Models.DTOs
{
    public class UpdateFormDTO
    {
        // ToDo: Data Annotaions

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
