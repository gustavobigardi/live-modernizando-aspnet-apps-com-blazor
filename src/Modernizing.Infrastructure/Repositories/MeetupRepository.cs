using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Modernizing.Core.Entities;
using Modernizing.Core.Repositories;
using Modernizing.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Infrastructure.Repositories
{
    public class MeetupRepository : IMeetupRepository
    {
        private readonly ModernizingDbContext _dbContext;

        public MeetupRepository(ModernizingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Meetup> AddAsync(Meetup meetup)
        {
            _dbContext.Meetups.Add(meetup);
            await _dbContext.SaveChangesAsync();
            return meetup;
        }

        public async Task DeleteAsync(int id)
        {
            _dbContext.Meetups.Remove(_dbContext.Meetups.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Meetup>> GetAllAsync()
        {
            return await _dbContext.Meetups.ToListAsync();
        }

        public async Task<Meetup> GetByIdAsync(int id)
        {
            return await _dbContext.Meetups.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Meetup> UpdateAsync(Meetup meetup)
        {
            if (!_dbContext.Meetups.Any(m => m.Id.Equals(meetup.Id)))
                return null;

            _dbContext.Update(meetup);
            await _dbContext.SaveChangesAsync();
            return meetup;
        }
    }
}
