using Microsoft.AspNetCore.Mvc;
using Rsvp.ViewModels;
using System.Threading.Tasks;

namespace Rsvp.ViewComponents
{
    public class GuestViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(GuestViewModel guestViewModel)
        {
            return View(guestViewModel);
        }
    }
}
