using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisFinanzas.Models
{
    [Table("GrupoGastos")]
    public class GrupoGasto
    {
        [Key]
        public int IdGrupoGasto { get; set; }
        public String Descripcion { get; set; }
        public TipoGasto TipoGasto { get; set; }
    }

    public enum TipoGasto {
        Oligatorio = 1,
        Deseoso = 2,
        Inversion = 3
    }
}