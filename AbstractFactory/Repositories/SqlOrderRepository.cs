using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Repositories
{
    public class SqlOrderRepository : IOrderRepository
    {
        public void GetOrder()
        {
            Console.WriteLine("Getting Order From SQL");
        }
    }
}
