using Microsoft.EntityFrameworkCore;
using Modernizing.Core.Entities;
using Modernizing.Infrastructure.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Modernizing.Infrastructure.Persistence
{
    public class ModernizingDbContext : DbContext
    {
        public ModernizingDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MeetupConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
        }

        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
