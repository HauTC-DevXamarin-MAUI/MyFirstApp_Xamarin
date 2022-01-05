using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Services
{
    public interface ILoginGoogleService
    {
        Task LoginAsync();
        void Logout();
    }
}
