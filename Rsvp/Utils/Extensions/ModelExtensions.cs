using Rsvp.Models.DB;
using Rsvp.Utils.Enums;
using Rsvp.ViewModels;
using System.Linq;
using RsvpStatus = Rsvp.Utils.Enums.RsvpStatus;

namespace Rsvp.Utils.Extensions
{
    public static class ModelExtensions
    {
        public static Household ToHouseholdModel(this HouseholdViewModel householdViewModel)
        {
            return new Household
            {
                Id = householdViewModel.Id,
                EmailAddress = householdViewModel.EmailAddress,
                Guest = householdViewModel.Guests.Select(guest => guest.ToGuestModel()).ToList()
            };
        }
        public static HouseholdViewModel ToHouseholdViewModel(this Household householdModel)
        {
            return new HouseholdViewModel
            {
                Id = householdModel.Id,
                EmailAddress = householdModel.EmailAddress,
                Guests = householdModel.Guest.Select(guest => guest.ToGuestViewModel()).ToList()
            };
        }


        public static Guest ToGuestModel(this GuestViewModel guestViewModel)
        {
            return new Guest
            {
                Id = guestViewModel.Id,
                FirstName = guestViewModel.FirstName,
                LastName = guestViewModel.LastName,
                SeatNumber = guestViewModel.SeatNumber,
                DietaryRequirements = guestViewModel.DietaryRequirements,
                SongRequest = guestViewModel.SongRequest,
                RsvpStatusId = guestViewModel.RsvpReply == RsvpStatus.Accepted ? 4 : 3,
                HouseholdId = guestViewModel.HouseholdId,
                IsChild = guestViewModel.IsChild,
                HotelRequirementId = (int)guestViewModel.HotelRequirement,
                RequiresTransport = guestViewModel.RequiresTransport
            };
        }
        public static GuestViewModel ToGuestViewModel(this Guest guestModel)
        {
            var guestViewModel = new GuestViewModel
            {
                Id = guestModel.Id,
                FirstName = guestModel.FirstName,
                LastName = guestModel.LastName,
                SeatNumber = guestModel.SeatNumber,
                DietaryRequirements = guestModel.DietaryRequirements,
                SongRequest = guestModel.SongRequest,
                HouseholdId = guestModel.HouseholdId,
                IsChild = guestModel.IsChild,
                HotelRequirement = (HotelRequirementOptions)guestModel.HotelRequirementId,
                RsvpStatusId = guestModel.RsvpStatusId,
                RequiresTransport = guestModel.RequiresTransport
            };
         

            return guestViewModel;
        }
    }
}