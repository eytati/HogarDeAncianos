using HogarDeAncianos.Bussiness.Entities;
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
            return _dataBase.GetCollection<BsonDocument>("EmployeesDB");
        }

        public Employee CreateOneDocument(Employee item)
        {
            BsonDocument empleado = new BsonDocument
            {
                { "Nombre", item.Name },
                { "Apellido" , item.Lastname },
                { "Cedula" , item.Identification },
                { "Correo Electronico" , item.Email },
                { "Estado Actual" , item.State },
                { "Fecha de Ingreso" , item.EntryDate },
                { "Puesto" , item.Occupation },
                { "Telefono" , item.Phone }
            };

            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.InsertOneAsync(empleado);
            return item;
        }

        public bool DeleteOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            collection.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("Cedula", id));
            return true;
        }

        public async Task<IEnumerable<Employee>> GetManyDocumentsAsync()
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            List<BsonDocument> EmployeeListBson = new List<BsonDocument>();
            List<Employee> EmployeeList = new List<Employee>();
            try
            {
                 await collection.Find(new BsonDocument()).ForEachAsync(X => EmployeeListBson.Add(X));

                foreach (BsonDocument documento in EmployeeListBson)
                {
                    var data = documento.ToList();
                    Employee employee = new Employee
                    {
                        Name = data[1].Value.ToString(),
                        Lastname = data[2].Value.ToString(),
                        Identification = data[3].Value.ToString(),
                        Email = data[4].Value.ToString(),
                        State = data[5].Value.ToBoolean(),
                        EntryDate = data[6].Value.ToUniversalTime(),
                        Occupation = data[7].Value.ToString(),
                        Phone = data[8].Value.ToString()
                    };

                EmployeeList.Add(employee);
                }
            }
            catch (Exception)
            { }
            return EmployeeList;
        }

        public async Task<Employee> GetOneDocument(string id)
        {
            IMongoCollection<BsonDocument> collection = ObtenerColeccion();
            var filter = Builders<BsonDocument>.Filter.Eq("Cedula", id);
            var result = await collection.Find(filter).ToListAsync();

            var data = result[0].ToList();
            Employee employee = new Employee
            {
                Name = data[1].Value.ToString(),
                Lastname = data[2].Value.ToString(),
                Identification = data[3].Value.ToString(),
                Email = data[4].Value.ToString(),
                State = data[5].Value.ToBoolean(),
                EntryDate = data[6].Value.ToUniversalTime(),
                Occupation = data[7].Value.ToString(),
                Phone = data[8].Value.ToString()
            };

            return employee; 
        }

        public bool UpdateOneDument(string id, Employee item)
        {
            try
            {
                IMongoCollection<BsonDocument> collection = ObtenerColeccion();

                BsonDocument empleado = new BsonDocument
                {
                    { "Nombre", item.Name },
                    { "Apellido" , item.Lastname },
                    { "Cedula" , item.Identification },
                    { "Correo Electronico" , item.Email },
                    { "Estado Actual" , item.State },
                    { "Fecha de Ingreso" , item.EntryDate },
                    { "Puesto" , item.Occupation },
                    { "Telefono" , item.Phone }
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
