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
            return View();
        }
        [Route("not-found")]
        public ActionResult NotFound()
        {
            return View();
        }
        [Route("~/error")]
        public ActionResult HttpException()
        {
            return View("Error");
        }
    }
}