using AbstractFactory3.Implementation;
using AbstractFactory3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory3.Factories
{
    public class VintageFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VintageChair();
        }

        public ISofa CreateSofa()
        {
            return new VintageSofa();
        }
    }
}
