using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ongbook
{
    /// <summary>
    /// Define configurações locais do cliente do Firebase
    /// </summary>
    public static class Firebase
    {

        /// <summary>
        /// Obtém um objeto de acesso à api do firebase
        /// </summary>
        public static IFirebaseClient Client { get; set; }




        /// <summary>
        /// Método chamado em tempo de execução para a configuração da api do firebase
        /// </summary>
        public static void Configure()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "oRNHK4WGUMouQYyuw6eHakTQkFV3MElDAasyW7Xp",
                BasePath = "https://ongbook-9c3ec.firebaseio.com"
                
            };

            Client = new FirebaseClient(config);
        }
    }
}
