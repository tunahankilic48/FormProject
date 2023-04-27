using FormProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Infrastructure.EntityTypeConfig
{
    internal class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnOrder(2);

            builder.Property(x => x.Description)
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired(false)
                .IsUnicode(true)
                .HasColumnOrder(3);

            builder.Property(x => x.CreatedBy)
                .IsRequired(false)
                .HasColumnOrder(4);

            builder.Property(x => x.CreatedAt)
                .IsRequired(true)
                .HasColumnType("smalldatetime")
                .HasColumnOrder(5);


            ////Foreign Key
            builder.HasOne(x => x.User)
                .WithMany(x => x.Forms)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
