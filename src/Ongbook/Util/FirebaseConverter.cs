using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ongbook.Model;

namespace Ongbook.Util
{
    /// <summary>
    /// Define métodos de conversão da resposta da api do firebase
    /// </summary>
    public class FirebaseConverter
    {
        /// <summary>
        /// Move o Id do Firebase para dentro do objeto
        /// </summary>
        /// <typeparam name="T">typeof(IFirebaseEntry)</typeparam>
        /// <param name="json">String json de entrada</param>
        /// <returns>Lista de objetos convertidos</returns>
        public static IEnumerable<T> ConvertCollectionId<T>(string json) where T: IFirebaseEntry
        {
            List<T> result = new List<T>();

            Dictionary<string, T> r = JsonConvert.DeserializeObject<Dictionary<string, T>>(json);

            foreach(var i in r)
            {
                T item = i.Value;
                item.id = i.Key;

                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Move o Id do Firebase para dentro do objeto
        /// </summary>
        /// <typeparam name="T">typeof(IFirebaseEntry)</typeparam>
        /// <param name="json">String json de entrada</param>
        /// <returns>Objeto convertido</returns>
        public static T ConvertId<T>(string json) where T : IFirebaseEntry
        {
            KeyValuePair<string, T> r = JsonConvert.DeserializeObject<KeyValuePair<string, T>>(json);

            T item = r.Value;
            item.id = r.Key;

            return item;
        }


        /// <summary>
        /// Move o Id do Firebase para dentro do objeto
        /// </summary>
        /// <typeparam name="T">typeof(IFirebaseEntry)</typeparam>
        /// <param name="json">String json de entrada</param>
        /// <returns>Objeto convertido</returns>
        public static T Convert<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
