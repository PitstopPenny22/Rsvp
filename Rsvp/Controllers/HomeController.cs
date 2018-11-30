using Microsoft.AspNetCore.Mvc;
using Rsvp.Models.Interfaces;
using Rsvp.ViewModels;
using System;

namespace Rsvp.Controllers
{
    public class HomeController : Controller
    {
        private IGuestsRepository _guestsRepository;

        public HomeController(IGuestsRepository guestsRepository)
        {
            _guestsRepository = guestsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{idAsString}")]
        public IActionResult Household(string idAsString)
        {
            var success = Guid.TryParse(idAsString, out var id);
            if (!success)
            {
                 return NotFound(idAsString);    
            }

            var householdViewModel = _guestsRepository.GetHouseholdById(id);
            if (householdViewModel == null)
            {
                 return NotFound(idAsString);
            }
            var guests = _guestsRepository.GetGuestsInHouseholdWithId(id);
            householdViewModel.Guests = guests;
            return View(householdViewModel);
        }

        //[HttpPost]
        //public IActionResult RSVP(HouseholdViewModel householdViewModel)
        //{
        //   _guestsRepository.UpdateRsvpStatusForHousehold(householdViewModel);
        //    return View(householdViewModel);
        //}
        [HttpPost]
        public IActionResult RSVP(GuestViewModel[] guests)
        {
            return View();
        }
    }
}