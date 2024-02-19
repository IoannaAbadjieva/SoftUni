namespace Contacts.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
            = new HashSet<ApplicationUserContact>();
    }
}
