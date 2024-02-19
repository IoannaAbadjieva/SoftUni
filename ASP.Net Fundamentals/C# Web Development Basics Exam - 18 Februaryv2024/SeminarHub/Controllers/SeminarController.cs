namespace SeminarHub.Controllers
{
	using System;
	using System.Security.Claims;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Contracts;
	using Models.Seminar;

	[Authorize]
	public class SeminarController : Controller
	{
		private readonly ISeminarService seminarService;

		public SeminarController(ISeminarService _seminarService)
		{
			seminarService = _seminarService;
		}

		public async Task<IActionResult> Add()
		{
			var model = new SeminarFormViewModel()
			{
				Categories = await seminarService.GetCategoriesAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(SeminarFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = await seminarService.GetCategoriesAsync();
				return View(model);
			}

			var userId = GetUserId();

			await seminarService.AddSeminarAsync(model, userId);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> All()
		{
			IEnumerable<SeminarInfoViewModel> model = await seminarService.GetAllSeminarsAsync();
			return View(model);
		}

		public async Task<IActionResult> Joined()
		{
			string userId = GetUserId();

			IEnumerable<SeminarInfoViewModel> model = await seminarService.GetJoinedSeminarsAsync(userId);

			return View(model);
		}

		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var userId = GetUserId();
				SeminarFormViewModel model = await seminarService.GetSeminarByIdAsync(id, userId);
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
		public async Task<IActionResult> Edit(int id, SeminarFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = await seminarService.GetCategoriesAsync();
				return View(model);
			}

			try
			{
				var userId = GetUserId();
				await seminarService.EditSeminarAsync(id, model, userId);
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
				await seminarService.JoinSeminarAsync(id, userId);
				return RedirectToAction(nameof(Joined));
			}
			catch (InvalidOperationException)
			{
				return RedirectToAction(nameof(All));
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
				await seminarService.LeaveSeminarAsync(id, userId);
				return RedirectToAction(nameof(Joined));
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
				SeminarDetailsViewModel model = await seminarService.GetSeminarDetailsAsync(id);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}

		}

		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var userId = GetUserId();
				SeminarDeleteViewModel model = await seminarService.GetSeminarToDeleteByIdAsync(id, userId);
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
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				var userId = GetUserId();
				await seminarService.DeleteSeminarAsync(id, userId);
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

		private string GetUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
