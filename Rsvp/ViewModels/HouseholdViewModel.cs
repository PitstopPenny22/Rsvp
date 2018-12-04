using System;
using System.Collections.Generic;
using System.Linq;

namespace Rsvp.ViewModels
{
    public class HouseholdViewModel
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<GuestViewModel> Guests { get; set; }

        public bool HasReplied
        {
            get
            {
                if (Guests == null)
                {
                    return false;
                }
                else
                {
                    return Guests.All(g => g.RsvpStatusId != 2); // 2 is pending reply
                }
            }
        }
    }
}