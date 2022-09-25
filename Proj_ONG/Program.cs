using System;
using System.Data.SqlClient;

namespace Proj_ONG
{
    internal class Program
    {
        static Adotante a = new Adotante();
        static Animal animal = new Animal();
        static void Main(string[] args)
        {
            MenuPrincipal();
            //chamar apenas a função do menu principal
        }
        static void MenuPrincipal()
        {
            int opc = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("------------------BEM VINDO A ONG DE ADOÇÃO----------------------");
                Console.WriteLine("0 - SAIR DO MENU");
                Console.WriteLine("1 - MENU ADOTANTE");
                Console.WriteLine("2 - MENU DO ANIMAL");
                Console.WriteLine("3 - EFETUAR ADOÇÃO");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 2)
                    Console.WriteLine("OPÇÃO INVÁLIDA! Informe um número válido para acessar o menu:");
                else
                {
                    Console.Clear();
                    switch (opc)
                    {
                        case 0:
                            Console.WriteLine("SAINDO...");
                            Environment.Exit(0);
                            break;
                        case 1:
                            MenuAdotante();
                            break;

                        case 2:
                            MenuAnimal();
                            break;

                        case 3:
                            break;

                        default:
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                            break;
                    }

                }
            } while (opc != 0);
        }
        static public void MenuAdotante()
        {

            int opc = 0;
            do
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-----------------------MENU DO ADOTANTE ----------------------");
                Console.WriteLine("1 - VOLTAR AO MENU PRINCIPAL");
                Console.WriteLine("2 - CADASTRAR ADOTANTE");//insert
                Console.WriteLine("3 - IMPRIMIR TODOS OS CADASTROS ATIVOS");//select
                Console.WriteLine("4 - IMPRIMIR CADASTRO DE UM ADOTANTE ESPECÍFICO");//select c o cpf
                Console.WriteLine("5 - EDITAR CADASTRO DO ADOTANTE"); //UPDATE
                Console.WriteLine("6 - DELETAR CADASTRO"); //DELETE
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 6)
                    Console.WriteLine("OPÇÃO INVÁLIDA! Informe um número válido para acessar o menu:");
                else
                {
                    Console.Clear();
                    switch (opc)
                    {
                        case 1:
                            MenuPrincipal();
                            break;

                        case 2:
                            //Cadastrar adotante, dps verificar que n pode cadastrar c o mesmo cpf
                            Adotante a = new Adotante();
                            a.CadastrarAdotante();
                            InsertAdotante(a);

                            //chamar o metodo de INSERT aqui
                            //chamar cad adotante dnv - sem cpf
                            //UpdateAdotante

                            break;

                        case 3:
                            //Imprimir o cadastro de TODOS os adotantes ativos
                            SelectAdotanteAtivo();
                            //COM O SELECT WHERE
                            break;

                        case 4:
                            //imprimir cadastro de UM adotante ESPECIFICO atraves do CPF
                            SelectAdotante();
                            //COM O SELECT WHERE CPF
                            break;

                        case 5:
                            //Editar dados do adotante
                            UpdateAdotante();
                            break;

                        case 6:
                            break;

                        default:
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                            break;
                    }
                }
            } while (opc < 0 || opc > 6);
        }
        static void MenuAnimal()
        {
            int opc = 0;
            do
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-----------------------MENU DO ANIMAL ----------------------");
                Console.WriteLine("1 - VOLTAR AO MENU PRINCIPAL");
                Console.WriteLine("2 - CADASTRAR ANIMAL");//insert
                Console.WriteLine("3 - IMPRIMIR CADASTRO DOS ANIMAIS DISPONIVEIS");//select
                Console.WriteLine("4 - IMPRIMIR CADASTRO DE UM ANIMAL ESPECÍFICO");//select c o cpf
                Console.WriteLine("5 - EDITAR CADASTRO ANIMAL"); //UPDATE
                Console.WriteLine("6 - DELETAR CADASTRO ANIMAL"); //DELETE
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 6)
                    Console.WriteLine("OPÇÃO INVÁLIDA! Informe um número válido para acessar o menu:");
                else
                {
                    Console.Clear();
                    switch (opc)
                    {
                        case 1:
                            MenuPrincipal();
                            break;

                        case 2:
                            //Cadastrar adotante, dps verificar que n pode cadastrar c o mesmo cpf
                            Animal animal = new Animal();
                            animal.CadastrarAnimal();
                            InsertAnimal(animal);
                            break;

                        case 3:
                            //Imprimir o cadastro de TODOS os adotantes ativos
                            //COM O SELECT WHERE
                            break;

                        case 4:
                            //imprimir cadastro de UM adotante ESPECIFICO atraves do CPF
                            //COM O SELECT WHERE CPF
                            break;

                        case 5:
                            break;

                        case 6:
                            break;

                        default:
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                            break;
                    }
                }
            } while (opc < 0 || opc > 6);

        }
        static void InsertAdotante(Adotante adotante)
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            string sql = $"INSERT INTO dbo.Adotante (Nome, CPF, Sexo, DataNascimento, Logradouro, Numero, CEP, Bairro, Complemento, Cidade, UF, Telefone, Status) VALUES ('{adotante.Nome}', '{adotante.CPF}', '{adotante.Sexo}', '{adotante.DataNascimento}', '{adotante.Logradouro}', '{adotante.Numero}', '{adotante.CEP}', '{adotante.Bairro}', '{adotante.Complemento}', '{adotante.Cidade}', '{adotante.UF}','{adotante.Telefone}', '{adotante.Status}');";

            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            cmd.ExecuteNonQuery();
            Console.ReadKey();
            conexaosql.Close();

        }
        static void UpdateAdotante()
        {
            string sql;
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            Console.WriteLine("Informe o CPF do adotante que deseja editar o cadastro: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Escolha entre as opções: ");
            Console.WriteLine("0 - VOLTAR AO MENU ADOTANTE");
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
                    MenuAdotante();
                    break;
                case 1:
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set Nome='{nome}' WHERE CPF='{cpf}';";
                    SqlCommand cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;

                case 2:
                    char s;
                    do
                    {
                        Console.WriteLine("Informe o novo sexo: (M - Masculino, F - Feminino, N - Não desejo informar) : ");
                        s = char.Parse(Console.ReadLine().ToUpper());
                        if (s != 'M' && s != 'F' && s != 'N')
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA! INFORME (M, F OU N) ");
                        }
                        else
                        {
                            sql = $"UPDATE dbo.Adotante set Sexo='{s}' WHERE CPF='{cpf}';";
                            cmd = new SqlCommand(sql, conexaosql);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            conexaosql.Close();
                        }
                    } while (s != 'M' && s != 'F' && s != 'N');
                    break;

                case 3:
                    DateTime datanasc;
                    Console.Write("Informe a nova Data de Nascimento: ");
                    while (!DateTime.TryParse(Console.ReadLine(), out datanasc))
                    {
                        if (datanasc > DateTime.Now)
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma data válida!");
                        }
                    }
                    string dt = datanasc.ToString("dd/MM/yyyy");
                    sql = $"UPDATE dbo.Adotante set DataNascimento='{dt}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;

                case 4:
                    //fazer tratamento de dados
                    Console.WriteLine("Obs: Nosso sistema de alterar o endereço necessita que seja informado todos os dados do endereço novamente,mesmo que só deseje alterar um campo específico");
                    Console.WriteLine("Novo Logradouro: ");
                    string log = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set Logradouro='{log}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Novo Número: ");
                    int num = int.Parse(Console.ReadLine());
                    sql = $"UPDATE dbo.Adotante set Numero='{num}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();


                    Console.WriteLine("Novo CEP: ");
                    string cep = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set CEP='{cep}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Novo Bairro: ");
                    string b = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set Bairro='{b}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();

                    int opcao = 0;
                    string comp;
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
                                    Console.WriteLine("Novo complemento: ");
                                    comp = Console.ReadLine();
                                    if (comp.Length == 0 && comp.Length > 30)
                                    {
                                        Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                                    }
                                    else
                                    {
                                        sql = $"UPDATE dbo.Adotante set Complemento='{comp}' WHERE CPF='{cpf}';";
                                        cmd = new SqlCommand(sql, conexaosql);
                                        cmd.ExecuteNonQuery();

                                    }
                                } while (comp.Length > 30);
                            }
                            else
                                comp = "--";
                        }
                        catch
                        {
                            Console.WriteLine("Informe um valor NUMERICO! ");

                        }
                    } while (opcao < 0 || opcao != 1 && opcao != 2);


                    Console.WriteLine("Cidade: ");
                    string c = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set Cidade='{c}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("UF: [Ex: SP]");
                    string uf = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set UF='{uf}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;

                case 5:

                    string tel;
                    Console.WriteLine("Novo número de telefone com DDD sem caracteres especiais: [Ex: 16999999999]  ");
                    try
                    {
                        tel = Console.ReadLine();
                        if (tel.Length == 0 && tel.Length > 11)
                        {
                            Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                        }
                        else
                        {
                            sql = $"UPDATE dbo.Adotante set Telefone='{tel}' WHERE CPF='{cpf}';";
                            cmd = new SqlCommand(sql, conexaosql);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Informe um valor NUMERICO! ");
                    }
                    break;


                case 6:
                    int opc;
                    char status;
                    Console.WriteLine("Deseja inativar esse cadastro? [1 - SIM, 2 - NÃO]");
                    opc = int.Parse(Console.ReadLine());
                    if (opc == 1)
                    {
                        do
                        {
                            status = 'I';
                        } while (status != 'A' && status != 'I');
                    }
                    else
                        status = 'A';
                    break;

                default:
                    break;
            }


        }
        static void SelectAdotanteAtivo()
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            string sql = $"SELECT Nome, CPF, Sexo, DataNascimento, Logradouro, Numero, CEP, Bairro, Complemento, Cidade, UF, Telefone FROM dbo.Adotante WHERE Status= 'A';";

            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            cmd.ExecuteNonQuery();
            Console.ReadKey();
            conexaosql.Close();

        }
        static void SelectAdotante(Adotante adotante)
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            Console.WriteLine("Informe o CPF do adotante que deseja vizualizar o cadastro: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\n");

            string sql = $"SELECT {adotante.Nome}, CPF, Sexo, DataNascimento, Logradouro, Numero, CEP, Bairro, Complemento, Cidade, UF, Telefone, Status FROM dbo.Adotante WHERE CPF= '{cpf}';";
            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            //cmd.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Nome: {reader.GetString(0)}");
                    Console.WriteLine($"CPF: {reader.GetString(1)}");
                    Console.WriteLine($"Sexo {reader.GetChar(2)}");
                    Console.WriteLine($"Data Nascimento: {reader.GetDateTime(3).ToShortDateString()}");
                    Console.WriteLine($"Logradouro: {reader.GetString(4)}");
                    Console.WriteLine($"Numero: {reader.GetInt32(5)}");
                    Console.WriteLine($"CEP: {reader.GetInt32(5)}");
                    Console.WriteLine($"Bairro: {reader.GetString(7)}");
                    Console.WriteLine($"Complemento: {reader.GetString(8)}");
                    Console.WriteLine($"Cidade: {reader.GetString(9)}");
                    Console.WriteLine($"UF: {reader.GetString(10)}");
                    Console.WriteLine($"Telefone: {reader.GetString(11)}");
                    Console.WriteLine($"Status: {reader.GetChar(12)}");
                }
            }
            Console.ReadKey();
            conexaosql.Close();
        }
        static void InsertAnimal(Animal animal)
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            string sql = $"INSERT INTO dbo.Animal (CHIP, Familia, Raca, Sexo, Nome, Situacao) VALUES ('{animal.CHIP}', '{animal.Familia}', '{animal.Raca}', '{animal.Sexo}', '{animal.Nome}', '{animal.Situacao}');";

            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            cmd.ExecuteNonQuery();
            Console.ReadKey();
            conexaosql.Close();

        }
        static void UpdateAnimal()
        {
            string sql;
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            Console.WriteLine("Informe o numero do CHIP do animal que deseja editar o cadastro: ");
            string chip = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Escolha entre as opções: ");
            Console.WriteLine("0 - VOLTAR AO MENU ANIMAL");
            Console.WriteLine("1 - Editar NOME");
            Console.WriteLine("2 - Editar FAMILIA");
            Console.WriteLine("3 - Editar RAÇA");
            Console.WriteLine("4 - Editar SEXO");
            Console.WriteLine("5 - Editar SITUAÇÃO do cadastro");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 0:
                    MenuAdotante();
                    break;
                case 1:
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    sql = $"UPDATE dbo.Animal set Nome='{nome}' WHERE CHIP='{chip}';";
                    SqlCommand cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;
                case 2:
                    string fam;
                    do
                    {
                        Console.WriteLine("Informe a Familia: [Ex: Gato, Cachorro]");
                         fam = Console.ReadLine();
                        if (fam.Length <= 0 && fam.Length > 50)
                        {
                            Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                        }
                    } while (fam.Length <= 0 && fam.Length > 50);
                    break;

                case 3:
                    string raca;
                    do
                    {
                        Console.WriteLine("Raça do animal: [Ex: Vira-Lata, Pitbull, ShihTzu]");
                        raca = Console.ReadLine();
                        if (raca.Length <= 0 && raca.Length > 20)
                        {
                            Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                        }
                    } while (raca.Length <= 0 && raca.Length > 20);
                    break;
                case 4:
                    break;

                default:
                    break;


            }
            static void SelectAnimalDisponivel()
            {

            }
            static void SelectAnimal()
            {


            }
            static void DeleteAnimal()
            {

            }
        }
    }
}












