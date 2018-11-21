using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Assentos
    {
        [Display(Name="Escolha seu banco")]
        [Range(1, 50)]
        public int banco { get; set; }

        public int[] bancos { get; set; }

        public double[] bancosValor { get; set; }
    }
}