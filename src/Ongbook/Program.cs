using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Ongbook
{
    /// <summary>
    /// Define a classe de entrada da aplicação
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Define o método de entrada da aplicação
        /// </summary>
        /// <param name="args">Parâmetros de inicialização</param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
