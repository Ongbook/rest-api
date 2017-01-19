//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using FireSharp;
//using FireSharp.Response;
//using Ongbook.Model;
//using Microsoft.AspNetCore.Cors;
//using Ongbook.Util;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Ongbook.Controllers.Api.v2
//{
//    /// <summary>
//    /// Define métodos de requisição e manipulação de dados
//    /// referentes às entidades cadastradas no ongbook.org
//    /// </summary>
//    [Route("api/v2/[controller]")]
//    [Produces("application/json")]
//    [ApiExplorerSettings(GroupName = "v2")]
//    public class EntidadesController : Controller
//    {
//        /// <summary>
//        /// Obtém uma lista de entidades cadastradas no ongbook.org
//        /// </summary>
//        /// <param name="cnpj">CNPJ da entidade a ser pesquisada</param>
//        /// <param name="razaosocial">Razão social da entidade a ser pesquisada</param>
//        /// <param name="cidade">Cidade de atuação da entidade</param>
//        /// <param name="cep">Cep referente à localização da entidade</param>
//        /// <param name="estado">Estado (UF) da entidade</param>
//        /// <returns>JSON</returns>
//        [HttpGet]
//        [Produces(typeof(ApiResponse))]
//        public async Task<IActionResult> Get([FromQuery]string cnpj, [FromQuery]string razaosocial,
//                [FromQuery]string cidade, [FromQuery]string cep, [FromQuery]string estado)
//        { 
//            string orderby = "", equalTo = "";

//            FirebaseResponse result;
//            ApiResponse response = new ApiResponse();

//            if (!string.IsNullOrEmpty(cnpj))
//            {
//                orderby = "cnpj";
//                equalTo = cnpj;
//            }
//            else if (!string.IsNullOrEmpty(razaosocial))
//            {
//                orderby = "razao_social";
//                equalTo = razaosocial;
//            }
//            else if (!string.IsNullOrEmpty(cidade))
//            {
//                orderby = "localizacao/cidade";
//                equalTo = cidade;
//            }
//            else if (!string.IsNullOrEmpty(cep))
//            {
//                orderby = "localizacao/cep";
//                equalTo = cep;
//            }
//            else if (!string.IsNullOrEmpty(estado))
//            {
//                orderby = "localizacao/estado";
//                equalTo = estado;
//            }
//            else
//            {
//                result = await Firebase.Client.GetAsync("entidades/");
//                response.Response = FirebaseConverter.ConvertCollectionId<EntidadeResponse>(result.Body);

//                response.Status = (int)result.StatusCode;

//                return Json(response);
//            }

//            result = await Firebase.Client.GetAsync("entidades/", QueryBuilder.New().OrderBy(orderby).EqualTo(equalTo));
//            response.Response = FirebaseConverter.ConvertCollectionId<EntidadeResponse>(result.Body);

//            response.Status = (int)result.StatusCode;

//            return Json(response);
//        }

//        /// <summary>
//        /// Obtém os dados de uma entidade específica
//        /// </summary>
//        /// <param name="id">Id da entidade cadastrada no ongbook.org</param>
//        /// <returns>JSON</returns>
//        [HttpGet("{id}")]
//        [Produces(typeof(ApiResponse))]
//        public async Task<IActionResult> Get([FromQuery]string id)
//        {
//            ApiResponse response = new ApiResponse();

//            var result = await Firebase.Client.GetAsync("entidades/" + id);
//            response.Response = FirebaseConverter.ConvertCollectionId<Entidade>(result.Body);

//            response.Status = (int)result.StatusCode;

//            return Json(response);
//        }

//        /// <summary>
//        /// Insere uma nova entidade no ongbook.org
//        /// </summary>
//        /// <returns>JSON</returns>
//        [HttpPost]
//        [Produces(typeof(ApiResponse))]
//        public async Task<IActionResult> Post([FromBody]Entidade model)
//        {
//            ApiResponse response = new ApiResponse();
//            response.Errors = new ApiError();
//            int status = 200;
//            if (ModelState.IsValid)
//            {
//                var result = await Firebase.Client.PushAsync("entidades/", model);

//                response.Response = FirebaseConverter.ConvertCollectionId<Entidade>(result.Body);

//                status = (int)result.StatusCode;
//                response.Status = status;

//                if(status != 200)
//                {
//                    response.Errors.Add(result.Body);
//                }
//                return StatusCode(status, response);
//            }
//            else
//            {
//                foreach (var item in ModelState.Values)
//                {
//                    foreach(var error in item.Errors)
//                    {
//                        response.Errors.Add(error.ErrorMessage);
//                    }
//                }
//                response.Status = 400;

//                return BadRequest(response);
//            }
//        }

//        /// <summary>
//        /// Atualiza os dados de uma entidade cadastrada
//        /// </summary>
//        /// <param name="id">Id da entidade</param>
//        /// <returns>JSON</returns>
//        [HttpPut("{id}")]
//        [Produces(typeof(ApiResponse))]
//        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] Entidade model)
//        {
//            ApiResponse response = new ApiResponse();
//            response.Errors = new ApiError();
//            int status = 200;
//            if (ModelState.IsValid)
//            {
//                var result = await Firebase.Client.UpdateAsync("entidades/" + id, model);

//                response.Response = FirebaseConverter.ConvertCollectionId<Entidade>(result.Body);

//                status = (int)result.StatusCode;
//                response.Status = status;

//                if (status != 200)
//                {
//                    response.Errors.Add(result.Body);
//                }
//                return StatusCode(status, response);
//            }
//            else
//            {
//                foreach (var item in ModelState.Values)
//                {
//                    foreach (var error in item.Errors)
//                    {
//                        response.Errors.Add(error.ErrorMessage);
//                    }
//                }
//                response.Status = 400;

//                return BadRequest(response);
//            }
//        }
//    }
//}
