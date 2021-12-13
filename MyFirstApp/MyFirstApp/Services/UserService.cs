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
        public async Task<List<User>> GetUsers()
        {
            var responseUser = RestService.For<IUserService>("http://jsonplaceholder.typicode.com");
            var users= await responseUser.GetUsers();

            return users;
        }
    }
}
