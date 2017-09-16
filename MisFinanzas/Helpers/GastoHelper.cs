using MisFinanzas.Context;
using MisFinanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisFinanzas.Helpers
{
    public class GastoHelper
    {
        public GastoHelper() { }

        public Porcentaje getPorcentaje()
        {
            Porcentaje porcentaje = new Porcentaje();
            using (var db = new FinanzasContext())
            {
                porcentaje = (from p in db.Porcentajes select p).FirstOrDefault();
            }
            return porcentaje;
        }

        public void addPorcentaje(int obligatorio, int deseoso, int inversion)
        {
            using (var db = new FinanzasContext())
            {
                Porcentaje porcentaje = new Porcentaje();
                porcentaje.Obligatorio = obligatorio;
                porcentaje.Deseoso = deseoso;
                porcentaje.Inversion = inversion; 
                db.Porcentajes.Add(porcentaje);
                db.SaveChanges();
            }
        }

        public void updatePorcentaje(int obligatorio, int deseoso, int inversion)
        {
            using (var db = new FinanzasContext())
            {
                Porcentaje porcentaje = db.Porcentajes.FirstOrDefault();
                porcentaje.Obligatorio = obligatorio;
                porcentaje.Deseoso = deseoso;
                porcentaje.Inversion = inversion; 
                db.SaveChanges();
            }
        }


        //public Gasto addGasto(string username, string email, string password, int idGrupo)
        //{ 
        //    Persona newPerson = new Persona();
        //    newPerson.UserName = username;
        //    newPerson.Email = email;
        //    newPerson.Password = password;
        //    newPerson.IdGrupo = idGrupo;

        //    Persona p = this.getByEmail(email);
        //    if (p == null)
        //    {
        //        using (var db = new FinanzasContext())
        //        {
        //            db.Personas.Add(newPerson);
        //            db.SaveChanges();
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("El Nombre del usuario ya existe");
        //    }
        //    return newPerson; 
        //}

        public List<Gasto> getByIdPersona(int id)
        {
            List<Gasto> gastos = new List<Gasto>();
            using (var db = new FinanzasContext())
            {
                gastos = (from g in db.Gastos where g.IdPersona == id select g).ToList();
            }
            return gastos;
        }

        public void saveGasto(int idGrupoGasto, DateTime fechaGasto, decimal monto, int idPersona, string descripcion)
        {
            Gasto gasto = new Gasto();
            gasto.Descripcion = descripcion;
            gasto.FechaGasto = fechaGasto;
            gasto.monto = monto;
            gasto.Persona = new PersonaHelper().getById(idPersona);
            gasto.GrupoGasto = new GrupoGastoHelper().getById(idGrupoGasto);
            using (var db = new FinanzasContext())
            {
                db.Gastos.Add(gasto);
                db.SaveChanges();
            }
        }

        public void removeGasto(int id)
        {
            using (var db = new FinanzasContext())
            {
                var gasto = db.Gastos.Find(id);
                if (gasto != null)
                {
                    db.Gastos.Remove(gasto);
                    db.SaveChanges();
                }
            }
        }

        public void updateGasto(int id, String description, DateTime fecha, decimal monto)
        {
            using (var db = new FinanzasContext())
            {
                var gasto = db.Gastos.Find(id);
                if (gasto != null)
                {
                    gasto.monto = monto;
                    gasto.FechaGasto = fecha;
                    gasto.Descripcion = description;
                    db.SaveChanges();
                }
            }
        }
    }
}