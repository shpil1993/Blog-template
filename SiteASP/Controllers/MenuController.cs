using SiteASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteASP.Controllers
{
    public class MenuController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public MenuController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: Menu
        public ActionResult Index()
        {
            var model = _unitOfWork.CategoryRepository.GetAll();
            return View(model);
        }
    }
}