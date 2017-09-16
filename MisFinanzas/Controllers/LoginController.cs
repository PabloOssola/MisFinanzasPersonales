using MisFinanzas.Helpers;
using MisFinanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisFinanzas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Persona p)
        {
            try
            {
                PersonaHelper helper = new PersonaHelper();
                helper.validarPersona(p.UserName, p.Password);
                return RedirectToAction("Logueado", "Home");
            }
            catch (Exception e)
            {
                return View("Error", Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password, bool? remember)
        {
            try
            {
                PersonaHelper helper = new PersonaHelper();
                Persona p = helper.validarPersona(username, password);
                Session["PersonaId"] = p.IdPersona;
                return RedirectToAction("Logueado", "Home", p);
            }
            catch (Exception e)
            {
                return View("Error", Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public ActionResult Registrarme(string username, string email, string password)
        {
            PersonaHelper helper = new PersonaHelper();
            try
            {
                Persona per = helper.addPersona(username, email, password, 1);
                return View("Success", per);
            }
            catch (Exception e)
            {
                return View("Error", Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet));
            }
        }
        
    }
}