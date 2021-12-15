using MyFirstApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Services
{
    public class UserService : IUserService
    {
        public const string API = "http://jsonplaceholder.typicode.com";

        public async Task<List<User>> GetUsers()
        {
            var responseUser = RestService.For<IUserService>(API);
            var users= await responseUser.GetUsers();

            return users;
        }
    }
}
