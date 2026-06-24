using FactoryPattern3.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern3.Factories
{
    public class AmazonS3Factory : StorageFactory
    {
        public override IStorageProvider CreateStorageProvider()
        {
            return new AmazonS3Provider();
        }
    }
}
