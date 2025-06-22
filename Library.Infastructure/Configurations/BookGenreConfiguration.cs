using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Configurations
{
    public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasOne(bg => bg.Genre).WithMany().HasForeignKey(bg => bg.GenreId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bg => bg.Book).WithMany().HasForeignKey(bg => bg.BookId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
