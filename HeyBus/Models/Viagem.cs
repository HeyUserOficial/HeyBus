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
        public int id_Viagem { get; set; }

        [Display (Name = "Origem"), MaxLength(60), Required]
        public string origem_Viagem { get; set; }

        [Display (Name = "Destino"), MaxLength(60), Required]
        private string destino_Viagem;

        [Display (Name = "Viãção"), MaxLength(30), Required]
        public string viacao_Viagem  {get; set; }

        [Display (Name = "Data da viagem")]
        public DateTime data_Viagem { get; set; }

        [Display (Name = "Valor")]
        public double valor_Viagem { get; set; }

        public int id_Rota { get; set; }

        public int id_Onibus { get; set; }
    }
}