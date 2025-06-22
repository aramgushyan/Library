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
    public class BookLendingConfiguration : IEntityTypeConfiguration<BookLending>
    {
        public void Configure(EntityTypeBuilder<BookLending> builder)
        {
            builder.HasOne(bl => bl.Reader).WithMany().HasForeignKey(bl => bl.ReaderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bl => bl.Instance).WithMany().HasForeignKey(bl => bl.InstanceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}