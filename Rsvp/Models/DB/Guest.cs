using System;
using System.Collections.Generic;

namespace Rsvp.Models.DB
{
    public partial class Guest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SeatNumber { get; set; }
        public string DietaryRequirements { get; set; }
        public string SongRequest { get; set; }
        public int RsvpStatusId { get; set; }
        public Guid HouseholdId { get; set; }
        public bool IsChild { get; set; }
        public int HotelRequirementId { get; set; }
        public bool RequiresTransport { get; set; }

        public Household Household { get; set; }
        public RsvpStatus RsvpStatus { get; set; }
    }
}
