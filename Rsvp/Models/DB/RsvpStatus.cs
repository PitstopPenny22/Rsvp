using System;
using System.Collections.Generic;

namespace Rsvp.Models.DB
{
    public partial class RsvpStatus
    {
        public RsvpStatus()
        {
            Guest = new HashSet<Guest>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<Guest> Guest { get; set; }
    }
}
