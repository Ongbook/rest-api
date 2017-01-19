using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ongbook.Controllers
{
    /// <summary>
    /// Define o ponto de entrada da aplicação
    /// </summary>
    public class AppController : Controller
    {
        /// <summary>
        /// Define o método padrão GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Redirect("/docs");
        }
    }
}