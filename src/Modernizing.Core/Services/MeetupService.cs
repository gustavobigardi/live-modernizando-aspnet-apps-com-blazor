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
    public class MeetupService
    {
        private readonly IMeetupRepository _meetupRepository;

        public MeetupService(IMeetupRepository meetupRepository)
        {
            _meetupRepository = meetupRepository;
        }

        public async Task<MeetupDto> AddAsync(MeetupDto dto)
        {
            var entity = await _meetupRepository.AddAsync(
                new Meetup(dto.Name, dto.Available));
            return new MeetupDto(entity.Id, entity.Name, entity.Available);
        }

        public async Task DeleteAsync(int id)
        {
            await _meetupRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MeetupDto>> GetAllAsync()
        {
            var result = await _meetupRepository.GetAllAsync();
            return result.Select(m => new MeetupDto(m.Id, m.Name, m.Available));
        }

        public async Task<MeetupDto> GetByIdAsync(int id)
        {
            var entity = await _meetupRepository.GetByIdAsync(id);
            return new MeetupDto(entity.Id, entity.Name, entity.Available);
        }

        public async Task<MeetupDto> UpdateAsync(MeetupDto dto)
        {
            var entity = await _meetupRepository.UpdateAsync(new Meetup(dto.Id, dto.Name, dto.Available));
            return new MeetupDto(entity.Id, entity.Name, entity.Available);
        }
    }
}
