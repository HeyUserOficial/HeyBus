using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Acesso : Passagem
    {
        [Key]
        public static int id_Acesso;

        [Display (Name = "Usuário"), MaxLength(25)]
        public string login_Acesso { get; set; }
        
        [Display (Name = "Senha"), MaxLength(25)] 
        public string password_Acesso { get; set; } 

        public static string nivel_Acesso;

        [Display (Name = "Nível de acesso"), MaxLength(15)]
        public string level_Acesso;
    }
}