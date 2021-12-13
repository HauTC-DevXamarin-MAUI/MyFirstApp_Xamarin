using MyFirstApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Services
{
    public interface IUserService
    {
        [Get("/users")]
        Task<List<User>> GetUsers();
    }
}
