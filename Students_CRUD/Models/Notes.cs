
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

    public partial class Notes
{

        public int id { get; set; }
       
        public int id_student { get; set; }
      
        public int id_subject { get; set; }
        [DisplayName("Examen 1")]
        [Required]
        [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public Nullable<int> exam1 { get; set; }
        [DisplayName("Tarea")]
        [Required]
        [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public Nullable<int> homework { get; set; }
        [DisplayName("Examen 2")]
        [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required]
        public Nullable<int> exam2 { get; set; }
        [DisplayName("Promedio")]
     
        public Nullable<double> avg { get; set; }


      
        public virtual Student Student { get; set; }

       
        public virtual Subject Subject { get; set; }

}

}