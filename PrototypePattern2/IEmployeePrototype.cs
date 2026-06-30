using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern2
{
    public interface IEmployeePrototype
    {
        IEmployeePrototype Clone();
    }
}
