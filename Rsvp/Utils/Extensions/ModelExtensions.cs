using Rsvp.Models.DB;
using Rsvp.Utils.Enums;
using Rsvp.ViewModels;
using System.Linq;
using RsvpStatus = Rsvp.Utils.Enums.RsvpStatus;

namespace Rsvp.Utils.Extensions
{
    public static class ModelExtensions
    {
        public static HouseholdViewModel ToHouseholdViewModel(this Household householdModel)
        {
            return new HouseholdViewModel
            {
                Id = householdModel.Id,
                EmailAddress = householdModel.EmailAddress,
                Guests = householdModel.Guest.Select(guest => guest.ToGuestViewModel()).ToList()
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
          
            guestViewModel.RsvpReply = EnumUtils.EnumStatusToDbStatusIdMap.ContainsValue(guestViewModel.RsvpStatusId)
                ? EnumUtils.EnumStatusToDbStatusIdMap.First(status => status.Value == guestViewModel.RsvpStatusId).Key
                : RsvpStatus.Accepted;
            return guestViewModel;
        }
    }
}