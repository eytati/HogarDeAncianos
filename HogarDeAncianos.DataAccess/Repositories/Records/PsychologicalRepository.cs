using HogarDeAncianos.Bussiness.Entities.Records;
using HogarDeAncianos.Bussiness.IRepositories;
using HogarDeAncianos.DataAccess.Connection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.DataAccess.Repositories.Records
{
    public class PsychologicalRepository : IRepository<Psychological>
    {
        protected static IMongoDatabase _dataBase;
        public PsychologicalRepository()
        {
            ConnectionDB classConnection = new ConnectionDB();
            _dataBase = classConnection.Get_dataBase();

        }

        public IMongoCollection<BsonDocument> ObtenerColeccion()
        {
            return _dataBase.GetCollection<BsonDocument>("PsychologicalRecordDB");
        }

        public Psychological CreateOneDocument(Psychological item)
        {
            BsonDocument empleado = new BsonDocument
            {
                { "Id", item.Id },
                { "Cedula" , item.Identification },
                { "Mental test" , item.MentalTest},
                { "Monitoreo" , item.Monitoring},
                { "Historia Personal" , item.PersonalHistory},
                { "Examen Psicologico" , item.PsychologicalTest},
                { "Observaciones" , item.Observations},
                { "Creado por" , item.CreatedByUser},
                { "Editado" , item.EditedByUser},
                { "Creado en" , item.CreationTime},
                { "Editado en" , item.EditionTime}

            };

            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.InsertOneAsync(empleado);
            return item;
        }

        public bool DeleteOneDocument(string id)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = ObtenerColeccion();
                collection.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("Cedula", id));
                return true;
            }
            catch {
                return false; 
            }
        }

        public async Task<IEnumerable<Psychological>> GetManyDocumentsAsync()
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            List<BsonDocument> EmployeeListBson = new List<BsonDocument>();
            List<Psychological> RecordList = new List<Psychological>();
            try
            {
                await collection.Find(new BsonDocument()).ForEachAsync(X => EmployeeListBson.Add(X));

                foreach (BsonDocument documento in EmployeeListBson)
                {
                    var data = documento.ToList();
                    Psychological record = new Psychological
                    {
                        Id = data[1].Value.AsGuid,
                        Identification = data[2].Value.ToString(),
                        MentalTest = data[3].Value.ToString(),
                        Monitoring = data[4].Value.ToString(),
                        PersonalHistory = data[5].Value.ToString(),
                        PsychologicalTest = data[6].Value.ToString(),
                        Observations = data[7].Value.ToString(),
                        CreatedByUser = data[8].Value.ToString(),
                        EditedByUser = data[9].Value.ToString(),
                        CreationTime = data[10].Value.ToUniversalTime(),
                        EditionTime = data[11].Value.ToUniversalTime()

                    };

                    RecordList.Add(record);
                }
            }
            catch (Exception)
            { }
            return RecordList;
        }

        public async Task<Psychological> GetOneDocument(string id)
        {
            Psychological record = null;
            try
            {
                IMongoCollection<BsonDocument> collection = ObtenerColeccion();
                var filter = Builders<BsonDocument>.Filter.Eq("Cedula", id);
                var result = await collection.Find(filter).ToListAsync();

                var data = result[0].ToList();
                record = new Psychological
                {
                    Id = data[1].Value.AsGuid,
                    Identification = data[2].Value.ToString(),
                    MentalTest = data[3].Value.ToString(),
                    Monitoring = data[4].Value.ToString(),
                    PersonalHistory = data[5].Value.ToString(),
                    PsychologicalTest = data[6].Value.ToString(),
                    Observations = data[7].Value.ToString(),
                    CreatedByUser = data[8].Value.ToString(),
                    EditedByUser = data[9].Value.ToString(),
                    CreationTime = data[10].Value.ToUniversalTime(),
                    EditionTime = data[11].Value.ToUniversalTime()
                };


            }
            catch (Exception)
            {
                record = null; 
            }
            return record;
        }

        public bool UpdateOneDument(string id, Psychological item)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();

            BsonDocument record = new BsonDocument
            {
                { "Id", item.Id },
                { "Cedula" , item.Identification },
                { "Mental test" , item.MentalTest},
                { "Monitoreo" , item.Monitoring},
                { "Historia Personal" , item.PersonalHistory},
                { "Examen Psicologico" , item.PsychologicalTest},
                { "Observaciones" , item.Observations},
                { "Creado por" , item.CreatedByUser},
                { "Editado" , item.EditedByUser},
                { "Creado en" , item.CreationTime},
                { "Editado en" , item.EditionTime}
            };

            collection.ReplaceOneAsync(new BsonDocument("Cedula", item.Identification), new BsonDocument(record));

            return true;
        }
    }
}
