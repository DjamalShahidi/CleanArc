using Demo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Demo.Persistence.Configurations.Entities
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book
                {
                    Id=1,
                    Count = 10,
                    Title="Love",
                    CreateDate = DateTime.Now,
                },
                new Book
                {
                    Id = 2,
                    Count = 20,
                    Title = "Hate",
                    CreateDate = DateTime.Now,
                }
            );
        }
    }
}
