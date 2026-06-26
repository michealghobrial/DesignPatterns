using AbstractFactory3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory3.Services
{
    public class FurnitureService
    {
        private readonly IChair _chair;
        private readonly ISofa _sofa;
        public FurnitureService(IFurnitureFactory furnitureFactory)
        {
            _chair = furnitureFactory.CreateChair();
            _sofa = furnitureFactory.CreateSofa();
        }
        public void ShowProducts()
        {
            _chair.SitOn();
            _sofa.LayOn();
        }
    }
}
