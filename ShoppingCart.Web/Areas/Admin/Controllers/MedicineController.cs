using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingCart.DataAccess.Repositories;
using ShoppingCart.DataAccess.ViewModels;
using ShoppingCart.Models;
using System;
using System.Linq;

namespace ShoppingCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicineController : Controller
    {
        private IUnitOfWork _unitofWork;
        private IWebHostEnvironment _hostingEnvironment;

        public Medicine Medicine { get; set; }

        public MedicineController(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        #region API Call
        public IActionResult AllMedicines()
        {
            var medicines = _unitofWork.Medicine.GetAll(includeProperties: "Category");
            return Json(new { data = medicines });
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            MedicineVM vm = new MedicineVM() {
                Medicine = new Medicine(),
                Categories = _unitofWork.Category.GetAll().Select(x=> 
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if (id == null | id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Medicine = _unitofWork.Medicine.GetT(x => x.Id == id);
                if(vm.Medicine == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // public IActionResult CreateUpdate(MedicineController vm,IFormFile? file)
        public IActionResult CreateUpdate(MedicineController vm)
        {
            if (ModelState.IsValid)
            {
                //string fileName = String.Empty;
                //if (file != null)
                //{
                //    string uploadDir = Path.combine(_hostingEnvironment.WebRootPath,"MedicineImage");
                //    fileName=Guid.NewGuid().ToString()+"-"+file.FileName;
                //    string filePath = filePath.Combine(uploadDir, fileName);
                //    if (vm.Medicine.ImageURL != null)
                //    {
                //        var oldImagePath = filePath.combine(_hostingEnvironment.WebRootPath,vm.Medicine.ImageUrl.TrimStart('\\'));
                //        if (System.IO.File.Exists(oldImagePath))
                //        {
                //            System.IO.File.Delete(oldImagePath);
                //        }
                //    }
                //    using (var fileStream=new Filestream(filePath, FileMode.Create))
                //    {
                //        file.CopyTo(fileStream);
                //    }
                //    vm.Medicine.ImageUrl = @"\ProductImage\"+fileName;
                //}

                if (vm.Medicine.Id == 0)
                {
                    _unitofWork.Medicine.Add(vm.Medicine);
                    TempData["success"] = "Medicine Created Done"; 
                }
                else
                {
                    _unitofWork.Medicine.Update(vm.Medicine);
                    TempData["success"] = "Medicine Updated Done";

                }
                 
                _unitofWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}