using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ShoppingCart.DataAccess.ViewModels
//{
//    public class MedicineVM
//    {
//        public Medicine Medicine { get; set; } = new Medicine();

//      [ValidateNever]
//        public IEnumerable<Medicine> Medicines { get; set; } = new List<Medicine>();
//        [ValidateNever]
//        public IEnumerable<SelectListItem> Categories { get; set; }
//    }
//}


namespace ShoppingCart.DataAccess.ViewModels
{
    public class MedicineVM
    {
        public Medicine Medicine { get; set; } = new Medicine();


      
        public IEnumerable<Medicine> medicines { get; set; } = new List<Medicine>();
       // Debug.log(medicines);

        public IEnumerable<SelectListItem> Categories { get; set; }
    }

}

