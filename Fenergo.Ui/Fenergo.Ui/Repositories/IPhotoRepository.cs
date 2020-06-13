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
        Photo Update(Photo hardware);
        Photo Create(Photo hardware);
        Photo Delete(int id);
    }
}