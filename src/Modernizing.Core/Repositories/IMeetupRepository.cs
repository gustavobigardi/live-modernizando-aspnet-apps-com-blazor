using Modernizing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Core.Repositories
{
    public interface IMeetupRepository
    {
        Task<IList<Meetup>> GetAllAsync();
        Task<Meetup> GetByIdAsync(int id);
        Task<Meetup> AddAsync(Meetup meetup);
        Task<Meetup> UpdateAsync(Meetup meetup);
        Task DeleteAsync(int id);
    }
}
