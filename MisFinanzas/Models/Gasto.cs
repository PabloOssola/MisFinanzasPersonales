using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisFinanzas.Models
{
    [Table("Gastos")]
    public class Gasto
    {
        [Key]
        public int IdGasto { get; set; }
        public String Descripcion { get; set; }
        public Decimal monto { get; set; }
        public int IdGrupoGasto { get; set; }
        [ForeignKey("IdGrupoGasto")]
        public GrupoGasto GrupoGasto { get; set; }
        public DateTime FechaGasto { get; set; }
        public int IdPersona { get; set; }
        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }
    }
}