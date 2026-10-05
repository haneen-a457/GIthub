using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<Book> books { get; set; } = new List<Book>();
    }
}
