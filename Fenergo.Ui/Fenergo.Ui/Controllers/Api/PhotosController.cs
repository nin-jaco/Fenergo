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
    public class PhotosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Photos
        public IEnumerable<PhotoDto> GetPhotos()
        {
            return db.Photos.ToList().Select(Mapper.Map<Photo, PhotoDto>);
        }

        // GET: api/Photos/5
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult GetPhoto(int id)
        {
            var photo = db.Photos.Find(id);
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

            var photo = db.Photos.Find(id);
            if (photo == null) return NotFound();

            if (id != photo.Id)
            {
                return BadRequest();
            }

            Mapper.Map(photoDto, photo);
            db.Entry(photo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photos
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult PostPhoto(PhotoDto photoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var photo = Mapper.Map<PhotoDto, Photo>(photoDto);
            db.Photos.Add(photo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = photo.Id }, photoDto);
        }

        // DELETE: api/Photos/5
        [ResponseType(typeof(PhotoDto))]
        public IHttpActionResult DeletePhoto(int id)
        {
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return NotFound();
            }

            db.Photos.Remove(photo);
            db.SaveChanges();

            return Ok(Mapper.Map<Photo, PhotoDto>(photo));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhotoExists(int id)
        {
            return db.Photos.Count(e => e.Id == id) > 0;
        }
    }
}