using MisFinanzas.Models;
using System.Data.Entity;

namespace MisFinanzas.Context
{
    public class FinanzasContext : DbContext
    {
        public FinanzasContext()
            : base("name=FinanzasContext")
        {
        }

        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<GrupoGasto> GrupoGastos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Porcentaje> Porcentajes { get; set; }
    }
 
}