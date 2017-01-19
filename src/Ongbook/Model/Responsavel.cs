using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ongbook.Model
{
    public class Responsavel
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}
