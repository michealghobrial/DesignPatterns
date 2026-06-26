using AbstractFactory3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory3.Implementation
{
    public class ModernSofa : ISofa
    {
        public void LayOn()
        {
            Console.WriteLine("Laying on a modern sofa.");
        }
    }
}
