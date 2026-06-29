using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public interface ICarPrototype
    {
        ICarPrototype Clone();
    }
}
