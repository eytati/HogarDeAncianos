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

namespace HogarDeAncianos.DataAccess.Repositories
{
    class ExpNutricitionalRepository : IRepository<ExpNutritional>
    {
        protected static IMongoDatabase _dataBase;

        public ExpNutricitionalRepository()
        {
            ConnectionDB classConnection = new ConnectionDB();
            _dataBase = classConnection.Get_dataBase();
        }

        public IMongoCollection<BsonDocument> ObtenerColeccion()
        {
            return _dataBase.GetCollection<BsonDocument>("Nutritional");
        }

        public ExpNutritional CreateOneDocument(ExpNutritional item)
        {
            try
            {
                BsonDocument expNutritional = new BsonDocument
            {
                { "Cadula", item.Cedula },
                { "Edad" , item.Edad },
                { "Circunferencia Braquial" , item.CircunferenciaBraquial},
                { " Circunferencia De Pantorrilla" , item.CircunferenciaDePantorrilla},
                { "Altura De Rodilla" , item.AlturaDeRodilla},
                { "Peso Actual" , item.PesoActual},
                { "Peso Estimado" , item.PesoEstimado},
                { "Peso Ideal" , item.PesoIdeal},
                { "Porcentaje De Cambio De Peso" , item.PorcentajeDeCambioDePeso},
                { "Talla Actual" , item.TallaActual},
                { "Talla Estimada" , item.TallaEstimada},
                { "IMC" , item.IMC},
                { "TMB" , item.TMB},
                { "FTA" , item.FTA},
                { "FS" , item.FS},
                { "VET" , item.VET},
                { "Observaciones" , item.Observaciones}
            };

                IMongoCollection<BsonDocument> collection = ObtenerColeccion();
                collection.InsertOneAsync(expNutritional);
            }
            catch (Exception)
            { }
            return item;

        }

        public bool DeleteOneDocument(string id)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = ObtenerColeccion();
                collection.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("Id", id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Task<IEnumerable<ExpNutritional>> GetManyDocumentsAsync()
        {
            throw new NotImplementedException();
        }

        public ExpNutritional GetOneDocument(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOneDument(string id, ExpNutritional item)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();

            try
            {
                BsonDocument expNutritional = new BsonDocument
            {
                { "Cadula", item.Cedula },
                { "Edad" , item.Edad },
                { "Circunferencia Braquial" , item.CircunferenciaBraquial},
                { " Circunferencia De Pantorrilla" , item.CircunferenciaDePantorrilla},
                { "Altura De Rodilla" , item.AlturaDeRodilla},
                { "Peso Actual" , item.PesoActual},
                { "Peso Estimado" , item.PesoEstimado},
                { "Peso Ideal" , item.PesoIdeal},
                { "Porcentaje De Cambio De Peso" , item.PorcentajeDeCambioDePeso},
                { "Talla Actual" , item.TallaActual},
                { "Talla Estimada" , item.TallaEstimada},
                { "IMC" , item.IMC},
                { "TMB" , item.TMB},
                { "FTA" , item.FTA},
                { "FS" , item.FS},
                { "VET" , item.VET},
                { "Observaciones" , item.Observaciones}
            };
                collection.ReplaceOneAsync(new BsonDocument("id", item.Cedula), new BsonDocument(expNutritional));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
