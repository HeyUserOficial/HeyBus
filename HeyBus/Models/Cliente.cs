using HeyBus.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Cliente
    {
        [Display (Name ="Código do cliente"), Key]
        public int id_Cliente { get; set; }

        [Display (Name ="CPF do cliente"), MaxLength(14), Required]
        public char cpf_Cliente { get; set; }

        [Display (Name ="Nome do cliente"), MaxLength(70), Required]
        public string nome_Cliente { get; set; }

        [Display (Name ="Data de nascimento"), BirthDay(14), DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime nascimento_Cliente { get; set; }

        [Display (Name ="Telefone do cliente"), MaxLength(20), Required]
        public char tel_Cliente { get; set; }

        [Display (Name ="Celular do cliente"), MaxLength(20), Required]
        public char cel_Cliente { get; set; }
        
        [Display (Name ="E-mail do cliente"), MaxLength(60), Required]
        public string email_Cliente { get; set; }

        [Display (Name ="Nome do usuário"), MaxLength(25), Required]
        public string usuario_Acesso { get; set; }

        [Display (Name ="Senha do usuário"), MaxLength(25), Required]
        public string senha_Acesso { get; set; }
    }
}