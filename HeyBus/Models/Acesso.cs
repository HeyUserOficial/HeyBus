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

        [Display(Name = "Nome do usuário"), MaxLength(25), Required]
        public string usuario_Acesso { get; set; }

        [Display(Name = "Senha do usuário"), MaxLength(25), Required]
        public string senha_Acesso { get; set; }

        public string nivel_Acesso { get; set; }
    }
}