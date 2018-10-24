using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Passagem
    {
        [Key]
        private int id_Passagem;
        public int id_Passag
        {
            get { return id_Passagem; }
            set { id_Passagem = id_Passag; }
        }

        [MaxLength(14), Required]
        private string cpf_Cliente;
        public string cpf_Cli
        {
            get { return cpf_Cliente; }
            set { cpf_Cliente = cpf_Cli; }
        }

        private string origem_Rota;
        public string origem_Rot
        {
            get { return origem_Rota; }
            set { origem_Rota = origem_Rot; }
        }

        private string destino_Rota;
        public string destino_Rot
        {
            get { return destino_Rota; }
            set { destino_Rota = destino_Rot; }
        }

        private string viacao_Viagem;
        public string viacao_Viag
        {
            get { return viacao_Viagem; }
            set { viacao_Viagem = viacao_Viag; }
        }

        private double desconto_Passagem;
        public double desconto_Passag
        {
            get { return desconto_Passagem; }
            set { desconto_Passagem = desconto_Passag; }
        }

        private double valor_Passagem;
        public double valor_Passag
        {
            get { return valor_Passagem; }
            set { valor_Passag = valor_Passag; }
        }

        private string forma_Pagamaneto;
        public string from_Pag
        {
            get { return forma_Pagamaneto; }
            set { forma_Pagamaneto = from_Pag; }
        }
    }
}