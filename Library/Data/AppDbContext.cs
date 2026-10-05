using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Member>members { get; set; }
        public DbSet<Borrowing>borrowings { get; set; }       
        public DbSet<Category> categories { get; set; }
        public DbSet<Book> books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(x => x.ISBN).IsUnique();


            modelBuilder.Entity<Category>().HasMany(x=>x.books).WithOne(x=>x.category).HasForeignKey(x=>x.CategoryId);
            modelBuilder.Entity<Member>().HasMany(x=>x.borrowings).WithOne(x=>x.member).HasForeignKey(x=>x.MemberId);
            modelBuilder.Entity<Book>().HasMany(x=>x.Borrowings).WithOne(x=>x.book).HasForeignKey(x=>x.BookId);

            modelBuilder.Entity<Member>().HasData(
             new Member
             {
                 MemberId = 1,
                 FullName = "Ahmed Hassan",
                 Email = "ahmed@example.com",
                 Phone = "01012345678",
                
             },
                 new Member {
             MemberId=2,
             FullName= "Sara Mohamed",
             Email= "sara@example.com",
             Phone= "01198765432",
          });


            modelBuilder.Entity<Category>().HasData(
                new Category {
                CategoryId = 1,
                Name = "Programming",
                Description = "Programming and software development books",
            },
                  new Category
                  {
                      CategoryId = 2,
                      Name = "Database",
                      Description = "Database and data management books",
                      
                  });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "C++ Basics",
                    Auther = "John Smith",
                    ISBN = "ISBN001",
                    Price = 450,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "SQL Fundamentals",
                    Auther = "Sarah Ali",
                    ISBN = "ISBN002",
                    Price = 500,
                    IsAvailable = false,
                    CategoryId= 2
                });

            modelBuilder.Entity<Borrowing>().HasData(
                new Borrowing
                {
                    BorrowingId = 1,
                    BorrowDate = new DateTime(2026 - 09 - 20),
                    ReturnDate = new DateTime(2026 - 09 - 25),
                    BookId = 1,
                },
                    new Borrowing
                    {
                        BorrowingId = 2,
                        BorrowDate = new DateTime(2026 - 09 - 22),
                        ReturnDate = null,
                        BookId = 2,
                    });


        }



    }
}
