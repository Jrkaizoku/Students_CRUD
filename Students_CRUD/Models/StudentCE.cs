using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students_CRUD.Models
{
    public class StudentCE
    {
    }
    public partial class Student {
        [Display(Name ="Nombre Completo")]
      public string fullName { get { return name + " " + last_name; } }
    }
}