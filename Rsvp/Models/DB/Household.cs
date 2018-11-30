using System;
using System.Collections.Generic;

namespace Rsvp.Models.DB
{
    public partial class Household
    {
        public Household()
        {
            Guest = new HashSet<Guest>();
        }

        public Guid Id { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Guest> Guest { get; set; }
    }
}
