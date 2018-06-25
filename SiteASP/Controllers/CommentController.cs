using SiteASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteASP.Controllers
{
    public class CommentController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CommentController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TopComments()
        {
            var model = _unitOfWork.CommentRepository.GetAll().OrderByDescending(e => e.Id).Take(3);
            return View(model);
        }

        public ActionResult Comments(int id)
        {
            var model = _unitOfWork.CommentRepository.GetAll().Where(e => e.ArticleId == id);
            return View(model);
        }

        public ActionResult AddComment(int id, Article article)
        {
            var model = new Comment()
            {
                Article = article,
                ArticleId = id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            comment.PubDate = DateTime.Now;
            _unitOfWork.CommentRepository.Create(comment);
            _unitOfWork.Save();
            return RedirectToAction("Article", "Home", new { id = comment.ArticleId });
        }
    }
}