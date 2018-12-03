using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Models
{
    public class Assentos
    {
        [Display(Name = "Escolha seu banco")]
        [Range(1, 50)]
        public int banco { get; set; }

        public int id_Bancos { get; set; }

        public List<int> listaBancos {get;set;}

        public double[] bancosValor { get; set; }
    }
}