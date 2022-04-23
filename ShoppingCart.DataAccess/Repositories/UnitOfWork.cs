using ShoppingCart.DataAccess.Data;
using ShoppingCart.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IMedicineRepository Medicine { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Medicine = new MedicineRepository(context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
