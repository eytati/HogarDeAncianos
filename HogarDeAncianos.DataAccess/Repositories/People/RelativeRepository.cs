using HogarDeAncianos.Bussiness.Entities.Records;
using HogarDeAncianos.Bussiness.IRepositories;
using HogarDeAncianos.DataAccess.Connection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogarDeAncianos.DataAccess.Repositories.People
{
    public class RelativeRepository : IRepository<Relative>
    {
        protected static IMongoDatabase _dataBase;

        public RelativeRepository()
        {
            ConnectionDB classConnection = new ConnectionDB();
            _dataBase = classConnection.Get_dataBase();
        }

        public IMongoCollection<BsonDocument> ObtenerColeccion()
        {
            return _dataBase.GetCollection<BsonDocument>("RelativesDB");
        }

        public Relative CreateOneDocument(Relative item)
        {
            BsonDocument relative = new BsonDocument
            {
                { "Nombre", item.Name },
                { "Primer Apellido" , item.FirstSurname },
                { "Segundo Apellido" , item.SecondSurname },
                { "Cedula" , item.Identification },
                { "Direccion" , item.Address },
                { "Telefono" , item.Phone },
                { "Correo Electronico" , item.Email },
                { "Parentesco", item.Related },
                { "Cedula del Adulto Mayor" , item.OlderAdultId }
            };

            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.InsertOneAsync(relative);
            return item;
        }

        public bool DeleteOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("Cedula", id));
            return true;
        }

        public async Task<IEnumerable<Relative>> GetManyDocumentsAsync()
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            List<BsonDocument> RelativeListBson = new List<BsonDocument>();
            List<Relative> RelativesList = new List<Relative>();
            try
            {
                await collection.Find(new BsonDocument()).ForEachAsync(X => RelativeListBson.Add(X));


                foreach (BsonDocument document in RelativeListBson)
                {
                    var data = document.ToList();
                    Relative relative = new Relative
                    {
                        Name = data[1].Value.ToString(),
                        FirstSurname = data[2].Value.ToString(),
                        SecondSurname = data[3].Value.ToString(),
                        Identification = data[4].Value.ToString(),
                        Address = data[5].Value.ToString(),
                        Phone = data[6].Value.ToString(),
                        Email = data[7].Value.ToString(),
                        Related = data[8].Value.ToString(),
                        OlderAdultId = data[9].Value.ToString()
                    };

                    RelativesList.Add(relative);
                }
            }catch (Exception)
            { }
            return RelativesList;
        }

        public async Task<Relative> GetOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            var filter = Builders<BsonDocument>.Filter.Eq("Cedula", id);
            var result = await collection.Find(filter).ToListAsync();

            var data = result[0].ToList();
            Relative relative = new Relative
            {
                Name = data[1].Value.ToString(),
                FirstSurname = data[2].Value.ToString(),
                SecondSurname = data[3].Value.ToString(),
                Identification = data[4].Value.ToString(),
                Address = data[5].Value.ToString(),
                Phone = data[6].Value.ToString(),
                Email = data[7].Value.ToString(),
                Related = data[8].Value.ToString(),
                OlderAdultId = data[9].Value.ToString()

            };

            return relative;
        }

        public bool UpdateOneDument(string id, Relative item)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = ObtenerColeccion();

                BsonDocument empleado = new BsonDocument
                {
                    { "Nombre", item.Name },
                    { "Primer Apellido" , item.FirstSurname },
                    { "Segundo Apellido" , item.SecondSurname },
                    { "Cedula" , item.Identification },
                    { "Direccion" , item.Address },
                    { "Telefono" , item.Phone },
                    { "Correo Electronico" , item.Email },
                    { "Parentesco", item.Related },
                    { "Cedula del Adulto Mayor" , item.OlderAdultId }
                };

                collection.ReplaceOneAsync(new BsonDocument("id", item.Identification), new BsonDocument(empleado));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
