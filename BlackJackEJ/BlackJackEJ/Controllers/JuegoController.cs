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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Juego/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Juego/5
        public void Delete(int id)
        {
        }
    }
}
