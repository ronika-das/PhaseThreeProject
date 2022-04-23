using ShoppingCart.DataAccess.Data;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repositories
{
    public class MedicineRepository:Repository<Medicine>,IMedicineRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicineRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void Update(Medicine medicine)
        {
            var medicineDb = _context.Medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if(medicineDb != null)
            {
                medicineDb.Name = medicine.Name;
                medicineDb.Description = medicine.Description;
                medicineDb.Price = medicine.Price;

            }
        }
    }
}
