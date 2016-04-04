using BlackJackEJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BlackJackEJ.Controllers
{
    public class BarajaController : ApiController
    {
        // GET: api/Baraja
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Baraja/5
        public IHttpActionResult Get(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var carta = CartaBaraja.ObtenerCarta(db, id);
            return Ok(carta);
        }

        // POST: api/Baraja
        public IHttpActionResult Post([FromBody]string value)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var baraja = Baraja.CrearNuevaBaraja(db);
            CartaBaraja.CrearNuevaCartaBaraja(db, baraja);
            return Ok(baraja);
        }

        // PUT: api/Baraja/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            CartaBaraja.ReordenarCartaBaraja(db, id);
            return Ok("Reordenado");
        }

        // DELETE: api/Baraja/5
        public void Delete(int id)
        {
        }

     }
}
