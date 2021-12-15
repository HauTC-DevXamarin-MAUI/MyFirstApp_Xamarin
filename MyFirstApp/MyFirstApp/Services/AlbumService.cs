using MyFirstApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Services
{
    public class AlbumService : IAlbumService
    {
        public const string API = "http://jsonplaceholder.typicode.com";
        public async Task<List<Album>> GetAlbums()
        {
            var responseAlbum = RestService.For<IAlbumService>(API);
            var albums = await responseAlbum.GetAlbums();

            return albums;
        }
    }
}
