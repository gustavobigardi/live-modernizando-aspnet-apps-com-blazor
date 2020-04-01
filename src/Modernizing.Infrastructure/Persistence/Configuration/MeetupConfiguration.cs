using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modernizing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modernizing.Infrastructure.Persistence.Configuration
{
    public class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasMany(m => m.Participants);
        }
    }
}
