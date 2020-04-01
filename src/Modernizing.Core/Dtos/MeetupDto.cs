using System;
using System.Collections.Generic;
using System.Text;

namespace Modernizing.Core.Dtos
{
    public class MeetupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }

        public MeetupDto(int id, string name, bool available)
        {
            Id = id;
            Name = name;
            Available = available;
        }
    }
}
