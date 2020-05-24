using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }
        public string ClientsCollection { get; }
    }

    public interface IDatabaseSettings
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
        string ClientsCollection { get; }
    }
}
