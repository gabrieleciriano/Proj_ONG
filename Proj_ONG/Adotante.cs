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
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public char Status { get; set; } //A- ATIVO I - INATIVO NO CADASTRO

        //Metodo Construtor vazio
        public Adotante()
        {

        }
        //Metodo Construtor com parametros
        public Adotante(string nome, string cpf, char sexo, DateTime dataNasc,string endereco, string telefone, char status)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Sexo = sexo;
            this.DataNascimento = dataNasc;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Status = status;


        }
        public Adotante CadastrarAdotante()
        {
            string n, c;
            char s;
            do
            {
                Console.WriteLine("Informe o seu NOME (Máximo 50 digítos): ");
                n = Console.ReadLine();
                if (n.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (n.Length > 50);         
           
            Console.WriteLine("Informe seu CPF sem caracteres especiais: ");
            c = Console.ReadLine();

            do
            {
                Console.WriteLine("Informe seu genero: (M - Masculino, F - Feminino, N - Não desejo informar) : ");
                 s = char.Parse(Console.ReadLine().ToUpper());
                if (s != 'M' && s != 'F' && s != 'N')
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA! INFORME (M, F OU N) ");
                }
            } while (s != 'M' && s != 'F' && s != 'N');





            return new Adotante();
        }
    }
}

   
