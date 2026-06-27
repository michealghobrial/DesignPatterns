using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class ComputerShop
    {
        public void ConstructComputer(ComputerBuilder builder)
        {
            builder.SetCPU();
            builder.SetRAM();
            builder.SetHardDrive();
            builder.SetGraphicsCard();
            builder.SetSoundCard();
        }
    }
}
