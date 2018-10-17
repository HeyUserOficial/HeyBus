using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Funcionario
    {
        [Key]
        private int id_Funcionario;
        public int id_Func
        {
            get { return id_Funcionario; }
            set { id_Funcionario = id_Func; }
        }

        [MaxLength(14), Required]
        private string cpf_Funcionario;
        public string cpf_Func
        {
            get { return cpf_Funcionario; }
            set { cpf_Funcionario = cpf_Func; }
        }

        [MaxLength(70), Required]
        private string nome_Funcionario;
        public string nome_Func
        {
            get { return nome_Funcionario; }
            set { nome_Funcionario = nome_Func; } 
        }

        [MaxLength(60), Required]
        private string email_Funcionario;
        public string email_Func
        {
            get { return email_Funcionario; }
            set { email_Funcionario = email_Func; }
        }
        

        [MaxLength(100), Required]
        private string endereco_Funcionario;
        public string endereco_Func
        {
            get { return endereco_Funcionario; }
            set { endereco_Funcionario = endereco_Func; }
        }


        private int id_Acesso;
        public int id_Ac
        {
            get { return id_Acesso; }
            set { id_Acesso = id_Ac; }
        }
    }
}