using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Funcionario
    {
        [Display (Name= "Código do funcionário" ), Key]
        public int id_Funcionario { get; set; }
        
        [Display (Name = "CPF do funcionário"), MaxLength(14), Required]
        public string cpf_Funcionario { get; set; }

        [Display(Name = "Nome do funcionário"), MaxLength(70), Required]
        public string nome_Funcionario { get; set; }

        [Display (Name = "E-mail do funcionário"), MaxLength(60), Required]
        public string email_Funcionario { get; set; }

        [Display (Name = "Endereço do funcionário"), MaxLength(100), Required]
        public string endereco_Funcionario { get; set; }
    }
}