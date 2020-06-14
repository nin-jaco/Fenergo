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
    public class HardwareTypesController : ApiController
    {
        private IHardwareTypeRepository _repository;

        public HardwareTypesController(IHardwareTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/HardwareTypes
        public IEnumerable<HardwareTypeDto> GetHardwareTypes()
        {
            return _repository.GetAll().Select(Mapper.Map<HardwareType, HardwareTypeDto>);
        }

        // GET: api/HardwareTypes/5
        [ResponseType(typeof(HardwareTypeDto))]
        public IHttpActionResult GetHardwareType(int id)
        {
            var hardwareType = _repository.Get(id);
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

            var hardwareType = _repository.Get(id);
            if (hardwareType == null) return NotFound();

            if (id != hardwareType.Id)
            {
                return BadRequest();
            }

            Mapper.Map(hardwareTypeDto, hardwareType);
            hardwareType = _repository.Update(hardwareType);

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
            hardwareType = _repository.Create(hardwareType);

            return CreatedAtRoute("HardwareApi", new { id = hardwareType.Id }, hardwareTypeDto);
        }

        // DELETE: api/HardwareTypes/5
        [ResponseType(typeof(HardwareTypeDto))]
        public IHttpActionResult DeleteHardwareType(int id)
        {
            var hardwareType = _repository.Delete(id);

            return Ok(Mapper.Map<HardwareType, HardwareTypeDto>(hardwareType));
        }

        
    }
}