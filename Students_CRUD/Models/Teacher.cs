//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Students_CRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Teacher
    {

        public int id { get; set; }
        [DisplayName("Nombre")]
        [Required]
        [MaxLength(length: 50)]
        public string name { get; set; }

        [DisplayName("Apellido")]
        [Required]
        [MaxLength(length: 50)]
        public string last_name { get; set; }
        [DisplayName("Correo")]
        [Required]
        public string email { get; set; }
        [DisplayName("Telefono")]
        public string phone { get; set; }
    }
}
