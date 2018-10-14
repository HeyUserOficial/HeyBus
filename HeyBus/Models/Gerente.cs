using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Gerente
    {
        [Display(Name = "Código do gerente"), Key]
        public int id_Gerente {get; set;}

        [Display(Name = "CPF do gerente"), MaxLength(14), Required]
        public string cpf_Gerente { get; set; }

        [Display(Name = "Nome do gerente"), MaxLength(70), Required]
        public string nome_Gerente { get; set; }
    }
}