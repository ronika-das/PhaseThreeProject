using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server='DESKTOP-JCFHSDL';Database=MedicalDB;Integrated Security=true;");
        //    //optionsBuilder.UseSqlServer("Server=W10CBMFL13;Database=DellDB;User Id=sa;Password=sa@123456;");
        //}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
