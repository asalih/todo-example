﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevAssign;
using DevAssign.Controllers;

namespace DevAssign.Tests.Controllers
{
    [TestClass]
    public class CommonControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CommonController controller = new CommonController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Contact()
        {
            // Arrange
            CommonController controller = new CommonController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}