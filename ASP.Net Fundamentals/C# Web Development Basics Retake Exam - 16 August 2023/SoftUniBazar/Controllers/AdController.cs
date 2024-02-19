namespace SoftUniBazar.Controllers
{
	using System;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Contracts;
	using Models;

	[Authorize]
	public class AdController : BaseController
	{
		private readonly IAdService adService;

		public AdController(IAdService _adService)
		{
			adService = _adService;
		}

		public async Task<IActionResult> All()
		{
			IEnumerable<AdInfoViewModel> model = await adService.GetAllAdsAsync();
			return View(model);
		}

		public async Task<IActionResult> Add()
		{
			AdFormViewModel model = await adService.GetNewAdFormViewModelAsync();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AdFormViewModel model)
		{

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			string userId = GetUserId();

			await adService.AddAdAsync(model, userId);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				string userId = GetUserId();
				var model = await adService.GetNewAdEditViewModelAsync(id, userId);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}
			catch (UnauthorizedAccessException)
			{
				return Unauthorized();
			}

		}

		[HttpPost]
		public async Task<IActionResult> Edit(AdFormViewModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}


			try
			{
				string userId = GetUserId();
				await adService.EditAdAsync(model, id, userId);
			}
			catch (ArgumentNullException)
			{
				return BadRequest();
			}
			catch (InvalidOperationException)
			{
				return Unauthorized();
			}


			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int id)
		{
			try
			{
				string userId = GetUserId();
				await adService.AddAdToCartAsync(id, userId);
			}
			catch (ArgumentNullException)
			{
				return BadRequest();
			}
		
			return RedirectToAction(nameof(Cart));
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCart(int id)
		{
			try
			{
				string userId = GetUserId();
				await adService.RemoveAdFromCartAsync(id, userId);
			}
			catch (ArgumentNullException)
			{
				return BadRequest();
			}
		
			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> Cart()
		{
			string userId = GetUserId();

			IEnumerable<AdInfoViewModel> model = await adService.GetCartAsync(userId);

			return View(model);
		}
	}
}
