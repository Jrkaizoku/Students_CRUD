
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
    using System.ComponentModel.DataAnnotations;

    public partial class Teacher
{
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string last_name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }

}

}
