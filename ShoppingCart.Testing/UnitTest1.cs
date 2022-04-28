using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ShoppingCart.DataAccess.Data;
using ShoppingCart.DataAccess.Migrations;
using ShoppingCart.DataAccess.Repositories;
using ShoppingCart.DataAccess.ViewModels;
using ShoppingCart.Models;
using ShoppingCart.Web.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.InMemory;

namespace ShoppingCart.Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           

          //  Medicine medicine = new Medicine() { Name="ABC",Description="For XYZ",Price=10,CategoryId=categoryId};
        }

        [Test]
        public void addCategory()
        {
            // var mockContext = new Mock<ApplicationDbContext>();
            // var dbContext = ApplicationDbContext();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();//.UseInMemoryDatabase>;
           // optionsBuilder.UseInMemoryDatabase();
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
          //  CategoryController categoryController = new CategoryController(unitOfWork);



            Category category = new Category();
            category.Name = "Test1";
            category.Description = "Test1 Desciption";

            Category category2 = new Category();
            category2.Name = "Test2";
            category2.Description = "Test2 Desciption";

            CategoryVM categoryVM = new CategoryVM();
            CategoryVM categoryVM1 = new CategoryVM();


            categoryVM.categories = unitOfWork.Category.GetAll();

            //Get current count of records
            int id11 = 0;
            foreach (var item in categoryVM.categories)
            {
                id11 = item.Id;
            }


            unitOfWork.Category.Add(category);
            unitOfWork.Category.Add(category2);




            
            categoryVM1.categories = unitOfWork.Category.GetAll();


            //var something=categoryController.CreateUpdate(categoryVM);
            //            Console.Write(categoryVM1.categories);
            int id22=0;
            foreach (var item in categoryVM1.categories)
            {
                id22 = item.Id;
            }
                 
           
            
            Assert.AreEqual(id11+2, id22);
            //var item in Model.categories
            //CategoryRepository   cr= new CategoryRepository();
            ////UnitOfWork _unitofWork;
            //UnitOfWork _unitofWork = new UnitOfWork();

            //_unitofWork.category.Add(categoryVM.Category);

        }

        [Test]
        public void addCategory1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();//.UseInMemoryDatabase(Guid.NewGuid().ToString("N"));//.UseInMemoryDatabase>;
                                                                                     // optionsBuilder.UseInMemoryDatabase();
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);

            var sut = new CategoryRepository(_dbContext);
            var result1 = sut.GetAll();
            int id11 = 0;
            foreach (var item in result1)
            {
                id11 = item.Id;
            }

            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            sut.Add(category);
            _dbContext.SaveChanges();
            var result = sut.GetAll();
            //result.ToString();
            int id22 = 0;
            foreach (var item in result)
            {
                id22 = item.Id;
            }

            Assert.AreEqual(id11+1, id22);
            _dbContext.Dispose();


        }
    }
}