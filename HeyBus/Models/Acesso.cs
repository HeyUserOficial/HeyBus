using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Acesso
    {
        [Display (Name= "Código do login"), Key]
        public int id_Acesso { get; set; }
    }
}