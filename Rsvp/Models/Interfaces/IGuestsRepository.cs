using Rsvp.ViewModels;
using System;
using System.Collections.Generic;

namespace Rsvp.Models.Interfaces
{
    public interface IGuestsRepository
    {
        HouseholdViewModel GetHouseholdById(Guid id);
        HouseholdViewModel GetFullHouseholdById(Guid id);
        IEnumerable<GuestViewModel> GetGuestsInHouseholdWithId(Guid id);
        bool UpdateRsvpStatusForHousehold(HouseholdViewModel household);
    }
}