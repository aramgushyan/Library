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
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasOne(ab => ab.Author).WithMany().HasForeignKey(ab => ab.AuthorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ab => ab.Book).WithMany().HasForeignKey(ab => ab.BookId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
