using Rsvp.Utils.Enums;
using System;

namespace Rsvp.ViewModels
{
    public class GuestViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SeatNumber { get; set; }
        public int RsvpStatusId { get; set; }
        public RsvpStatus RsvpReply { get; set; }
        public string DietaryRequirements { get; set; }
        public string SongRequest { get; set; }
        public Guid HouseholdId { get; set; }
        public bool IsChild { get; set; }
        public HotelRequirementOptions HotelRequirement { get; set; }
        public bool RequiresTransport { get; set; }
    }
}