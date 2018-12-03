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
        
        [Display (Name = "Desconto")]
        public double desconto_Passagem { get; set; }

        [Display(Name = "Valor")]
        public double valor_Passagem;

        [Display(Name = "Desconto"), MaxLength(15)]
        public int forma_Pagamaneto { get; set; }

        [Display (Name = "Data de compra")]
        public DateTime data_Compra { get; set; }

        public Rota rot { get; set; } = new Rota();

        public Viagem viag { get; set; } = new Viagem();

        public Cliente cli { get; set; } = new Cliente();

        public Onibus oni { get; set; } = new Onibus();

        public Assentos assentos { get; set; } = new Assentos();

    }
}