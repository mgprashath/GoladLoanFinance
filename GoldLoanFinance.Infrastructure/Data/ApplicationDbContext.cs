using GoldLoanFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Repledge> Repledges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().Property(u => u.LoanAmount).HasPrecision(15,5);
            modelBuilder.Entity<Repledge>().Property(u=>u.LoanAmountFromBank).HasPrecision(15,5);   
        }

    }
}
