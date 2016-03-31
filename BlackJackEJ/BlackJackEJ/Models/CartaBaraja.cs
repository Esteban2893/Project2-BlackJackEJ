using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackJackEJ.Models
{
    public class CartaBaraja
    {
        [Key]
        public int Id { get; set; }
        public Carta Carta { get; set; }
        public Baraja Baraja { get; set; }
        public int Posicion { get; set; }
        public bool Disponible { get; set; }

    }
}