using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class ApplicationDbContext : DbContext
    {



        public DbSet<Customers> Customers { get; set; }
        public DbSet<Officer> Officer { get; set; }
        public DbSet<OrderManagment> OrderManagement { get; set; }
        public DbSet<SavingImage> SavingImages { get; set; }
        public DbSet<Status> Statuse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=DESKTOP-69LTTPD\\SQLEXPRESS;Database=PhotoManagmentDB_Sara;Trusted_Connection = True;Encrypt=False");

        }
    }
}



