using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory3.Interfaces
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }
}
