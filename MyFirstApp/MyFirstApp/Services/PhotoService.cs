using MyFirstApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Services
{
    public class PhotoService : IPhotoService
    {
        public async Task<List<Photo>> GetPhotos()
        {
            var responsePhoto = RestService.For<IPhotoService>("http://jsonplaceholder.typicode.com");
            var photos = await responsePhoto.GetPhotos();
            
            return photos;
        }
    }
}
