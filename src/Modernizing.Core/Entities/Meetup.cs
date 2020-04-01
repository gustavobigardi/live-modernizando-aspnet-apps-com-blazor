using System;
using System.Collections.Generic;
using System.Text;

namespace Modernizing.Core.Entities
{
    public class Meetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public virtual IList<Participant> Participants { get; set; }

        public Meetup()
        { }

        public Meetup(int id)
        {
            Id = id;
        }

        public Meetup(int id, string name, bool available)
        {
            Id = id;
            Name = name;
            Available = available;
        }

        public Meetup(string name, bool available)
        {
            Name = name;
            Available = available;
        }
    }
}
