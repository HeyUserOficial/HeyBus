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
        public int id_Onibus { get; set; }

        [Display (Name = "Viação"), MaxLength(30), Required]
        public string viacao_Onibus { get; set; }

        [Display (Name = "Categoria"), MaxLength(30), Required]
        public string categoria_Onibus { get; set; }

        [Display (Name = "Bancos")]
        public int assentos_Onibus { get; set; }

        [Display (Name = "Manutenção"), MaxLength(15), Required]
        public string manutencao_Onibus { get; set; }
    }
}