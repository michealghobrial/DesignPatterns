using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Car : ICarPrototype
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public bool Sunroof { get; set; }
        public Engine EngineType { get; set; }

        public ICarPrototype Clone()
        {
            return (Car)this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"{Model} | Color: {Color} | Engine: {Engine} | Sunroof: {Sunroof} | HorsePower: {EngineType.HorsePower}";
        }
    }
}
