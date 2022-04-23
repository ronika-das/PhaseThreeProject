using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IMedicineRepository Medicine { get; }
        public void Save();
    }
}
