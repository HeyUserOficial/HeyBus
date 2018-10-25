using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        [Display (Name = "Itinerário")]
        public DateTime itinerario_Rota { get; set; }

        [Display (Name = "Distância"), MaxLength(10), Required]
        public string distancia_Rota { get; set; }
    }
}