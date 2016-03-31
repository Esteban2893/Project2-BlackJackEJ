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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Baraja
        public IHttpActionResult Post([FromBody]string value)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var baraja = this.CrearNuevaBaraja(db);
            return Ok(baraja);
        }

        // PUT: api/Baraja/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Baraja/5
        public void Delete(int id)
        {
        }

        public Baraja CrearNuevaBaraja(ApplicationDbContext db)
        {
            var baraja = new Baraja { };
            db.Barajas.Add(baraja);
            db.SaveChanges();
            return baraja;
        }
     }
}
