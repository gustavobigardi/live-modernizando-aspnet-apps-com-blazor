using Microsoft.EntityFrameworkCore;
using Modernizing.Core.Entities;
using Modernizing.Core.Repositories;
using Modernizing.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Infrastructure.Repositories
{
    public class RaffleRepository : IRaffleRepository
    {
        private readonly ModernizingDbContext _dbContext;

        public RaffleRepository(ModernizingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Participant> RaffleAsync(int meetupId)
        {
            using(var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                var participant = await _dbContext.Participants
                    .Include(p => p.Meetup)
                    .Where(p => p.Meetup.Id.Equals(meetupId) && !p.Won)
                    .OrderBy(p => Guid.NewGuid())
                    .FirstOrDefaultAsync();
                
                if (participant != null)
                {
                    participant.Win();
                    _dbContext.Update(participant);
                    await _dbContext.SaveChangesAsync();
                }

                await transaction.CommitAsync();
                return participant;
            }
        }
    }
}
