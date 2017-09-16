using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisFinanzas.Models
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int IdGrupo { get; set; }
    }
}