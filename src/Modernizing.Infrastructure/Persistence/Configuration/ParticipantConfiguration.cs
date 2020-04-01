using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modernizing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modernizing.Infrastructure.Persistence.Configuration
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Phone)
                .HasMaxLength(15)
                .IsRequired();
            builder.HasOne(p => p.Meetup)
                .WithMany(m => m.Participants);
        }
    }
}
