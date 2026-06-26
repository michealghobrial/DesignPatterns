using AbstractFactory3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory3.Implementation
{
    public class VintageChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a vintage chair.");
        }
    }
}