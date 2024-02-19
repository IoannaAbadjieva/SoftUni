using SeminarHub.Data.DataValidation;

namespace SeminarHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Category;

    public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = string.Empty;

		public ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();
	}
}