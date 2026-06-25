using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        public void GetUser()
        {
            Console.WriteLine("Getting User From SQL");
        }
    }
}
