using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MisFinanzas.Models
{
    [Table("Grupos")]
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }
        public String Descripion { get; set; }

    }
}