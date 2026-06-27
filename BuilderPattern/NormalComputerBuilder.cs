using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class NormalComputerBuilder : ComputerBuilder
    {
        public override void SetCPU()
        {
            Computer.CPU = "Normal Performance CPU";
        }

        public override void SetHardDrive()
        {
            Computer.HardDrive = "512GB SSD";
        }

        public override void SetRAM()
        {
            Computer.RAM = "8 GB DDR4";
        }

        public override void SetGraphicsCard()
        {
            Computer.GraphicsCard = "Normal-end Graphics Card";
        }
        public override void SetSoundCard()
        {
            Computer.SoundCard = "5.1 Surround Sound Card";
        }
    }
}
