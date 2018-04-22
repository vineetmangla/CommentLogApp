using CommentLog.Process;
using CommentLog.Utility;
using CommentLog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Owin;

namespace CommentLog.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IUserProcess _userProcess;
        public AuthController(IUserProcess userProcess)
        {
            this._userProcess = userProcess;
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsersVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = _userProcess.GetUserByLoginName(model.Email);
            if(user!=null && model.Password==user.Password)
            {
                var identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                   new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Email,user.Email)
                    
               },
                   "ApplicationCookie"
                    );

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);
                return RedirectToAction("index", "comment");
            }
            ModelState.AddModelError("", "Email or password is incorrect");
            return View(model);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("login");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UsersVM model)
        {
            if (ModelState.IsValid)
            {
                _userProcess.Add(model.ToDTO());
            }
            return View();
        }
    }
}