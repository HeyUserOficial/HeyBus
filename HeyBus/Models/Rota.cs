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
        private int id_Rota; 
        public int id_Rot
        {
            get { return id_Rota; }
            set { id_Rota = id_Rot; }
        }

        [MaxLength(60), Required]
        private string origem_Rota;
        public string origem_Rot
        {
            get { return origem_Rota; }
            set { origem_Rota = origem_Rot; }
        }

        [MaxLength(60), Required]
        private string destino_Rota;
        public string destino_Rot
        {
            get { return destino_Rota; }
            set { destino_Rota = destino_Rot; }
        }

        private DateTime intinerario_Rota;
        public DateTime intinerario_Rot
        {
            get { return intinerario_Rota; }
            set { intinerario_Rota = intinerario_Rot; }
        }

        [MaxLength(10), Required]
        private string distancia_Rota;
        public string distancia_Rot
        {
            get { return distancia_Rota; }
            set { distancia_Rota = distancia_Rot; }
        }
    }
}