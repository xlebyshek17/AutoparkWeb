using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; }
        public DbConnection(string con)
        {
            ConnectionString = con;
        }
    }
}
