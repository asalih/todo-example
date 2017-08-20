using DevAssign.Data;
using DevAssign.Data.Context;
using DevAssign.Data.Contracts;
using DevAssign.Data.Model;
using DevAssign.Data.Repositories;
using DevAssign.Data.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAssign.Tests.Data
{
    [TestClass]
    public class UserTest
    {
        private EFDataContext context;

        private IUnitOfWork unitOfWork;
        private IRepository<User> userRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            context = new EFDataContext();
            unitOfWork = new EFUnitOfWork(context);
            userRepository = unitOfWork.GetRepository<User>();
        }

        [TestMethod]
        public void CreateUser()
        {
            User user = new User
            {
                CreateDate = DateTime.Now,
                Email = "asalih@testuser.com",
                FullName = "Ahmet Salih",
                Password = "123456"
            };

            userRepository.Add(user);
            int result = unitOfWork.SaveChanges();

            Assert.AreNotEqual(-1, result);

        }
        [TestMethod]
        public void GetUser()
        {
            User user = userRepository.GetById(1);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = userRepository.GetById(1);

            user.Password = "123456";
            userRepository.Update(user);
            int result = unitOfWork.SaveChanges();

            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = userRepository.GetById(1);

            userRepository.Delete(user);
            int result = unitOfWork.SaveChanges();

            Assert.AreNotEqual(-1, result);
        }
    }
}
