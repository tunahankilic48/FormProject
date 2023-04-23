using FormProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormProject.Infrastructure.EntityTypeConfig
{
    internal class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.Required)
                .HasColumnType("bit")
                .IsRequired(true)
                .HasColumnOrder(2);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnOrder(3);

            builder.Property(x => x.DataType)
                .IsRequired(true)
                .HasColumnOrder(4);
            
            builder.Property(x => x.FormId)
                .IsRequired(true)
                .HasColumnOrder(5);


            //Foreign Key
            builder.HasOne(x => x.Form)
                .WithMany(x => x.Fields)
                .HasForeignKey(x => x.FormId);
        }
    }
}
