namespace FormProject.Domain.Entities
{
    internal class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public List<Field> Fields { get; set; }

        //Navigation Property
        public AppUser User { get; set; }
    }
}
