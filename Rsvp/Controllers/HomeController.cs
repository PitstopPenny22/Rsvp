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
            try
            {
                var success = Guid.TryParse(idAsString, out var id);
                if (!success)
                {
                    return RedirectToAction("Index");
                }

                var householdViewModel = _guestsRepository.GetFullHouseholdById(id);
                if (householdViewModel == null)
                {
                    return RedirectToAction("Index");
                }
                return View(householdViewModel);
            }
            catch (Exception ex)
            {
                // TODO DS log ex
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult SendRsvpReply(HouseholdViewModel householdViewModel)
        {
            try
            {
                _guestsRepository.UpdateRsvpStatusForHousehold(householdViewModel);
                return View(householdViewModel);
            }
            catch (Exception ex)
            {
                // TODO DS log ex
                return RedirectToAction("Index");
            }
        }

    }
}