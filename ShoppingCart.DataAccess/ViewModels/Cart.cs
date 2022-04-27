using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataAccess.ViewModels
{
    public class Cart
    {
        public int Id { get; set; }

        public int MedicineId { get; set; }
        [ValidateNever]

        public Medicine Medicine { get; set; }
        [ValidateNever]

        public string ApplicationUserId { get; set; }
        [ValidateNever]

        public ApplicationUser ApplicationUser { get; set; }
        public int Count { get; set; }


    }
}
