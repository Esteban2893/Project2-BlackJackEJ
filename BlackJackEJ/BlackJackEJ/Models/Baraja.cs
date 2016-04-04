using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlackJackEJ.Models
{
    public class Baraja
    {
        [Key]
        public int Id { get; set; }

        public static Baraja CrearNuevaBaraja(ApplicationDbContext db)
        {
            var baraja = new Baraja { };
            db.Barajas.Add(baraja);
            db.SaveChanges();
            return baraja;
        }
    }
}