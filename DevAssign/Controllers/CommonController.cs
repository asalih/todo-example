using System;
using System.Linq;
using System.Web.Mvc;
using DevAssign.Data.Model;
using DevAssign.Model;

namespace DevAssign.Controllers
{
    [Route("{action}")]
    public class CommonController : BaseController
    {
        [Route("~/")]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        [Route("signup")]
        public ActionResult SignUp()
        {
            ViewBag.Message = "Signup";
            return View();
        }

        [HttpPost, Route("signup")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp");
            }

            var userRepo = base.UnitOfWork.GetRepository<User>();

            user.CreateDate = DateTime.Now;
            userRepo.Add(user);
            base.UnitOfWork.SaveChanges();

            return Redirect("/login");
        }
        [Route("login")]
        public ActionResult Login()
        {
            ViewBag.Message = "Login";
            return View();
        }

        [HttpPost, Route("login")]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            var userRepo = base.UnitOfWork.GetRepository<User>();
            var user = userRepo.GetAll(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();

            if (user != null)
            {
                base.SessionUser = user;
                return RedirectToAction("UserMain", "User");
            }

            else
            {
                ModelState.AddModelError("", "Invalid user name password.");
                return View("Login");
            }
        }

        [Route("TopUserInfo")]
        public ActionResult TopUserInfo()
        {
            return PartialView(base.SessionUser);
        }


    }
};