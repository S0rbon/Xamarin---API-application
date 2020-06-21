using Microsoft.AspNet.OData;
using KlassenlisteService.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace KlassenlisteService.Controllers
{
    public class KlassenlistesController : ODataController
    {
        KlassenlistesContext db = new KlassenlistesContext();
        private bool KlassenlisteExists(int key)
        {
            return db.Klassenlistes.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Klassenliste> Get()
        {
            return db.Klassenlistes;
        }
        [EnableQuery]
        public SingleResult<Klassenliste> Get([FromODataUri] int key)
        {
            IQueryable<Klassenliste> result = db.Klassenlistes.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Klassenliste Klassenliste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Klassenlistes.Add(Klassenliste);
            await db.SaveChangesAsync();
            return Created(Klassenliste);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Klassenliste> Klassenliste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Klassenlistes.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            Klassenliste.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlassenlisteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Klassenliste update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlassenlisteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var Klassenliste = await db.Klassenlistes.FindAsync(key);
            if (Klassenliste == null)
            {
                return NotFound();
            }
            db.Klassenlistes.Remove(Klassenliste);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}