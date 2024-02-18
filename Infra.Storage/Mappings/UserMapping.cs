using Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infra.Storage.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.IdUser);
            builder.Property(u => u.IdUser).HasColumnName("IdUser").IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.Property(u => u.Password).HasColumnName("Password").HasMaxLength(100).IsRequired();
            builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").IsRequired();
            builder.Property(u => u.DateRegister).HasColumnName("DateRegister").IsRequired();
            builder.Property(u => u.Role).HasColumnName("Role").IsRequired();

            //builder.HasMany(e => e.UserStores).WithOne().HasForeignKey(x => x.IdUser).HasPrincipalKey(u => u.IdUser);

        }
    }
}
