using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Repositories
{
    public class MongoOrderRepository : IOrderRepository
    {
        public void GetOrder()
        {
            Console.WriteLine("Getting Order From Mongo");
        }
    }
}
