using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.Bussiness.IRepositories
{
    public interface IRepository<T> where T : class
    {

        /// <summary>
        /// Obtener varios documentos por medio de una lista
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
         Task<IEnumerable<T>> GetManyDocumentsAsync();


        /// <summary>
        /// Obtiene un documento por medio de un id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetOneDocument(string id);


        /// <summary>
        /// Crea un nuevo documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T CreateOneDocument(T item);


        /// <summary>
        /// Elimina un documento por medio de un ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteOneDocument(string id);

        /// <summary>
        /// Actualiza el documento por medio de un ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdateOneDument(string id, T item);

    }
}
