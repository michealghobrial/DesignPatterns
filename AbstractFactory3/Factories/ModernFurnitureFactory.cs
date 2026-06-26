using AbstractFactory3.Implementation;
using AbstractFactory3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory3.Factories
{
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }
}
