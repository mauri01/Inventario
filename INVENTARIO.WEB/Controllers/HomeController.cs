using INVENTARIO.ENTITY;
using INVENTARIO.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INVENTARIO.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;

        public HomeController() : this(new UnitOfWork()) { }

        public ActionResult Index()
        {
            Index obj = new Index();

            obj.tipo = "notebook";
            obj.marca = "dell";

            return View();
        }

        public HomeController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var existe = unitOfWork.UsuarioRepository.All().ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       


    }
}