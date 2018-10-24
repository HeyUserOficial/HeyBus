using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Viagem
    {
        [Key]
        private int id_Viagem;
        public int id_Viag
        {
            get { return id_Viagem; }
            set { id_Viagem = id_Viag; }
        }

        [MaxLength(60), Required]
        private string origem_Viagem;
        public string origem_Viag
        {
            get { return origem_Viagem; }
            set { origem_Viagem = origem_Viag; }
        }

        [MaxLength(60), Required]
        private string destino_Viagem;
        public string destino_Viag
        {
            get { return destino_Viagem; }
            set { destino_Viag = destino_Viagem; }
        }

        [MaxLength(30), Required]
        private string viacao_Viagem;
        public string viacao_Viag
        {
            get { return viacao_Viagem; }
            set { viacao_Viag = viacao_Viagem; }
        }

        private DateTime data_Viagem;
        public DateTime data_Viag
        {
            get { return data_Viagem; }
            set { data_Viagem = data_Viag; }
        }

        private double valor_Viagem;
        public double valor_Viag
        {
            get { return valor_Viagem; }
            set { valor_Viagem = valor_Viag; }
        }
    }
}