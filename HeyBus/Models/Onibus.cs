using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeyBus.Models
{
    public class Onibus
    {
        [Key]
        private int id_Onibus;
        public int id_Oni
        {
            get { return id_Onibus; }
            set { id_Onibus = id_Oni; }
        }

        [MaxLength(30), Required]
        private string viacao_Onibus;
        public string viacao_Oni
        {
            get { return viacao_Onibus; }
            set { viacao_Onibus = viacao_Oni; }
        }

        [MaxLength(30), Required]
        private string categoria_Onibus;
        public string categoria_Oni
        {
            get { return categoria_Onibus; }
            set { categoria_Onibus = categoria_Oni; }
        }

        
        private List<int> assentos_Onibus;
        public List<int> assentos_Oni
        {
            get { return assentos_Onibus; }
            set { assentos_Onibus = assentos_Oni; }
        }

        private string manutencao_Onibus;
        public string manutencao_Oni
        {
            get { return manutencao_Onibus; }
            set { manutencao_Onibus = manutencao_Oni; }
        }
    }
}