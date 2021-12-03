using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymenTControLL.Api.Models
{
    public class ParcelstoreDatabaseSettings : IParcelstoreDatabaseSettings
    {
        public string ParcelCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IParcelstoreDatabaseSettings
    {
        string ParcelCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
