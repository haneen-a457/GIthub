using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Antiforgery;

namespace Library.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }

        [AllowNull]
        public DateTime? ReturnDate { get;set; }

        //nav prop
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book book { get; set; }


        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        public Member member { get; set; }


    }
}
