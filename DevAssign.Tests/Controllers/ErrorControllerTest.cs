using DevAssign.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevAssign.Tests.Controllers
{
    [TestClass]
    public class ErrorControllerTest
    {
        [TestMethod]
        public void Unexpected()
        {
            // Arrange
            ErrorController controller = new ErrorController();

            // Act
            ViewResult result = controller.Unexpected() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void NotFound()
        {
            // Arrange
            ErrorController controller = new ErrorController();

            // Act
            ViewResult result = controller.NotFound() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void HttpException()
        {
            // Arrange
            ErrorController controller = new ErrorController();

            // Act
            ViewResult result = controller.HttpException() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
