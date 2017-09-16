using MisFinanzas.Context;
using MisFinanzas.Models;
using System; 

namespace MisFinanzas.Helpers
{
    public class GrupoHelper
    {
        public GrupoHelper() {
        }

        public void addGrupo(String descripcion) {
            Grupo grupo = new Grupo();
            grupo.Descripion = descripcion;
            using (var db = new FinanzasContext())
            {
                db.Grupos.Add(grupo);
                db.SaveChanges();
            }
        }

        public Grupo getById(int id) {
            Grupo grupo = new Grupo();
            using (var db = new FinanzasContext()) {
                grupo = db.Grupos.Find(id);                
            }
            return grupo;
        }

        public void removeGrupo(int id) {
            using (var db = new FinanzasContext())
            {
                var grupo = db.Grupos.Find(id);
                if (grupo != null)
                {
                    db.Grupos.Remove(grupo);
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