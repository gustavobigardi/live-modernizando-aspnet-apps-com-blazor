using Modernizing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Core.Repositories
{
    public interface IRaffleRepository
    {
        Task<Participant> RaffleAsync(int meetupId);
    }
}
