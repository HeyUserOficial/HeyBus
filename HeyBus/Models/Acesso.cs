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
        public int id_Acesso;

        [Display (Name = "Usuário"), MaxLength(25)]
        public string login_Acesso { get; set; }
        
        [Display (Name = "Senha"), MaxLength(25)] 
        [DataType(DataType.Password)]
        public string password_Acesso { get; set; } 
    }
}