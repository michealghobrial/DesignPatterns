using AbstractFactory.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    public interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository();
        IOrderRepository CreateOrderRepository();
    }
}
