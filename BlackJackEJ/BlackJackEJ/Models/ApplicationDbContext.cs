using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlackJackEJ.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Baraja> Barajas { get; set; }
        public DbSet<CartaBaraja> CartaBaraja { get; set; }
        public DbSet<Historial> Historial { get; set; }

    }
}