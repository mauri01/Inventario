using INVENTARIO.ENTITY;
using INVENTARIO.WEB.Models;
using SGITO_OBRAS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INVENTARIO.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        IUnitOfWork unitOfWork;

        public UsuarioController() : this(new UnitOfWork()) { }

        public UsuarioController(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        // GET: Usuario
        public ActionResult Index()
        {

            //var existe = unitOfWork.UsuarioRepository.Find(x => x.nombre == "gime");
            return View();
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            var allUsuario = unitOfWork.UsuarioRepository.All().ToList();
            var filteredUsuario = allUsuario;
         
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredUsuario = allUsuario.Where(c => c.nombre.ToUpper().Contains(param.sSearch.ToUpper()) || c.apellido.ToUpper().Contains(param.sSearch.ToUpper()) || c.direccion.ToUpper().Contains(param.sSearch.ToUpper()) || c.email.ToUpper().Contains(param.sSearch.ToUpper())).ToList();
            }
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Usuario, string> orderingStringFunction = null;
            Func<Usuario, int> orderingIntFunction = null;

            switch (sortColumnIndex)
            {
                case 1:
                    orderingStringFunction = (c => c.nombre);
                    break;
                case 2:
                    orderingStringFunction = (c => c.apellido);
                    break;
                case 3:
                    orderingStringFunction = (c => c.direccion);
                    break;
                case 4:
                    orderingIntFunction = (c => c.telefono);
                    break;
                case 5:
                    orderingIntFunction = (c => c.perfilId);
                    break;
            }
            var sortDirection = Request["sSortDir_0"];
            if (sortDirection == "asc")
            {
                filteredUsuario = filteredUsuario.OrderBy(orderingStringFunction).ToList();
            }
            else
            {
                filteredUsuario = filteredUsuario.OrderByDescending(orderingStringFunction).ToList();
            }

            var displayedUsuarios = filteredUsuario.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            var result = from c in displayedUsuarios
                         select new[] { c.usuarioId.ToString(), c.nombre, c.apellido.ToUpper(), c.direccion, c.telefono.ToString(),c.perfilId.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allUsuario.Count(),
                iTotalDisplayRecords = filteredUsuario.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }
        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            //ViewData["perfilId"] = desplegable.desplegablePerfiles();
            //ViewData["tipoDocumento"] = desplegable.desplegableDNI();
            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
