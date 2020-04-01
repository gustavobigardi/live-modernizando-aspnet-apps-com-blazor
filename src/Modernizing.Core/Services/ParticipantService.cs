using Modernizing.Core.Dtos;
using Modernizing.Core.Entities;
using Modernizing.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modernizing.Core.Services
{
    public class ParticipantService
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<ParticipantDto> AddAsync(ParticipantDto dto)
        {
            var entity = await _participantRepository.AddAsync(
                new Participant(dto.Name, dto.Email, dto.Phone, new Meetup(dto.MeetupId), false));
            return new ParticipantDto(entity.Id, entity.Name, entity.Email, entity.Phone, entity.Meetup.Id, entity.Meetup.Name, entity.Won);
        }

        public async Task DeleteAsync(int id)
        {
            await _participantRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ParticipantDto>> GetAllAsync()
        {
            var result = await _participantRepository.GetAllAsync();
            return result.Select(p => new ParticipantDto(p.Id, p.Name, p.Email, p.Phone, p.Meetup.Id, p.Meetup.Name, p.Won));
        }

        public async Task<ParticipantDto> GetByIdAsync(int id)
        {
            var entity = await _participantRepository.GetByIdAsync(id);
            return new ParticipantDto(entity.Id, entity.Name, entity.Email, entity.Phone, entity.Meetup.Id, entity.Meetup.Name, entity.Won);
        }

        public async Task<ParticipantDto> UpdateAsync(ParticipantDto dto)
        {
            var entity = await _participantRepository.UpdateAsync(new Participant(dto.Id, dto.Name, dto.Email, dto.Phone, new Meetup(dto.MeetupId), dto.Won));
            return new ParticipantDto(entity.Id, entity.Name, entity.Email, entity.Phone, entity.Meetup.Id, entity.Meetup.Name, entity.Won);
        }
    }
}
