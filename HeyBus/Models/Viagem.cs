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

        [Display (Name = "Data da viagem")]
        public DateTime data_Viagem { get; set; }

        [Display (Name = "Valor")]
        public double valor_Viagem { get; set; }

        public Rota rot { get; set; }

        public Onibus oni { get; set; }
    }
}