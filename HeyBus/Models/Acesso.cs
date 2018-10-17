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

        [MaxLength(25), Required]
        private string login_Acesso;
        public string login_Ac
        {
            get { return login_Acesso; }
            set { login_Acesso = login_Ac; }
        }

        [MaxLength(25), Required] 
        private string password_Acesso;
        public string password_Ac
        {
            get { return password_Acesso; }
            set { password_Acesso = password_Ac; }
        }

        public static string nivel_Acesso;
    }
}