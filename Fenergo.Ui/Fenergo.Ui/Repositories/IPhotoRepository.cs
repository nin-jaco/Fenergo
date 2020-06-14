using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Repositories
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAll();
        Photo Get(int id);
        Photo Update(Photo photo);
        Photo Create(Photo photo);
        Photo Delete(int id);
    }
}