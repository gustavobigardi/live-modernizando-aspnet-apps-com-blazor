using Modernizing.Core.Dtos;
using Modernizing.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Core.Services
{
    public class RaffleService
    {
        private readonly IRaffleRepository _raffleRepository;

        public RaffleService(IRaffleRepository raffleRepository)
        {
            _raffleRepository = raffleRepository;
        }

        public async Task<ParticipantDto> RaffleAsync(int meetupId)
        {
            var entity = await _raffleRepository.RaffleAsync(meetupId);
            return new ParticipantDto(entity.Id, entity.Name, entity.Email, entity.Phone, entity.Meetup.Id, entity.Meetup.Name, entity.Won);
        }
    }
}
