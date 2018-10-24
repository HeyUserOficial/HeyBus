using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Acesso
    {
        [Key]
        public static int id_Acesso;

        [MaxLength(25), Required]
        public static string usuario_Acesso;

        [MaxLength(25), Required]
        public static string senha_Acesso;

        [Display (Name = "Usuário"), MaxLength(25), Required]
        public string login_Acesso { get; set; }
        
        [Display (Name = "Senha"), MaxLength(25), Required] 
        public string password_Acesso { get; set; } 

        public static string nivel_Acesso;
    }
}