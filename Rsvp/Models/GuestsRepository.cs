using System;
using System.Collections.Generic;
using System.Linq;
using Rsvp.Models.DB;
using Rsvp.Models.Interfaces;
using Rsvp.Utils.Extensions;
using Rsvp.ViewModels;
using RsvpStatus = Rsvp.Utils.Enums.RsvpStatus;

namespace Rsvp.Models
{
    public class GuestsRepository : IGuestsRepository
    {
        private GuestsContext _guestsContext;

        public GuestsRepository(GuestsContext guestsContext)
        {
            _guestsContext = guestsContext;
        }

        //private void PopulateTableIfEmpty()
        //{
        //    if (_guestsContext.Household.Any())
        //    {
        //        return;
        //    }
        //    foreach (var householdAddress in DataUtils.HouseholdEmailAddresses)
        //    {
        //        var id = Guid.NewGuid();
        //        _guestsContext.Household.Add(new Household(id, householdAddress));
        //    }
        //    _guestsContext.SaveChanges();
        //}

        public HouseholdViewModel GetHouseholdById(Guid id)
        {
            var household = _guestsContext.Household.FirstOrDefault(h => h.Id == id);
            return household.ToHouseholdViewModel();
        }

        public IEnumerable<GuestViewModel> GetGuestsInHouseholdWithId(Guid id)
        {
            var guests = _guestsContext.Guest.Where(g => g.HouseholdId == id);
            foreach (var guest in guests)
            {
                yield return guest.ToGuestViewModel();
            }
        }

        public void UpdateRsvpStatusForHousehold(HouseholdViewModel householdViewModel)
        {
            foreach (var guestViewModel in householdViewModel.Guests)
            {
                var guest = _guestsContext.Guest.FirstOrDefault(g => g.Id == guestViewModel.Id);
                if (guest == null)
                {
                    return; // TODO DS return false?
                }
                guest.RsvpStatusId = GetRsvpStatusId(guestViewModel.RsvpReply);
                guest.SongRequest = guestViewModel.SongRequest;
                guest.DietaryRequirements = guestViewModel.DietaryRequirements;
                guest.HotelRequirementId = (int)guestViewModel.HotelRequirement;
                guest.RequiresTransport = guestViewModel.RequiresTransport;
                //_guestsContext.SaveChanges(); // TODO DS uncomment this
            }
        }

        private int GetRsvpStatusId(RsvpStatus status)
        {
            var dbStatus = _guestsContext.RsvpStatus.FirstOrDefault(s => s.Status == nameof(status));
            if (dbStatus == null)
            {
                // TODO DS do something
            }
            return dbStatus.Id;
        }
    }
}
