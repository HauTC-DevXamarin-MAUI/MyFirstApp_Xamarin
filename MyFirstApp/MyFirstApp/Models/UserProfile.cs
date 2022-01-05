using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyFirstApp.Models
{
    public class UserProfile 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
    }
}
