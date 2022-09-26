using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public string DataNascimento { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public int CEP { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }

        public Adotante()
        {

        }
        public void CadastrarAdotante()
        {

            DateTime datanasc;
            do
            {
                Console.WriteLine("Informe o seu NOME (Máximo 50 digítos): ");
                Nome = Console.ReadLine();
                if (Nome.Length < 0 && Nome.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Nome.Length  < 0 && Nome.Length > 50);

            Console.WriteLine("Informe seu CPF sem caracteres especiais: ");
            CPF = Console.ReadLine();

            do
            {
                Console.WriteLine("Informe seu genero: (M - Masculino, F - Feminino, N - Não desejo informar) : ");
                Sexo = char.Parse(Console.ReadLine().ToUpper());
                if (Sexo != 'M' && Sexo != 'F' && Sexo != 'N')
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA! INFORME (M, F OU N) ");
                }
            } while (Sexo != 'M' && Sexo != 'F' && Sexo != 'N');

            Console.Write("Informe a Data de Nascimento: ");
            while (!DateTime.TryParse(Console.ReadLine(), out datanasc))
            {
                if (datanasc > DateTime.Now)
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma data válida!");
                }
                else
                    Console.Write("Informe a Data de Nascimento: ");
            }
            DataNascimento = datanasc.ToString("dd/MM/yyyy");

            Console.WriteLine("Agora, informe os dados referente ao ENDEREÇO do Adotante: ");
            do
            {
                Console.WriteLine("Informe o Logradouro (Máximo 50 caracteres): ");
                Logradouro = Console.ReadLine();
                if (Logradouro.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Logradouro.Length > 50);

            Console.WriteLine("Informe o Numero da Residencia: ");
            Numero = Console.ReadLine();
            Console.WriteLine("Informe o CEP: ");
            try
            {
                CEP = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Informe um valor NUMERICO! ");
            }

            do
            {
                Console.WriteLine("Informe o Bairro (Máximo 20 caracteres): ");
                Bairro = Console.ReadLine();
                if (Bairro.Length > 20)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Bairro.Length > 20);

            int opcao = 0;
            do
            {
                Console.WriteLine("Deseja adicionar um complemento? (1 - SIM, 2 - NÃO): ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao == 1)
                    {
                        do
                        {
                            Console.WriteLine("Informe o complemento (Máximo 30 caracteres): ");
                            Complemento = Console.ReadLine();
                            if (Complemento.Length > 30)
                            {
                                Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                            }
                        } while (Complemento.Length > 30);
                    }
                    else
                        Complemento = "--";
                }
                catch
                {
                    Console.WriteLine("Informe um valor NUMERICO! ");

                }
            } while (opcao < 0 || opcao != 1 && opcao != 2);

            do
            {
                Console.WriteLine("Informe a Cidade onde reside (Máximo 30 caracteres): ");
                Cidade = Console.ReadLine();
                if (Cidade.Length > 30)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Cidade.Length > 30);

            do
            {
                Console.WriteLine("Informe a Unidade Federativa onde reside (Ex: SP): ");
                UF = Console.ReadLine();
                if (UF.Length > 2)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (UF.Length > 50);
            do
            {
                Console.WriteLine("Informe o Telefone para contato com o DDD sem caracteres especiais (Máximo 11 digítos): ");
                Telefone = Console.ReadLine();
                if (Telefone.Length > 11)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Telefone.Length > 11);
        
        }
    }

}



