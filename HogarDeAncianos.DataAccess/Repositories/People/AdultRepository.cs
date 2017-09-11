using HogarDeAncianos.Bussiness.Entities;
using HogarDeAncianos.Bussiness.IRepositories;
using HogarDeAncianos.DataAccess.Connection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.DataAccess.Repositories.People
{
    public class AdultRepository : IRepository<Adult>
    {
        protected static IMongoDatabase _dataBase;

        public AdultRepository()
        {
            ConnectionDB classConnection = new ConnectionDB();
            _dataBase = classConnection.Get_dataBase();

        }

        public IMongoCollection<BsonDocument> ObtenerColeccion()
        {
            return _dataBase.GetCollection<BsonDocument>("AdultDB");
        }

        public Adult CreateOneDocument(Adult item)
        {
            BsonDocument adult = new BsonDocument
            {
                { "Nombre", item.Name },
                { "Primer Apellido" , item.FirstSurname },
                { "Segundo Apellido" , item.SecondSurname },
                { "Cedula" , item.Identification },
                { "Cedula CCSS" , item.IdCCSS },
                { "BirthDate" , item.BirthDate },
                { "Genero" , item.Gender },
                { "Estado" , item.State },
                { "Razon de Entrada" , item.EntryReasons },
                { "Ocupacion" , item.Occupation },
                { "Estado Civil" , item.CivilStatus },
                { "Ayuda Biomecanica" , item.Biomechamical },
                { "Direccion" , item.Address },
                { "Fecha de Ingreso" , item.EntryDate },
                { "Contribucion" , item.Contribution },
                { "Pension" , item.Pension },
                { "Monto total" , item.Total },
                { "Creado por" , item.CreatedByUser},
                { "Editado" , item.EditedByUser},
                { "Creado en" , item.CreationTime},
                { "Editado en" , item.EditionTime}
            };

            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.InsertOneAsync(adult);
            return item;
        }

        public bool DeleteOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("Cedula", id));
            return true;
        }

        public async Task<IEnumerable<Adult>> GetManyDocumentsAsync()
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            List<BsonDocument> AdultListBson = new List<BsonDocument>();
            List<Adult> AdultList = new List<Adult>();
            try
            {
                await collection.Find(new BsonDocument()).ForEachAsync(X => AdultListBson.Add(X));

                foreach (BsonDocument documento in AdultListBson)
                {
                    var data = documento.ToList();
                    Adult employee = new Adult
                    {
                        Name = data[1].Value.ToString(),
                        FirstSurname = data[2].Value.ToString(),
                        SecondSurname = data[3].Value.ToString(),
                        Identification = data[4].Value.ToString(),
                        IdCCSS = data[5].Value.ToString(),
                        BirthDate = data[6].Value.ToUniversalTime(),
                        Gender = data[7].Value.ToString(),
                        State = data[8].Value.ToBoolean(),
                        EntryReasons = data[9].Value.ToString(),
                        Occupation = data[10].Value.ToString(),
                        CivilStatus = data[11].Value.ToString(),
                        Biomechamical = data[12].Value.ToString(),
                        Address = data[13].Value.ToString(),
                        EntryDate = data[14].Value.ToUniversalTime(),
                        Contribution = data[15].Value.ToInt32(),
                        Pension = data[16].Value.ToInt32(),
                        Total = data[17].Value.ToInt32(),
                        CreatedByUser = data[18].Value.ToString(),
                        EditedByUser = data[19].Value.ToString(),
                        CreationTime = data[20].Value.ToUniversalTime(),
                        EditionTime = data[21].Value.ToUniversalTime(),
                    };
                    AdultList.Add(employee);
                }
            }
            catch (Exception)
            { }
            return AdultList;
        }

        public async Task<Adult> GetOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            var filter = Builders<BsonDocument>.Filter.Eq("Cedula", id);
            var result = await collection.Find(filter).ToListAsync();

            var data = result[0].ToList();
            Adult adult = new Adult
            {
                Name = data[1].Value.ToString(),
                FirstSurname = data[2].Value.ToString(),
                SecondSurname = data[3].Value.ToString(),
                Identification = data[4].Value.ToString(),
                IdCCSS = data[5].Value.ToString(),
                BirthDate = data[6].Value.ToUniversalTime(),
                Gender = data[7].Value.ToString(),
                State = data[8].Value.ToBoolean(),
                EntryReasons = data[9].Value.ToString(),
                Occupation = data[10].Value.ToString(),
                CivilStatus = data[11].Value.ToString(),
                Biomechamical = data[12].Value.ToString(),
                Address = data[13].Value.ToString(),
                EntryDate = data[14].Value.ToUniversalTime(),
                Contribution = data[15].Value.ToInt32(),
                Pension = data[16].Value.ToInt32(),
                Total = data[17].Value.ToInt32(),
                CreatedByUser = data[18].Value.ToString(),
                EditedByUser = data[19].Value.ToString(),
                CreationTime = data[20].Value.ToUniversalTime(),
                EditionTime = data[21].Value.ToUniversalTime(),
            };

            return adult;
        }

        public bool UpdateOneDument(string id, Adult item)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = ObtenerColeccion();

                BsonDocument adult = new BsonDocument
                {
                    { "Nombre", item.Name },
                    { "Primer Apellido" , item.FirstSurname },
                    { "Segundo Apellido" , item.SecondSurname },
                    { "Cedula" , item.Identification },
                    { "Cedula CCSS" , item.IdCCSS },
                    { "BirthDate" , item.BirthDate },
                    { "Genero" , item.Gender },
                    { "Estado" , item.State },
                    { "Razon de Entrada" , item.EntryReasons },
                    { "Ocupacion" , item.Occupation },
                    { "Estado Civil" , item.CivilStatus },
                    { "Ayuda Biomecanica" , item.Biomechamical },
                    { "Direccion" , item.Address },
                    { "Fecha de Ingreso" , item.EntryDate },
                    { "Contribucion" , item.Contribution },
                    { "Pension" , item.Pension },
                    { "Monto total" , item.Total },
                    { "Creado por" , item.CreatedByUser},
                    { "Editado" , item.EditedByUser},
                    { "Creado en" , item.CreationTime},
                    { "Editado en" , item.EditionTime}
                };

                collection.ReplaceOneAsync(new BsonDocument("Cedula", item.Identification), new BsonDocument(adult));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
