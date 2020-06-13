using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Photo> GetAll()
        {
            return db.Photos.ToList();
        }

        public Photo Get(int id)
        {
            return db.Photos.Find(id);
        }

        public Photo Update(Photo hardware)
        {
            db.Entry(hardware).State = EntityState.Modified;

            db.SaveChanges();
            return hardware;
        }

        public Photo Create(Photo hardware)
        {
            db.Photos.Add(hardware);
            db.SaveChanges();
            return hardware;
        }

        public Photo Delete(int id)
        {
            Photo hardware = db.Photos.Find(id);
            if (hardware == null)
            {
                return null;
            }

            db.Photos.Remove(hardware);
            db.SaveChanges();
            return hardware;
        }


        private bool PhotoExists(int id)
        {
            return db.Photos.Count(e => e.Id == id) > 0;
        }
    }
}