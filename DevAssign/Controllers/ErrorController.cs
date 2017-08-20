using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevAssign.Controllers
{
    [RoutePrefix("error")]
    public class ErrorController : BaseController
    {
        [Route("unexpected-error")]
        public ActionResult Unexpected()
        {
            Response.StatusCode = 500;
            return View();
        }
        [Route("not-found")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
        [Route("~/error")]
        public ActionResult HttpException()
        {
            Response.StatusCode = 500;
            return View("Error");
        }
    }
}