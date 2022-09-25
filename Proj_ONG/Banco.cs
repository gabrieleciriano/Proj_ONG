using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG
{
    internal class Banco
    {
        string Conexao = "Data Source=localhost; Initial Catalog=OngAdocao; User Id=sa; Password=MT1860143g;";


        public Banco()
        {

        }
        //Metodo publico do tipo string que retorna a string conexao
        public string Caminho()
        {
            return Conexao;
        }

        
        
        

    }
}
