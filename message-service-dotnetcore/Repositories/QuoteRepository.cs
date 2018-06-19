using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Repositories
{
    public class QuoteRepository : DbContext
    {
        public DbSet<BillboardQuote> Quotes { get; set; }

        public QuoteRepository(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillboardQuote>().HasData(new BillboardQuote { Id = 1, Quote = "Never, never, never give up", Author = "Winston Churchill" });
            modelBuilder.Entity<BillboardQuote>().HasData(new BillboardQuote { Id = 2, Quote = "While there''s life, there''s hope", Author = "Marcus Tullius Cicero" });
            modelBuilder.Entity<BillboardQuote>().HasData(new BillboardQuote { Id = 3, Quote = "Failure is success in progress", Author = "Anonymous" });
            modelBuilder.Entity<BillboardQuote>().HasData(new BillboardQuote { Id = 4, Quote = "Success demands singleness of purpose", Author = "Vincent Lombardi" });
            modelBuilder.Entity<BillboardQuote>().HasData(new BillboardQuote { Id = 5, Quote = "The shortest answer is doing", Author = "Lord Herbert" });
        }
    }
}
