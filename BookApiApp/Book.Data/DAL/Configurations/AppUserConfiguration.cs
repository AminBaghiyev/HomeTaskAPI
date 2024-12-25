using Book.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.DAL.Configurations
{
    
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
           
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(50);
           
        }
    }
}
