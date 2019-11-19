using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.DAL;
using System.Web.Routing;

namespace WebApi.Controllers
{
    public class ClientsController : ApiController
    {
        private ClientDb db = new ClientDb();

        // GET: api/Clients
        [Route("DefaultResult/")]
        public IQueryable<Client> Getclient()
        {
            int noOfRecord = 5;
            return db.client.Include(r => r.ClientAddress).Take(noOfRecord);
        }



        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }


        [Route("DefaultResult/{FirstName}/{LastName}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetByFullName(string FirstName, string LastName)
        {
            var clients = db.client.Include(r => r.ClientAddress) .Where(k => k.FirstName == FirstName && k.LastName == LastName);
            if(clients == null)
        {
                return NotFound();

            }
            return Ok(clients);
        }

        [Route("DefaultResult/{FirstName}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetByOneName(string FirstName)
        {
            IList<Client> client = null;
            client = db.client.Include(r => r.ClientAddress).Where(k => (k.FirstName.Contains(FirstName)) || (k.LastName.Contains(FirstName))).ToList();
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        // GET: api/ClientInformations/
        [ResponseType(typeof(Client))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetClient(string name)
        {

            IList<Client> clients = null;

            clients = db.client.Where(s => s.FirstName == name || s.LastName == name).ToList();
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.client.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.client.Count(e => e.ClientId == id) > 0;
        }
    }


   

}