using BlackYellow.Authentication.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BlackYellow.Authetication.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                 .HasColumnName("Id");

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cpf)
               .HasColumnType("varchar(13)")
               .HasMaxLength(100)
               .IsRequired();


            builder.Property(c => c.Phone)
             .HasColumnType("varchar(13)")
             .HasMaxLength(100)
             .IsRequired();

            builder.HasOne(c => c.User);

            builder.HasOne(c => c.Address);

        }
    }
}
