using Modernizing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Core.Repositories
{
    public interface IParticipantRepository
    {
        Task<IList<Participant>> GetAllAsync();
        Task<Participant> GetByIdAsync(int id);
        Task<Participant> AddAsync(Participant participant);
        Task<Participant> UpdateAsync(Participant participant);
        Task DeleteAsync(int id);
    }
}
