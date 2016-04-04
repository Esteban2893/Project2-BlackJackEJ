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

        public static bool CrearNuevaCartaBaraja(ApplicationDbContext db, Baraja baraja)
        {
            Random random = new Random();
            var cartas = db.Cartas.ToList();
            var count = 0;
            var lista = DesordenarLista();
            foreach (var carta in cartas)
            {

                var carta_baraja = new CartaBaraja
                {
                    Baraja = baraja,
                    Carta = carta,
                    Posicion = lista[count],
                    Disponible = true
                };
                db.CartaBaraja.Add(carta_baraja);
                db.SaveChanges();
                count++;
            }

            return true;
        }

        public static bool ReordenarCartaBaraja(ApplicationDbContext db, int baraja_id)
        {
            Random random = new Random();
            var carta_baraja = db.CartaBaraja.Where(x => x.Baraja.Id == baraja_id).ToList();
            var count = 0;
            var lista = DesordenarLista();
            foreach (var carta in carta_baraja)
            {
                var edit_carta_baraja = db.CartaBaraja.Find(carta.Id);
                edit_carta_baraja.Posicion = lista[count];
                db.SaveChanges();
                count++;
            }

            return true;
        }

        public static List<int> DesordenarLista()
        {
            List<int> listaNumeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52 };
            List<int> listaDesordenada = new List<int>();

            Random randNum = new Random();
            while (listaNumeros.Count > 0)
            {
                int val = randNum.Next(0, listaNumeros.Count);
                listaDesordenada.Add(listaNumeros[val]);
                listaNumeros.RemoveAt(val);
            }

            return listaDesordenada;
        }

        public static Carta ObtenerCarta(ApplicationDbContext db, int baraja_id)
        {
            // var carta_baraja = db.CartaBaraja.Where(x => x.Baraja.Id == baraja_id && x.Disponible == true).ToList();
            var carta_baraja = db.CartaBaraja.Include("Carta").Include("Baraja").Where(x => x.Baraja.Id == baraja_id && x.Disponible == true).ToList();
            var carta_pocision = carta_baraja.Where(c => c.Disponible == true).OrderBy(x=> x.Posicion);
            var ultima_carta = carta_pocision.ElementAt(carta_baraja.Count - 1);
            RetirarCarta(db, ultima_carta);
            return db.Cartas.Find(ultima_carta.Carta.Id);
        }

        public static void RetirarCarta(ApplicationDbContext db, CartaBaraja carta_baraja)
        {
            var edit_carta_baraja = db.CartaBaraja.Find(carta_baraja.Id);
            edit_carta_baraja.Disponible = false;
            db.SaveChanges();
        }

    }
}