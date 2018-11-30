using System;
using System.Collections.Generic;

namespace Rsvp.ViewModels
{
    public class HouseholdViewModel
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }

        public IEnumerable<GuestViewModel> Guests { get; set; }
    }
}
