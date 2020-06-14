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
using Fenergo.Ui.Repositories;

namespace Fenergo.Ui.Controllers.Api
{
    public class HardwaresController : ApiController
    {
        private IHardwareRepository _repository;

        public HardwaresController(IHardwareRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Hardwares
        public IEnumerable<HardwareDto> GetHardwares()
        {
            return _repository.GetAll().Select(MapBackToDto);
        }

        // GET: api/Hardwares/5
        [ResponseType(typeof(HardwareDto))]
        public IHttpActionResult GetHardware(int id)
        {
            var hardware = _repository.Get(id);
            if (hardware == null)
            {
                return NotFound();
            }

            return Ok(MapBackToDto(hardware));
        }

        // PUT: api/Hardwares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHardware(int id, HardwareDto hardwareDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hardware = GetHardware(id);
            if (hardware == null) return NotFound();

            if (id != hardwareDto.Id)
            {
                return BadRequest();
            }

            var hardwareDb = _repository.Update(MapBackToModel(hardwareDto));

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

            var hardware = MapBackToModel(hardwareDto);
            hardware = _repository.Create(hardware);

            return CreatedAtRoute("DefaultApi", new { id = hardware.Id }, hardwareDto);
        }

        // DELETE: api/Hardwares/5
        [ResponseType(typeof(HardwareDto))]
        public IHttpActionResult DeleteHardware(int id)
        {
            var hardware = _repository.Delete(id);

            return Ok(MapBackToDto(hardware));
        }

        public static HardwareDto MapBackToDto(Hardware hardware)
        {
            return Mapper.Map<Hardware, HardwareDto>(hardware);
        }

        public static Hardware MapBackToModel(HardwareDto hardwareDto)
        {
            return Mapper.Map<HardwareDto, Hardware>(hardwareDto);
        }
    }
}