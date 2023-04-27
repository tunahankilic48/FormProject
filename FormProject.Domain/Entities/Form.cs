namespace FormProject.Domain.Entities
{
    public class Form
    {
        public int? Id { get; set; }
        public string? Name { get; set; } // Form Adı
        public string? Description { get; set; } // Formun açıklaması(Form hakkında bilgi verilebilir)
        public DateTime? CreatedAt { get; set; } // Formun ne zaman oluşturulduğunu gösterir
        public int? CreatedBy { get; set; } // Formun kim tarafından oluşturulduğu kaydedilir

        //Navigation Property
        public AppUser? User { get; set; }
        public List<Field>? Fields { get; set; }
    }
}
