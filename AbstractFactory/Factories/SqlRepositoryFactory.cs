using AbstractFactory.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    public class SqlRepositoryFactory : IRepositoryFactory
    {
        public IOrderRepository CreateOrderRepository()
        {
            return new SqlOrderRepository();
        }

        public IUserRepository CreateUserRepository()
        {
            return new SqlUserRepository();
        }
    }
}
