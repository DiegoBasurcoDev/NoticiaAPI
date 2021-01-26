using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Autor
    {
        [Key]
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}