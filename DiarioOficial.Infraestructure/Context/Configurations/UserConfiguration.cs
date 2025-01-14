﻿using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiarioOficial.Infraestructure.Context.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.Roles)
                .HasDefaultValue(UserEnum.User);
        }
    }
}
