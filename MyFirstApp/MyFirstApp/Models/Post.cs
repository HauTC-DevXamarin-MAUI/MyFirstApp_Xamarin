using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MyFirstApp.Models
{
    public class Post
    { 
        public string TitlePhoto { get; set; }
        public string ThumbnailUrl { get; set; }
        public string TitleAlbum { get; set; }
        public string Username { get; set; }
        public Post()
        {

        }
        public Post(string titlePhoto, string url, string titleAlbum, string userName)
        {
            TitlePhoto = titlePhoto;
            TitleAlbum = titleAlbum;
            ThumbnailUrl = url;
            Username = userName;
        }
    }
}
