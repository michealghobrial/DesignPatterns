using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class GamingComputerBuilder : ComputerBuilder
    {
        public override void SetCPU()
        {
            Computer.CPU = "High Performance CPU";
        }

        public override void SetHardDrive()
        {
            Computer.HardDrive = "1 TB SSD";
        }

        public override void SetRAM()
        {
            Computer.RAM = "16 GB DDR4";
        }

        //Optional
        public override void SetGraphicsCard()
        {
            Computer.GraphicsCard = "High-end Graphics Card";
        }
        public override void SetSoundCard()
        {
            Computer.SoundCard = "7.1 Surround Sound Card";
        }
    }
}
