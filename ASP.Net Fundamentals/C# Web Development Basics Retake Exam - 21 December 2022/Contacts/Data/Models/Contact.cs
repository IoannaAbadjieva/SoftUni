namespace Contacts.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required]
        public string Website { get; set; } = string.Empty;

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; }
            = new HashSet<ApplicationUserContact>();

    }
}