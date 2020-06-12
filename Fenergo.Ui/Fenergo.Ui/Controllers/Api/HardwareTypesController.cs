using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Fenergo.Ui.Dtos;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Controllers.Api
{
    public class HardwareTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/HardwareTypes
        public IEnumerable<HardwareTypeDto> GetHardwares()
        {
            return db.HardwareTypes.ToList().Select(Mapper.Map<HardwareType, HardwareTypeDto>);
        }

        // GET: api/HardwareTypes/5
        [ResponseType(typeof(HardwareTypeDto))]
        public IHttpActionResult GetHardwareType(int id)
        {
            var hardwareType = db.HardwareTypes.Find(id);
            if (hardwareType == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<HardwareType, HardwareTypeDto>(hardwareType));
        }

        // PUT: api/HardwareTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHardwareType(int id, HardwareTypeDto hardwareTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hardwareType = db.HardwareTypes.Find(id);
            if (hardwareType == null) return NotFound();

            if (id != hardwareType.Id)
            {
                return BadRequest();
            }

            Mapper.Map(hardwareTypeDto, hardwareType);
            db.Entry(hardwareType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HardwareExists(id))
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

        // POST: api/HardwareTypes
        [ResponseType(typeof(HardwareTypeDto))]
        public IHttpActionResult PostHardwareType(HardwareTypeDto hardwareTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hardwareType = Mapper.Map<HardwareTypeDto, HardwareType>(hardwareTypeDto);
            db.HardwareTypes.Add(hardwareType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hardwareType.Id }, hardwareTypeDto);
        }

        // DELETE: api/HardwareTypes/5
        [ResponseType(typeof(HardwareTypeDto))]
        public IHttpActionResult DeleteHardwareType(int id)
        {
            var hardwareType = db.HardwareTypes.Find(id);
            if (hardwareType == null)
            {
                return NotFound();
            }

            db.HardwareTypes.Remove(hardwareType);
            db.SaveChanges();

            return Ok(Mapper.Map<HardwareType, HardwareTypeDto>(hardwareType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HardwareExists(int id)
        {
            return db.HardwareTypes.Count(e => e.Id == id) > 0;
        }
    }
}