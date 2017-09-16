using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisFinanzas.Models
{
    [Table("Porcentaje")]
    public class Porcentaje
    {
        [Key] 
        public int IdPorcentaje { get; set; }
        public int Obligatorio { get; set; }
        public int Deseoso { get; set; }
        public int Inversion { get; set; }
    }
}