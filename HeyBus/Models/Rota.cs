using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Models
{
    public class Rota
    {
        [Key]
        public int id_Rota { get; set; }

        [Display (Name = "Origem"), MaxLength(60), Required]
        public string origem_Rota { get; set; }

        [Display (Name = "Destino"), MaxLength(60), Required]
        public string destino_Rota { get; set; }

        [Display (Name = "Distância"), MaxLength(10), Required]
        public string distancia_Rota { get; set; }

        public IEnumerable<SelectListItem> PuxarRota { get; set; }

        public IEnumerable<SelectListItem> PuxarOrigem { get; set; }
    }
}