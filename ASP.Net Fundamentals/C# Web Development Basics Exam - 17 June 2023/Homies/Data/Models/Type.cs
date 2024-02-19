namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.DataConstants;

    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
