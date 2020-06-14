using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;
using Unity.Storage;

namespace Fenergo.Ui.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private IApplicationDbContext db = new ApplicationDbContext();

        public PhotoRepository()
        {
            
        }

        public PhotoRepository(IApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Photo> GetAll()
        {
            return db.Photos.ToList();
        }

        public Photo Get(int id)
        {
            return db.Photos.Find(id);
        }

        public Photo Update(Photo photo)
        {
            //db.Entry(photo).State = EntityState.Modified;
            db.MarkAsModified(photo);
            db.SaveChanges();
            return photo;
        }

        public Photo Create(Photo photo)
        {
            db.Photos.Add(photo);
            db.SaveChanges();
            return photo;
        }

        public Photo Delete(int id)
        {
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return null;
            }

            db.Photos.Remove(photo);
            db.SaveChanges();
            return photo;
        }


        private bool PhotoExists(int id)
        {
            return db.Photos.Count(e => e.Id == id) > 0;
        }
    }
}