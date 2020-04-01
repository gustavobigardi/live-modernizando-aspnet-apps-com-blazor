using System;
using System.Collections.Generic;
using System.Text;

namespace Modernizing.Core.Dtos
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int MeetupId { get; set; }
        public string MeetupName { get; set; }
        public bool Won { get; set; }

        public ParticipantDto(int id, string name, string email, string phone, int meetupId, string meetupName, bool won)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            MeetupId = meetupId;
            MeetupName = meetupName;
            Won = won;
        }
    }
}
