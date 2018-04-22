using CommentLog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using CommentLog.Process;
using CommentLog.Utility;
using static CommentLog.Web.App_Start.FilterConfig;

namespace CommentLog.Web.Controllers
{

    
    public class CommentController : Controller
    {
        private ICommentProcess _commentProcess = null;
        public CommentController(ICommentProcess commentProcess)
        {
            _commentProcess = commentProcess;
        }
        // GET: Comment        
        public ActionResult Index()
        {
            //var claims = User.Identity.GetUserId();
            //var claims2 = User.Identity.GetUserName();
            //var _identity = User.Identity as ClaimsIdentity;
            //var email = _identity.FindFirstValue(ClaimTypes.Email);
            //var userid = _identity.FindFirstValue(ClaimTypes.NameIdentifier);
            var comments = _commentProcess.GetAll().ToViewModel();
            return View(comments);
        }

        [HttpPost]
        public PartialViewResult AddComment(CommentsVM comment)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }

            comment.CommentMsg = Server.HtmlEncode(comment.CommentMsg);
            comment.UserId = Convert.ToInt32(User.Identity.GetUserId());
            comment.CommentDate = DateTime.Now;
            
            _commentProcess.AddComment(comment.ToDTO());

            return PartialView("/Views/Shared/_Comment.cshtml", comment);
        }

        [HttpPost]
        public PartialViewResult SearchComment(string searchTerm)
        {     
            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                return null;
            }
            List<CommentsVM> comments = _commentProcess.Search(searchTerm, Convert.ToInt32(User.Identity.GetUserId())).ToViewModel();

            return PartialView("/Views/Shared/_Comments.cshtml", comments);
        }
    }
}