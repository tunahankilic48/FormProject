using FormProject.Domain.Enum;

namespace FormProject.Domain.Entities
{
    public class Field
    {
        public int? Id { get; set; }
        public bool? Required { get; set; } // Form için oluşturulan alanın doldurulmasının zorunlu olup olmadığı kontrol edilecek
        public string? Name { get; set; } // Doldurulacak alanın adı
        public DataType? DataType { get; set; } // Input alanının tipi seçiliyor
        public int? FormId { get; set; } // Hangi Forma Ait olduğunu gösterir

        //Navigation Property
        public Form? Form { get; set; }
    }
}
