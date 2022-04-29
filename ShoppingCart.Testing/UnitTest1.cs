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

        private ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "MedicineDataBase");
            //.UseInMemoryDatabase(Guid.NewGuid().ToString("N"));//.UseInMemoryDatabase>;
            // optionsBuilder.UseInMemoryDatabase();
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);
            return _dbContext;
        }

        [Test]
        public void addCategory()  //ToTest that addition of Category record
        {
            var _dbContext = CreateDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            var sut = new CategoryRepository(_dbContext);
            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            sut.Add(category);
            _dbContext.SaveChanges();
            var result = sut.GetAll();
            int id22 = 0;
            foreach (var item in result)
            {
                id22 = item.Id;
            }
            Assert.AreEqual(1, id22);
            _dbContext.Dispose();
        }

        [Test]
        public void UpdateCategory() //Test Update of Category record
        {
            var _dbContext = CreateDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            var sut = new CategoryRepository(_dbContext);
            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            sut.Add(category);
            _dbContext.SaveChanges();
            category.Description = "Test1 Description Updated";
            sut.Update(category);
            _dbContext.SaveChanges();


            var check= unitOfWork.Category.GetT(p => p.Id == category.Id);
            Assert.AreEqual("Test1 Description Updated", check.Description);
            _dbContext.Dispose();
        }

        [Test]
        public void DeleteCategory() //Test Deletion of Category record
        {
            var _dbContext = CreateDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            var sut = new CategoryRepository(_dbContext);
            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            var result = sut.AddT(category);
            _dbContext.SaveChanges();
           
            sut.Delete(category);
            _dbContext.SaveChanges();


            var isExists = unitOfWork.Category.GetT(p => p.Id == result.Id);

            //Assert.IsFalse(isExists);
            Assert.AreEqual(null, isExists);
            _dbContext.Dispose();
        }

        [Test]
        public void addMedicine()
        {
            var _dbContext = CreateDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            //Add Category Record
            var sut = new CategoryRepository(_dbContext);
            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            sut.Add(category);
            int id22 = 0;
            var result = sut.GetAll();
            foreach (var item in result)
            {
                id22 = item.Id;
            }

            var med = new MedicineRepository(_dbContext);
            var medicine = new Medicine { Name = "Test1", Description = "Test1 Description",Price=10, CategoryId=id22};
            med.Add(medicine);
            _dbContext.SaveChanges();
            var result1 = med.GetAll();
            int id33 = 0;
            foreach (var item in result1)
            {
                id33 = item.CategoryId;
            }
            Assert.AreEqual(id33, id22);
            _dbContext.Dispose();

        }


        [Test]
        public void updateMedicine()
        {
            var _dbContext = CreateDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            //Add Category Record
            var sut = new CategoryRepository(_dbContext);
            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            sut.Add(category);
            int id22 = 0;
            var result = sut.GetAll();
            foreach (var item in result)
            {
                id22 = item.Id;
            }

            var med = new MedicineRepository(_dbContext);
            var medicine = new Medicine { Name = "Test1", Description = "Test1 Description", Price = 10, CategoryId = id22 };
            med.Add(medicine);
            _dbContext.SaveChanges();

            medicine.Price = 20;
            med.Update(medicine);
            var result2 = med.GetById(medicine.Id);


            Assert.AreEqual(20, result2.Price);
            _dbContext.Dispose();

        }

        [Test]
        public void deleteMedicine()
        {
            var _dbContext = CreateDbContext();
            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            //Add Category Record
            var sut = new CategoryRepository(_dbContext);
            var category = new Category { Name = "Test1", Description = "Test1 Description" };
            sut.Add(category);
            int id22 = 0;
            var result = sut.GetAll();
            foreach (var item in result)
            {
                id22 = item.Id;
            }

            var med = new MedicineRepository(_dbContext);
            var medicine = new Medicine { Name = "Test1", Description = "Test1 Description", Price = 10, CategoryId = id22 };
            var medres=med.AddT(medicine);
            _dbContext.SaveChanges();

            med.Delete(medicine);
            _dbContext.SaveChanges();

            var isExists = unitOfWork.Medicine.GetT(p => p.Id == medres.Id);
            Assert.AreEqual(null, isExists);
            _dbContext.Dispose();

        }
    }
}