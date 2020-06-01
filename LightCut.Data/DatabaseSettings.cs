﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; }
        public string DatabaseName { get; }
        public string ClientsCollection { get; }
        public string UsersCollection { get; }
        public string SuppliersCollection { get; }
        public string OrdersCollection { get; }
        public string DeliveryMethodsCollection { get; }
        public string MachinesCollection { get; }
        public string MaterialsCollection { get; }
        public string RolesCollection { get; }
    }

    public interface IDatabaseSettings
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
        string ClientsCollection { get; }
        string UsersCollection { get; }
        string SuppliersCollection { get; }
        string OrdersCollection { get; }
        string DeliveryMethodsCollection { get; }
        string MachinesCollection { get; }
        string MaterialsCollection { get; }
        string RolesCollection { get; }
    }
}
