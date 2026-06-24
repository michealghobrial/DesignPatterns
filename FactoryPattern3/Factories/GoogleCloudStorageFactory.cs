using FactoryPattern3.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern3.Factories
{
    public class GoogleCloudStorageFactory : StorageFactory
    {
        public override IStorageProvider CreateStorageProvider()
        {
            return new GoogleCloudStorageProvider();
        }
    }
}
