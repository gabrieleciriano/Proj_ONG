using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG
{
    internal class Adotante
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public char Status { get; set; } //A- ATIVO I - INATIVO NO CADASTRO
    }
}
