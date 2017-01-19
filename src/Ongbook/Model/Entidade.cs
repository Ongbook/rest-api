using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ongbook.Model
{
    /// <summary>
    /// Representa uma entidade social do Ongbook.org
    /// </summary>
    public class Entidade
    {
        /// <summary>
        /// Razão social da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string razao_social { get; set; }


        /// <summary>
        /// Nome fantasia da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string fantasia { get; set; }


        /// <summary>
        /// CNPJ da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [RegularExpression(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)", 
            ErrorMessage = "O Campo CNPJ deve estar em um formato válido. Exemplo: XX.XXX.XXX/YYYY-ZZ")]
        public string cnpj { get; set; }


        /// <summary>
        /// Inscrição Estadual da entidade (Opcional)
        /// </summary>
        public string ie { get; set; }

        /// <summary>
        /// Ano de fundação da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [Range(1900, 2050, ErrorMessage = "O campo {0} deve possuir um valor válido")]
        public int ano_fundacao { get; set; }


        /// <summary>
        /// Informações de localização da entidade (Filhos obrigatórios)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public Logradouro localizacao { get; set; }


        /// <summary>
        /// Caminho de rota personalizado da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string route { get; set; }



        /// <summary>
        /// Id de cadastro do responsável pela entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public long? id_responsavel { get; set; }
    }


    /// <summary>
    /// Define informações sobre a localização física de uma entidade
    /// </summary>
    public class Logradouro
    {
        /// <summary>
        /// Endereço da entidade (Rua, avenida, etc.) (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string endereco { get; set; }


        /// <summary>
        /// Número do endereço da entidade (obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string numero { get; set; }


        /// <summary>
        /// Bairro da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string bairro { get; set; }


        /// <summary>
        /// Cidade da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string cidade { get; set; }


        /// <summary>
        /// Estado da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string estado { get; set; }


        /// <summary>
        /// Cep da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O campo Cep deve estar em um formato válido. Exemplo: 00000-000")]
        public string cep { get; set; }


        /// <summary>
        /// País de origem da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string pais { get; set; }

        /// <summary>
        /// Complemento do endereço da entidade (Opcional)
        /// </summary>
        public string complemento { get; set; }


        /// <summary>
        /// Coodenada geográfica de Latidude da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "O campo {0} deve estar em um formato válido")]
        public string latitude { get; set; }


        /// <summary>
        /// Coodenada geográfica de Langitude da entidade (Obrigatório)
        /// </summary>
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [RegularExpression(@"^[0-9]*(?:\.[0-9]*)?$", ErrorMessage = "O campo {0} deve estar em um formato válido")]
        public string longitude { get; set; }
        
    }
    
    
    
    /// <summary>
    /// Define uma resposta de entidade na api
    /// </summary>
    public class EntidadeResponse: Entidade, IFirebaseEntry
    {
        /// <summary>
        /// Id da entidade 
        /// </summary>
        public string id { get; set; }
    }
}
