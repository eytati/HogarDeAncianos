using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.DataAccess.Connection
{
    public class ConnectionDB
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public ConnectionDB()
        {
            _client = new MongoClient("mongodb://AdminHogar:OfeliaCarvajal225.@ds117592.mlab.com:17592/hogardeancianosdb");
            _database = _client.GetDatabase("hogardeancianosdb");
        }

        public IMongoDatabase Get_dataBase()
        {
            return _database;
        }
    }
}
