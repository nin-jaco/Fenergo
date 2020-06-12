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
    public class HardwaresController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Hardwares
        public IEnumerable<HardwareDto> GetHardwares()
        {
            return db.Hardwares.ToList().Select(Mapper.Map<Hardware, HardwareDto>);
        }

        // GET: api/Hardwares/5
        [ResponseType(typeof(HardwareDto))]
        public IHttpActionResult GetHardware(int id)
        {
            var hardware = db.Hardwares.Find(id);
            if (hardware == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Hardware, HardwareDto>(hardware));
        }

        // PUT: api/Hardwares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHardware(int id, HardwareDto hardwareDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hardware = db.Hardwares.Find(id);
            if (hardware == null) return NotFound();

            if (id != hardware.Id)
            {
                return BadRequest();
            }

            Mapper.Map(hardwareDto, hardware);
            db.Entry(hardware).State = EntityState.Modified;

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

        // POST: api/Hardwares
        [ResponseType(typeof(HardwareDto))]
        public IHttpActionResult PostHardware(HardwareDto hardwareDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hardware = Mapper.Map<HardwareDto, Hardware>(hardwareDto);
            db.Hardwares.Add(hardware);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hardware.Id }, hardwareDto);
        }

        // DELETE: api/Hardwares/5
        [ResponseType(typeof(HardwareDto))]
        public IHttpActionResult DeleteHardware(int id)
        {
            Hardware hardware = db.Hardwares.Find(id);
            if (hardware == null)
            {
                return NotFound();
            }

            db.Hardwares.Remove(hardware);
            db.SaveChanges();

            return Ok(Mapper.Map<Hardware, HardwareDto>(hardware));
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
            return db.Hardwares.Count(e => e.Id == id) > 0;
        }
    }
}