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
    public class PhotosController : ApiController
    {
        private IPhotoRepository _repository;

        public PhotosController(IPhotoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Photos
        public IEnumerable<PhotoDto> GetPhotos()
        {
            return _repository.GetAll().Select(Mapper.Map<Photo, PhotoDto>);
        }

        // GET: api/Photos/5
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult GetPhoto(int id)
        {
            var photo = _repository.Get(id);
            if (photo == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Photo, PhotoDto>(photo));
        }

        // PUT: api/Photos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhoto(int id, PhotoDto photoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var photo = _repository.Get(id);
            if (photo == null) return NotFound();

            if (id != photo.Id)
            {
                return BadRequest();
            }

            Mapper.Map(photoDto, photo);
            photo = _repository.Update(photo);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Photos
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult PostPhoto(PhotoDto photoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var photo = Mapper.Map<PhotoDto, Photo>(photoDto);
            photo = _repository.Create(photo);

            return CreatedAtRoute("PhotosApi", new { id = photo.Id }, photoDto);
        }

        // DELETE: api/Photos/5
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult DeletePhoto(int id)
        {
            var photo = _repository.Delete(id);

            return Ok(Mapper.Map<Photo, PhotoDto>(photo));
        }

        
    }
}