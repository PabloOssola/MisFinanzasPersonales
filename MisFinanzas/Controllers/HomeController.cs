using MisFinanzas.Helpers;
using MisFinanzas.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GastoHelper helper = new GastoHelper();
            List<Gasto> gastos = helper.getByIdPersona((int)Session["PersonaId"]);
            return View("Principal", gastos);
        }

        public ActionResult Logueado(Persona p)
        {
            GastoHelper helper = new GastoHelper();
            List<Gasto> gastos = helper.getByIdPersona(p.IdPersona);
            return View("Principal", gastos);
        }

        public ActionResult SetearPorcentajes()
        {
            GastoHelper helper = new GastoHelper();
            Porcentaje porcentaje = helper.getPorcentaje();
            return PartialView("Porcentajes", porcentaje);
        }

        public ActionResult Save(int Obligatorio, int Deseoso, int inversion)
        {
            GastoHelper helper = new GastoHelper();
            if(Obligatorio + Deseoso + inversion == 100)
            {
                Porcentaje porcentaje = helper.getPorcentaje();
                if (porcentaje == null)
                    helper.addPorcentaje(Obligatorio, Deseoso, inversion);
                else
                    helper.updatePorcentaje( Obligatorio, Deseoso, inversion);
            }                
            List<Gasto> gastos = helper.getByIdPersona((int)Session["PersonaId"]);
            return View("Principal", gastos);
        }


    }
}
