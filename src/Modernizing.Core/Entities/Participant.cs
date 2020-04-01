using System;
using System.Collections.Generic;
using System.Text;

namespace Modernizing.Core.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Meetup Meetup { get; set; }
        public bool Won { get; set; }

        public Participant()
        { }
        
        public Participant(int id, string name, string email, string phone, Meetup meetup, bool won)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Meetup = meetup;
            Won = won;
        }

        public Participant(string name, string email, string phone, Meetup meetup, bool won)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Meetup = meetup;
            Won = won;
        }

        public void Win()
        {
            Won = true;
        }
    }
}
