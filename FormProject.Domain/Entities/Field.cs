using FormProject.Domain.Enum;

namespace FormProject.Domain.Entities
{
    public class Field
    {
        public int? Id { get; set; }
        public bool? Required { get; set; }
        public string? Name { get; set; }
        public DataType? DataType { get; set; }
        public int? FormId { get; set; }

        //Navigation Property
        public Form? Form { get; set; }
    }
}
