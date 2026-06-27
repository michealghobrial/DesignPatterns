using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public abstract class ComputerBuilder
    {
        protected Computer Computer { get; private set; } = new Computer();
        public abstract void SetCPU();
        public abstract void SetRAM();
        public abstract void SetHardDrive();
        public virtual void SetGraphicsCard() { } // Optional
        public virtual void SetSoundCard() { }    // Optional
        public Computer GetComputer() => Computer;
    }
}
