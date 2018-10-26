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
        public int id_Passagem { get; set; }

        [Display (Name = "CPF"), MaxLength(14)]
        public string cpf_Cliente { get; set; }

        [Display(Name = "Origem"), MaxLength(60)]
        public string origem_Passagem { get; set; }

        [Display(Name = "Destino"), MaxLength(60)]
        public string destino_Passagem { get; set; }

        [Display(Name = "Viação"), MaxLength(30)]
        public string viacao_Onibus { get; set; }

        [Display (Name = "Desconto")]
        public double desconto_Passagem { get; set; }

        [Display(Name = "Valor")]
        public double valor_Passagem;

        [Display(Name = "Desconto"), MaxLength(15)]
        public string forma_Pagamaneto { get; set; }

        [Display (Name = "Data de compra")]
        public DateTime data_Compra { get; set; }
        public int id_Cliente { get; set; }
    }
}