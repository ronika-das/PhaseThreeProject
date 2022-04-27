using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.DataAccess.Repositories;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace ShoppingCart.Web.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Medicine> medicines = _unitOfWork.Medicine.GetAll(includeProperties:"Category");
            return View(medicines);
        }
        [HttpGet]
        public IActionResult Details(int? medicineId)
        {
            Cart cart = new Cart()
            {
                Medicine = _unitOfWork.Medicine.GetT(x => x.Id == medicineId, includeProperties: "Category"),
                Count =1,
                MedicineId = (int)medicineId

            };
            return View(cart);
        }

       /* [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Cart cart)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claims.Value;

                var cartItem = _unitOfWork.Cart.GetT(x => x.MedicineId == cart.MedicineId &&
                x.ApplicationUserId==claims.Value);

                if (cartItem == null)
                {
                    _unitOfWork.Cart.Add(cart);
                    _unitOfWork.Save();
                    HttpContext.Session.SetInt32("SessionCart", _unitOfWork.Cart.GetAll(x => x.ApplicationUserId == claims.Value).ToList().Count);
                }
                else
                {
                    _unitOfWork.Cart.IncrementalCartItem(cartItem, cart.Count);
                    _unitOfWork.Save();
                }
            }
        } */


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
