using MisFinanzas.Helpers;
using MisFinanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class GastoController : Controller
    {
        // GET: Gasto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            if (Session["PersonaId"] != null)
            {
                int idPersona = (int)Session["PersonaId"];
                GastoHelper helper = new GastoHelper();
                List<Gasto> gastos = helper.getByIdPersona(idPersona);
                return View(gastos);
            }
            else {
                return View("Error", Json(new { success = false, message = "Se perdio Session" }, JsonRequestBehavior.AllowGet));
            }
        }

        public ActionResult NewGasto() {
            return PartialView("Gasto"); 
        }

        public ActionResult Save(int idGrupoGasto, DateTime fechaGasto, decimal monto, int idPersona, string Descripcion)
        {
            GastoHelper helper = new GastoHelper();
            helper.saveGasto(idGrupoGasto, fechaGasto, monto, idPersona, Descripcion);
            List<Gasto> gastos = helper.getByIdPersona(idPersona);
            return View(gastos);
        }
    }
}