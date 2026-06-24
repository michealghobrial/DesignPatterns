using FactoryPattern3.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern3.Factories
{
    public abstract class StorageFactory
    {
        public abstract IStorageProvider CreateStorageProvider();

        public void Save(string fileName, byte[] fileData)
        {
            IStorageProvider storageProvider = CreateStorageProvider();
            storageProvider.SaveFile(fileName, fileData);
        }
        public byte[] Retrieve(string fileName)
        {
            IStorageProvider storageProvider = CreateStorageProvider();
            return storageProvider.RetrieveFile(fileName);
        }
    }
}
