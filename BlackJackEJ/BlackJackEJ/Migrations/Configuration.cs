namespace BlackJackEJ.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlackJackEJ.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlackJackEJ.Models.ApplicationDbContext context)
        {
            context.Cartas.AddOrUpdate(x => x.Id,
             new Carta { Id = 1, Nombre = "AT", Valor = 11, Imagen = "" },
             new Carta { Id = 2, Nombre = "2T", Valor = 2, Imagen = "" },
             new Carta { Id = 3, Nombre = "3T", Valor = 3, Imagen = "" },
             new Carta { Id = 4, Nombre = "4T", Valor = 4, Imagen = "" },
             new Carta { Id = 5, Nombre = "5T", Valor = 5, Imagen = "" },
             new Carta { Id = 6, Nombre = "6T", Valor = 6, Imagen = "" },
             new Carta { Id = 7, Nombre = "7T", Valor = 7, Imagen = "" },
             new Carta { Id = 8, Nombre = "8T", Valor = 8, Imagen = "" },
             new Carta { Id = 9, Nombre = "9T", Valor = 9, Imagen = "" },
             new Carta { Id = 10, Nombre = "10T", Valor = 10, Imagen = "" },
             new Carta { Id = 11, Nombre = "JT", Valor = 10, Imagen = "" },
             new Carta { Id = 12, Nombre = "QT", Valor = 10, Imagen = "" },
             new Carta { Id = 13, Nombre = "KT", Valor = 10, Imagen = "" },
             new Carta { Id = 14, Nombre = "AP", Valor = 11, Imagen = "" },
             new Carta { Id = 15, Nombre = "2P", Valor = 2, Imagen = "" },
             new Carta { Id = 16, Nombre = "3P", Valor = 3, Imagen = "" },
             new Carta { Id = 17, Nombre = "4P", Valor = 4, Imagen = "" },
             new Carta { Id = 18, Nombre = "5P", Valor = 5, Imagen = "" },
             new Carta { Id = 19, Nombre = "6P", Valor = 6, Imagen = "" },
             new Carta { Id = 20, Nombre = "7P", Valor = 7, Imagen = "" },
             new Carta { Id = 21, Nombre = "8P", Valor = 8, Imagen = "" },
             new Carta { Id = 22, Nombre = "9P", Valor = 9, Imagen = "" },
             new Carta { Id = 23, Nombre = "10P", Valor = 10, Imagen = "" },
             new Carta { Id = 24, Nombre = "JP", Valor = 10, Imagen = "" },
             new Carta { Id = 25, Nombre = "QP", Valor = 10, Imagen = "" },
             new Carta { Id = 26, Nombre = "KP", Valor = 10, Imagen = "" },
             new Carta { Id = 27, Nombre = "AC", Valor = 11, Imagen = "" },
             new Carta { Id = 28, Nombre = "2C", Valor = 2, Imagen = "" },
             new Carta { Id = 29, Nombre = "3C", Valor = 3, Imagen = "" },
             new Carta { Id = 30, Nombre = "4C", Valor = 4, Imagen = "" },
             new Carta { Id = 31, Nombre = "5C", Valor = 5, Imagen = "" },
             new Carta { Id = 32, Nombre = "6C", Valor = 6, Imagen = "" },
             new Carta { Id = 33, Nombre = "7C", Valor = 7, Imagen = "" },
             new Carta { Id = 34, Nombre = "8C", Valor = 8, Imagen = "" },
             new Carta { Id = 35, Nombre = "9C", Valor = 9, Imagen = "" },
             new Carta { Id = 36, Nombre = "10C", Valor = 10, Imagen = "" },
             new Carta { Id = 37, Nombre = "JC", Valor = 10, Imagen = "" },
             new Carta { Id = 38, Nombre = "QC", Valor = 10, Imagen = "" },
             new Carta { Id = 39, Nombre = "KC", Valor = 10, Imagen = "" },
             new Carta { Id = 40, Nombre = "AD", Valor = 11, Imagen = "" },
             new Carta { Id = 41, Nombre = "2D", Valor = 2, Imagen = "" },
             new Carta { Id = 42, Nombre = "3D", Valor = 3, Imagen = "" },
             new Carta { Id = 43, Nombre = "4D", Valor = 4, Imagen = "" },
             new Carta { Id = 44, Nombre = "5D", Valor = 5, Imagen = "" },
             new Carta { Id = 45, Nombre = "6D", Valor = 6, Imagen = "" },
             new Carta { Id = 46, Nombre = "7D", Valor = 7, Imagen = "" },
             new Carta { Id = 47, Nombre = "8D", Valor = 8, Imagen = "" },
             new Carta { Id = 48, Nombre = "9D", Valor = 9, Imagen = "" },
             new Carta { Id = 49, Nombre = "10D", Valor = 10, Imagen = "" },
             new Carta { Id = 50, Nombre = "JD", Valor = 10, Imagen = "" },
             new Carta { Id = 51, Nombre = "QD", Valor = 10, Imagen = "" },
             new Carta { Id = 52, Nombre = "KD", Valor = 10, Imagen = "" }
            );
        }
    }
}
