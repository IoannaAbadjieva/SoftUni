namespace Homies.Controllers
{
    using System;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models;


    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<EventInfoViewModel> model = await eventService.GetAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            IEnumerable<EventInfoViewModel> model = await eventService.GetJoinedEventsAsync(userId);

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel()
            {
                Types = await eventService.GetEventTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetEventTypesAsync();
                return View(model);
            }

            var userId = GetUserId();

            await eventService.AddEventAsync(model, userId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var userId = GetUserId();
                EventFormViewModel model = await eventService.GetEventFormViewModelAsync(id, userId);
                return View(model);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userId = GetUserId();
                await eventService.EditEventAsync(id, model, userId);
                return RedirectToAction(nameof(All));
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return Unauthorized();
            }

        }

        public async Task<IActionResult> Join(int id)
        {
            try
            {
                var userId = GetUserId();
                await eventService.JoinToEventAsync(id, userId);
                return RedirectToAction(nameof(Joined));
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Leave(int id)
        {
            try
            {
                var userId = GetUserId();
                await eventService.LeaveEventAsync(id, userId);
                return RedirectToAction(nameof(All));
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                EventDetailsViewModel model = await eventService.GetEventDetailsAsync(id);
                return View(model);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
