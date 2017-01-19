using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ongbook.Model
{
    /// <summary>
    /// Define uma entrada do firebase database
    /// </summary>
    public interface IFirebaseEntry
    {
        /// <summary>
        /// Obtém ou define o id da entrada do banco de dados
        /// </summary>
        string id { get; set; }
    }
}
