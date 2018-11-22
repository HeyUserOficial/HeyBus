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

        [Display(Name = "Data da Partida")]
        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime data_Ida { get; set; }

        [Display(Name = "Data da Volta")]
        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime data_Volta { get; set; }

        [Display(Name = "Horario da partida")]
        [DataType(DataType.Time),
        DisplayFormat(DataFormatString = "00:00", ApplyFormatInEditMode = true)]
        public DateTime horario_Viagem { get; set; }

        [Display (Name = "Valor da passagem")]
        public double valor_Viagem { get; set; }

        public Rota rot { get; set; } = new Rota();

        public Onibus oni { get; set; } = new Onibus();

        public Assentos assentos { get; set; } = new Assentos();
    }
}