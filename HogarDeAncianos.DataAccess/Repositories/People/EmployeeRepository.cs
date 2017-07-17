using HogarDeAncianos.Bussiness.Entities;
using HogarDeAncianos.Bussiness.IRepositories;
using HogarDeAncianos.DataAccess.Connection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.DataAccess.Repositories.People
{
    public class EmployeeRepository : IRepository<Employee>
    {
        protected static IMongoDatabase _dataBase;

        public EmployeeRepository()
        {
            ConnectionDB classConnection = new ConnectionDB();
            _dataBase = classConnection.Get_dataBase();

        }

        public IMongoCollection<BsonDocument> ObtenerColeccion()
        {
            return _dataBase.GetCollection<BsonDocument>("Users");
        }

        public Employee CreateOneDocument(Employee item)
        {
            BsonDocument empleado = new BsonDocument
            {
                { "Nombre", item.Name },
                { "Apellido" , item.Lastname },
                { "Cedula" , item.Identification},
                { "Correo Electronico" , item.Email},
                { "Estado Actual" , item.State},
                { "Fecha de Ingreso" , item.EntryDate},
                { "Puesto" , item.Occupation},
                { "Telefono" , item.Phone}
            };

            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.InsertOneAsync(empleado);
            return item;
        }

        public bool DeleteOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("Id", id));
            return true;
        }

        public async Task<IEnumerable<Employee>> GetManyDocumentsAsync()
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            List<BsonDocument> EmployeeListBson = new List<BsonDocument>();
            List<Employee> EmployeeList = new List<Employee>();
            IEnumerable<BsonElement> Prueba = new List<BsonElement>();
            try
            {
                 await collection.Find(new BsonDocument()).ForEachAsync(X => EmployeeListBson.Add(X));
           
                foreach (BsonDocument documento in EmployeeListBson)
                {
                  BsonElement name = documento.GetElement(1);
                  BsonElement Lastname = documento.GetElement(2);
                  BsonElement  Identification= documento.GetElement(3);
                  BsonElement  Phone= documento.GetElement(4);
                  BsonElement Email = documento.GetElement(5);
                  BsonElement EntryDate = documento.GetElement(6);
                  BsonElement occupation = documento.GetElement(7);
                  BsonElement state = documento.GetElement(8);
                }



            }
            catch (Exception)
            { }
            return EmployeeList;
        }

        public Employee GetOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            throw new NotImplementedException();
        }

        public bool UpdateOneDument(string id, Employee item)
        {

            IMongoCollection<BsonDocument> collection = ObtenerColeccion();

            BsonDocument empleado = new BsonDocument
            {
                { "Nombre", item.Name },
                { "Apellido" , item.Lastname },
                { "Cedula" , item.Identification},
                { "Correo Electronico" , item.Email},
                { "Estado Actual" , item.State},
                { "Fecha de Ingreso" , item.EntryDate},
                { "Puesto" , item.Occupation},
                { "Telefono" , item.Phone}
            };

            collection.ReplaceOneAsync(new BsonDocument("id", item.Identification), new BsonDocument(empleado));

            return true;
        }
    }
}
