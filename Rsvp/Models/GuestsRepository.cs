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

        public HouseholdViewModel GetHouseholdById(Guid id)
        {
            var household = _guestsContext.Household.FirstOrDefault(h => h.Id == id);
            return household.ToHouseholdViewModel();
        }
        public HouseholdViewModel GetFullHouseholdById(Guid id)
        {
            var household = _guestsContext.Household.FirstOrDefault(h => h.Id == id);
            if (household == null)
            {
                return null;
            }
            var householdViewModel = household.ToHouseholdViewModel();
            householdViewModel.Guests = GetGuestsInHouseholdWithId(id);
            return householdViewModel;
        }

        public IEnumerable<GuestViewModel> GetGuestsInHouseholdWithId(Guid id)
        {
            var guests = _guestsContext.Guest.Where(g => g.HouseholdId == id);
            foreach (var guest in guests)
            {
                yield return guest.ToGuestViewModel();
            }
        }

        /// <summary>
        /// Sends RSVP status replies for the guests in a household. Returns whether we were able to save it or not.
        /// </summary>
        public bool UpdateRsvpStatusForHousehold(HouseholdViewModel householdViewModel)
        {
            foreach (var guestViewModel in householdViewModel.Guests)
            {
                var guest = _guestsContext.Guest.FirstOrDefault(g => g.Id == guestViewModel.Id);
                if (guest == null)
                {
                    return false;
                }
                guest.RsvpStatusId = GetRsvpStatusId(guestViewModel.RsvpReply);
                guest.SongRequest = guestViewModel.SongRequest;
                guest.DietaryRequirements = guestViewModel.DietaryRequirements;
                guest.HotelRequirementId = (int)guestViewModel.HotelRequirement;
                guest.RequiresTransport = guestViewModel.RequiresTransport;
            }

            return _guestsContext.SaveChanges() > 0;
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
        private int GetRsvpStatusId(RsvpStatus status)
        {
            var dbStatus = _guestsContext.RsvpStatus.FirstOrDefault(s => s.Status == status.ToString());
            if (dbStatus != null)
            {
                return dbStatus.Id;

            }
            // TODO DS do something
            throw new Exception();
        }
    }
}
