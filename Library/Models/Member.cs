using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public ICollection<Borrowing>borrowings { get; set; }=new List<Borrowing>();
    }
}
