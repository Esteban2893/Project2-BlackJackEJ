using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackEJ.Models.DTO
{
    public class ReporteGanados
    {
        public int Ganados { get; set; }
        public int Perdidos { get; set; }
        public int Empatados { get; set; }
    }
}