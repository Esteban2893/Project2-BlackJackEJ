using BlackJackEJ.Models;
using BlackJackEJ.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlackJackEJ.Controllers
{
    public class JuegoController : ApiController
    {
        // GET: api/Juego
        public IHttpActionResult Get()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ganados = db.Historial.Where(x => x.Estado == 1).Count();
            var perdidos = db.Historial.Where(x => x.Estado == 2).Count();
            var empatados = db.Historial.Where(x => x.Estado == 3).Count();
            var reporte = new ReporteGanados {
                Ganados = ganados,
                Perdidos = perdidos,
                Empatados = empatados
            };

            return Ok(reporte);
        }

        // GET: api/Juego/5
        [Route("api/juego/{player}/{dealer}")]
        public IHttpActionResult Get(int player, int dealer)
        {
            //1= jugador 2= dealer 3= empate 4=sigue jugando
            var puntos_jugador = player;
            var puntos_dealer = dealer;
            if (puntos_jugador == 21 && puntos_dealer != 21)
            {
                return Ok(1);
            }
            else if (puntos_jugador != 21 && puntos_dealer == 21)
            {
                return Ok(2);
            }
            else if (puntos_jugador == 21 && puntos_dealer == 21)
            {
                return Ok(3);
            }
            else if (puntos_jugador <= 21 && puntos_dealer > 21)
            {
                return Ok(1);
            }
            else if (puntos_jugador > 21 && puntos_dealer <= 21)
            {
                return Ok(2);
            }
            else if (puntos_jugador < 21 && puntos_dealer == 21)
            {
                return Ok(2);
            }
            else if (puntos_jugador == 21 && puntos_dealer < 21)
            {
                return Ok(1);
            }
            else
            {
                return Ok(4);
            }
        }

        // POST: api/Juego
        public IHttpActionResult Post([FromBody]int ganador)
        {
            return null;
        }

        // PUT: api/Juego/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var historial = new Historial
            {
                Estado = id
            };
            db.Historial.Add(historial);
            db.SaveChanges();
            return Ok(historial);
        }

        // DELETE: api/Juego/5
        public void Delete(int id)
        {
        }
    }
}
