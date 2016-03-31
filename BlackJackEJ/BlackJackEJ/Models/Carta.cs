using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackJackEJ.Models
{
    public class Carta
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
        public string Imagen { get; set; }
    }
}