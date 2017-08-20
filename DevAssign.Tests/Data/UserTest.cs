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

        [TestMethod]
        public void CreateUser()
        {
            var fakeUser = new User() { Id = 1, FullName = "Ahmet Salih", Email="ahmet.salih@windowslive.com" };
            var _userRepository = new Mock<IRepository<User>>();
            _userRepository.Setup(s => s.Add(fakeUser)).Returns(fakeUser);

            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(s => s.SaveChanges()).Returns(1);

            var user = _userRepository.Object.Add(fakeUser);
            int result = _unitOfWork.Object.SaveChanges();

            Assert.IsNotNull(user);
            Assert.AreNotEqual(-1, result);

        }
        [TestMethod]
        public void GetUser()
        {
            var fakeUser = new List<User>() { new User() { Id = 1, FullName = "Ahmet Salih" } }.AsQueryable();

            var _userRepository = new Mock<IRepository<User>>();
            _userRepository.Setup(s => s.GetAll(null)).Returns(fakeUser);

            var user = _userRepository.Object.GetAll();

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var fakeUser = new User() { Id = 1, FullName = "Ahmet Salih", Email = "ahmet.salih@windowslive.com" };
            var _userRepository = new Mock<IRepository<User>>();
            _userRepository.Setup(s => s.Update(fakeUser));

            var _unitOfWork = new Mock<IUnitOfWork>();
            var result = _unitOfWork.Setup(s => s.SaveChanges()).Returns(1);

            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var fakeUser = new User() { Id = 1, FullName = "Ahmet Salih", Email = "ahmet.salih@windowslive.com" };
            var _userRepository = new Mock<IRepository<User>>();

            _userRepository.Setup(s => s.Delete(fakeUser));

            var _unitOfWork = new Mock<IUnitOfWork>();
            var result = _unitOfWork.Setup(s => s.SaveChanges()).Returns(1);

            Assert.AreNotEqual(-1, result);
        }
    }
}
