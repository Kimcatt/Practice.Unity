﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Storage
{
    public interface IConnectionStringStorage
    {
        string GetConnectionString(string key);

        void SaveConnectionString(string key, string val);
    }
}
