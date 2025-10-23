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
        public DbSet<LoanMaster> LoanMaster { get; set; }
        public DbSet<RepledgeMaster> RepledgeMaster { get; set; }
        public DbSet<LoanDetails> LoanDetails { get; set; }
        public DbSet<RepledgeDetails>  RepledgeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanMaster>().Property(u => u.LoanAmount).HasPrecision(15,5);
            modelBuilder.Entity<RepledgeMaster>().Property(u => u.LoanAmountFromBank).HasPrecision(15,5);
            modelBuilder.Entity<LoanMaster>().Property(u => u.DateTaken).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<LoanMaster>().Property(u => u.DueDate).HasDefaultValueSql("DATEADD(year,1,GETDATE())");

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { CustomerId=1, Name="Prashath", NIC= "856987452v", Phone="0715689562" },
                new Customer() { CustomerId=2, Name = "Ranmini", NIC="895698236v", Phone="0715458533" }
                );
            modelBuilder.Entity<Bank>().HasData(
                new Bank() { BankId=1, Name="HNB" },
                new Bank() { BankId=2, Name = "ABC" }
                );
            modelBuilder.Entity<LoanMaster>().HasData(
                new LoanMaster(){LoanId = 1, LoanAmount = 150.00m,CustomerId = 1, DateTaken= new DateTime(2025, 01, 01), DueDate= new DateTime(2026, 01, 01)}
                );
            modelBuilder.Entity<LoanDetails>().HasData(
                new LoanDetails() { LoanId=1, ArticleId=1, ArticleName="Ring", Unit=1, IsPledgedToBank = false }
                );

        }

    }
}
