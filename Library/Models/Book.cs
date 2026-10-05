using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; } 
        [Required]
        public string Auther { get; set; } 
        [Required]
        public string ISBN { get; set; }
        [Required,Range(1,double.MaxValue)]
        public decimal Price {  get; set; }
        public  bool IsAvailable { get; set; } =true;
        public ICollection<Borrowing>Borrowings { get; set; }=new List<Borrowing>();
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category category { get; set; }

       

    }
}
