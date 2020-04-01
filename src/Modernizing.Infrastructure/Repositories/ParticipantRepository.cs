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
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ModernizingDbContext _dbContext;

        public ParticipantRepository(ModernizingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Participant> AddAsync(Participant participant)
        {
            _dbContext.Participants.Add(participant);
            await _dbContext.SaveChangesAsync();
            return participant;
        }

        public async Task DeleteAsync(int id)
        {
            _dbContext.Participants.Remove(_dbContext.Participants.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Participant>> GetAllAsync()
        {
            return await _dbContext.Participants.ToListAsync();
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            return await _dbContext.Participants.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Participant> UpdateAsync(Participant participant)
        {
            if (!_dbContext.Participants.Any(p => p.Id.Equals(participant.Id)))
                return null;

            _dbContext.Update(participant);
            await _dbContext.SaveChangesAsync();
            return participant;
        }
    }
}
