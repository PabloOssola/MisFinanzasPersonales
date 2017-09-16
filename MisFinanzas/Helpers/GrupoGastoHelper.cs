using MisFinanzas.Context;
using MisFinanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MisFinanzas.Helpers
{
    public class GrupoGastoHelper
    {
        public GrupoGastoHelper() {
        }

        public void saveGrupoGasto(int idtipoGrupo, String descripcion)
        {
            GrupoGasto categoria = new GrupoGasto();
            categoria.Descripcion = descripcion;
            categoria.TipoGasto = (TipoGasto)idtipoGrupo;
            using (var db = new FinanzasContext())
            {
                db.GrupoGastos.Add(categoria);
                db.SaveChanges();
            }
        }

        public GrupoGasto getById(int id) {
            GrupoGasto grupo = new GrupoGasto();
            using (var db = new FinanzasContext()) {
                grupo = db.GrupoGastos.Find(id);                
            }
            return grupo;
        }

        public List<GrupoGasto> getAll() {
            List<GrupoGasto> grupoGastos = new List<GrupoGasto>();
            using (var db = new FinanzasContext()) {
                grupoGastos = db.GrupoGastos.ToList();
            }
            return grupoGastos;
        }


        public void removeGrupoGasto(int id) {
            using (var db = new FinanzasContext())
            {
                var grupoGasto = db.GrupoGastos.Find(id);
                if (grupoGasto != null)
                {
                    db.GrupoGastos.Remove(grupoGasto);
                    db.SaveChanges();
                }
            }
        }

        public void updateGrupo(int id, String description) {
            using (var db = new FinanzasContext())
            {
                var grupo = db.Grupos.Find(id);
                if (grupo != null) {
                    grupo.Descripion = description;
                    db.SaveChanges();
                }
            }
        }
    }
}