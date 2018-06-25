using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteASP.Controllers
{
    using Models;
    using SiteASP.Models.Paginator;

    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Article> articlesPerPage = _unitOfWork.ArticleRepository.GetAll().Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo() { PageNumber = page, PageSize = pageSize, TotalItems = _unitOfWork.ArticleRepository.GetAll().Count() };
            IndexViewModel model = new IndexViewModel() { PageInfo = pageInfo, Articles = articlesPerPage };
            return View(model);
        }

        public ActionResult Articles(int id, int page = 1)
        {
            int pageSize = 4;
            IEnumerable<Article> articlesPerPage = _unitOfWork.ArticleRepository.GetAll().Where(e => e.CategoryId == id).Skip((page - 1) * pageSize).Take(pageSize);
            if (articlesPerPage.Count() <= 0)
            {
                return HttpNotFound();
            }
            PageInfo pageInfo = new PageInfo() { PageNumber = page, PageSize = pageSize, TotalItems = articlesPerPage.Count() };
            IndexViewModel model = new IndexViewModel() { PageInfo = pageInfo, Articles = articlesPerPage };
            return View("Index", model);
        }

        public ActionResult Article(int id)
        {
            List<Article> model = new List<Article>();
            Article m = _unitOfWork.ArticleRepository.Get(id);
            if (m != null)
            {
                model.Add(m);
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult TopArticles()
        {
            var model = _unitOfWork.ArticleRepository.GetAll().OrderByDescending(e => e.Id).Take(3);
            return View(model);
        }

        public ActionResult AboutMe()
        {
            return View();
        }

        public ActionResult CopyRight()
        {
            return View();
        }
    }
}