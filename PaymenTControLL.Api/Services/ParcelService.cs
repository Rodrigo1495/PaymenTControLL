using MongoDB.Driver;
using PaymenTControLL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymenTControLL.Api.Services
{
    public class ParcelService
    {
        private readonly IMongoCollection<Parcel> _parcels;

        public ParcelService(IParcelstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _parcels = database.GetCollection<Parcel>(settings.ParcelCollectionName);
        }

        public List<Parcel> Get() =>
            _parcels.Find(parcel => true).ToList();

        public Parcel Get(string id) =>
            _parcels.Find<Parcel>(parcel => parcel.Id == id).FirstOrDefault();

        public Parcel Create(Parcel parcel)
        {
            _parcels.InsertOne(parcel);
            return parcel;
        }

        public void Update(string id, Parcel parcelIn) =>
            _parcels.ReplaceOne(parcel => parcel.Id == id, parcelIn);

        public void Remove(Parcel parcelIn) =>
            _parcels.DeleteOne(parcel => parcel.Id == parcelIn.Id);

        public void Remove(string id) =>
            _parcels.DeleteOne(parcel => parcel.Id == id);
    }
}
