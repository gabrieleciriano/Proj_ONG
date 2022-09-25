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
        public char Status { get; set; } //A- ATIVO I - INATIVO NO CADASTRO

        //Metodo Construtor vazio
        public Adotante()
        {

        }
        //Metodo Construtor com parametros
        //public Adotante(string nome, string cpf, char sexo, string dataNasc, string logradouro, string numero, int cep, string bairro, string complemento, string cidade, string uf, string telefone, char status)
        //{
        //    this.Nome = nome;
        //    this.CPF = cpf;
        //    this.Sexo = sexo;
        //    this.DataNascimento = dataNasc;
        //    this.Logradouro = logradouro;
        //    this.Numero = numero;
        //    this.CEP = cep;
        //    this.Bairro = bairro;
        //    this.Complemento = complemento;
        //    this.Cidade = cidade;
        //    this.UF = uf;
        //    this.Telefone = telefone;
        //    this.Status = status;


        //}
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

            Status = 'A';

        }

       public void EditarCadastroAdotante()
        {

            //Adotante adotante = new Adotante();
            Console.WriteLine("Informe o CPF do adotante que deseja editar o cadastro: ");
            string cpf = Console.ReadLine();

            //Console.WriteLine("Não há nenhum CPF cadastrado com esse numero!");
            // cpf = adotante.FirstOrDefault(c => c.CPF == cpf);
            Console.WriteLine("Escolha entre as opções: ");
            Console.WriteLine("1 - Editar NOME");
            Console.WriteLine("2 - Editar SEXO");
            Console.WriteLine("3 - Editar DATA DE NASCIMENTO");
            Console.WriteLine("4 - Editar ENDEREÇO");
            Console.WriteLine("5 - Editar TELEFONE");
            Console.WriteLine("6 - Editar STATUS do cadastro");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Informe o nome correto: ");
                    string nome = Console.ReadLine();
                    string sql = $"UPDATE dbo.Adotante set Nome='{nome}' WHERE CPF='{cpf}';";
                    //db.UpdateTable(sql);


                    break;

                case 2:
                    do
                    {
                        Console.WriteLine("Informe seu genero correto: (M - Masculino, F - Feminino, N - Não desejo informar) : ");
                        Sexo = char.Parse(Console.ReadLine().ToUpper());
                        if (Sexo != 'M' && Sexo != 'F' && Sexo != 'N')
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA! INFORME (M, F OU N) ");
                        }
                    } while (Sexo != 'M' && Sexo != 'F' && Sexo != 'N');
                    break;

                case 3:
                    DateTime datanasc;
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
                    
                    break;

                case 4:
                    Console.WriteLine("Informe o Endereço correto: ");
                    //criar e chamar o metodo de editar o endereco aq
                    break;

                case 5:
                    do
                    {
                        Console.WriteLine("Informe o número de Telefone para contato com o DDD sem caracteres especiais: ");
                        Telefone = Console.ReadLine();
                        if (Telefone.Length > 11)
                        {
                            Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                        }
                    } while (Telefone.Length > 11);
                    break;
                case 6:
                    do
                    {
                        Console.WriteLine("Informe o STATUS do cadastro (A - Ativo, I - Inativo): ");
                        Status = char.Parse(Console.ReadLine());
                    } while (Status != 'A' && Status != 'I');
                    break;

                default:
                    break;
            }
        }
       
        public override string ToString()
        {
            return $"NOME: {Nome} \nCPF: {CPF.Substring(0, 3)}.{CPF.Substring(3, 3)}.{CPF.Substring(6, 3)}-{CPF.Substring(9, 2)}" +
                $"\nSEXO: {Sexo} \nDATA DE NASCIMENTO: {DataNascimento}" +
                $"\nTELEFONE: ({Telefone.Substring(0, 2)}){Telefone.Substring(2, 5)}-{Telefone.Substring(7, 4)}" +
                $"\nEndereço: Lograduro: {Logradouro}, Numero: {Numero}, CEP: {CEP}, Bairro: {Bairro}, Complemento: {Complemento}" +
                $"\nCIDADE: {Cidade}, \nUF: {UF} ".ToString();
        }
    }

}



