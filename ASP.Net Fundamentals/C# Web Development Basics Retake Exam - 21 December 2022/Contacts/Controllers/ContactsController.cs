namespace Contacts.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Models;


    [Authorize]
    public class ContactsController : Controller
    {
        private ContactsDbContext context;

        public ContactsController(ContactsDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> All()
        {
            var model = await context.Contacts
                .AsNoTracking()
                .Select(c => new ContactInfoViewModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Website = c.Website
                }).ToArrayAsync();

            return View(model);
        }

        public async Task<IActionResult> AddToTeam(int id)
        {
            var contact = await context.Contacts
                .Where(c => c.Id == id)
                .Include(c => c.ApplicationUsersContacts)
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var uc = contact.ApplicationUsersContacts
                .FirstOrDefault(uc => uc.ApplicationUserId == userId);

            if (uc == null)
            {
                contact.ApplicationUsersContacts.Add(new ApplicationUserContact()
                {
                    ApplicationUserId = userId,
                });

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            var contact = await context.Contacts
                .Where(c => c.Id == id)
                .Include(c => c.ApplicationUsersContacts)
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var uc = contact.ApplicationUsersContacts
                .FirstOrDefault(uc => uc.ApplicationUserId == userId);

            if (uc != null)
            {
                contact.ApplicationUsersContacts.Remove(uc);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Team));
        }

        public async Task<IActionResult> Team()
        {
            string userId = GetUserId();

            var model = await context.ApplicationUserContacts
               .AsNoTracking()
               .Where(uc => uc.ApplicationUserId == userId)
               .Select(uc => new ContactInfoViewModel()
               {
                   Id = uc.ContactId,
                   FirstName = uc.Contact.FirstName,
                   LastName = uc.Contact.LastName,
                   Email = uc.Contact.Email,
                   PhoneNumber = uc.Contact.PhoneNumber,
                   Address = uc.Contact.Address,
                   Website = uc.Contact.Website
               }).ToArrayAsync();

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new ContactFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var contact = await context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return BadRequest();
            }

            var model = new ContactFormViewModel()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address,
                Website = contact.Website
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ContactFormViewModel model)
        {
            var contact = await context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Address = model.Address;
            contact.Website = model.Website;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
