using MyFirstApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Services
{
    public interface IPhotoService
    {
        [Get("/photos?_start=0&_limit=50")]
        Task<List<Photo>> GetPhotos();
    }

}
