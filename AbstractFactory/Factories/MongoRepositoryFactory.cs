using AbstractFactory.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    public class MongoRepositoryFactory : IRepositoryFactory
    {
        public IOrderRepository CreateOrderRepository()
        {
            return new MongoOrderRepository();
        }

        public IUserRepository CreateUserRepository()
        {
            return new MongoUserRepository();
        }
    }
}
