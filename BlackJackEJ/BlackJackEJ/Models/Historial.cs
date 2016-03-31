using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackJackEJ.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }
        public int Estado { get; set; }
    }
}