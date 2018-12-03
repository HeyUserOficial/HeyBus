using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Funcionario : Acesso
    {
        [Key]
        public int id_Funcionario { get; set; }

        [Display(Name = "CPF"), MaxLength(14), Required]
        public string cpf_Funcionario { get; set; }

        [Display(Name = "Nome"), MaxLength(70), Required]
        public string nome_Funcionario { get; set; }

        [Display(Name = "E-mail"), MaxLength(60), Required]
        public string email_Funcionario { get; set; }

        [Display(Name = "Endereço"), MaxLength(100), Required]
        public string endereco_Funcionario { get; set; }

        [Display(Name = "Login"), MaxLength(100), Required]
        public string login_Funcionario { get; set; }
    }
}