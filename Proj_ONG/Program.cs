using System;
using System.Data.SqlClient;

namespace Proj_ONG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
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
                Console.WriteLine("3 - MENU ADOÇÃO");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 3)
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
                            MenuAdocao();
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
                Console.WriteLine("2 - CADASTRAR ADOTANTE");
                Console.WriteLine("3 - IMPRIMIR CADASTRO DE UM ADOTANTE ESPECÍFICO");
                Console.WriteLine("4 - EDITAR CADASTRO DO ADOTANTE");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 4)
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
                            Adotante a = new Adotante();
                            a.CadastrarAdotante();
                            InsertAdotante(a);
                            break;

                        case 3:
                            //imprimir cadastro de UM adotante ESPECIFICO atraves do CPF
                            SelectAdotanteEspecifico();
                            break;

                        case 4:
                            //Editar dados do cadastro do Adotante
                            UpdateAdotante();
                            break;

                        default:
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                            break;
                    }
                }
            } while (opc < 0 || opc > 4);
        }
        static void MenuAnimal()
        {
            int opc = 0;
            do
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-----------------------MENU DO ANIMAL ----------------------");
                Console.WriteLine("1 - VOLTAR AO MENU PRINCIPAL");
                Console.WriteLine("2 - CADASTRAR ANIMAL");
                Console.WriteLine("3 - IMPRIMIR CADASTRO DE UM ANIMAL ESPECÍFICO");
                Console.WriteLine("4 - EDITAR CADASTRO ANIMAL");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 4)
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
                            //imprimir cadastro de um Animal ESPECIFICO atraves do CHIP
                            SelectAnimalEspecifico();
                            break;

                        case 4:
                            //Editar dados no cadastro do Animal
                            UpdateAnimal();
                            break;

                        default:
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                            break;
                    }
                }
            } while (opc < 0 || opc > 4);

        }
        static void MenuAdocao()
        {
            int opc = 0;
            do
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("-----------------------MENU DE ADOÇÃO----------------------");
                Console.WriteLine("1 - VOLTAR AO MENU PRINCIPAL");
                Console.WriteLine("2 - CADASTRAR ADOÇÃO");
                Console.WriteLine("3 - IMPRIMIR CADASTRO DAS ADOÇÕES");
                Console.WriteLine("4 - IMPRIMIR CADASTRO DE UMA ADOÇÃO ESPECÍFICA");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Digite a opção desejada: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 0 || opc > 4)
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
                            //Cadastrar Adoções
                            RealizarAdocao();
                            break;

                        case 3:
                            //Imprimir todas as adoções cadastradas
                            SelectAdocao();
                            break;

                        case 4:
                            //Imprimir cadastro de uma adoção específica
                            SelectAdocaoEspecifico();
                            break;

                        default:
                            Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                            break;
                    }
                }
            } while (opc < 0 || opc > 4);
        }

        //FUNCIONANDO
        //arrumado
        static void InsertAdotante(Adotante adotante)
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            try
            {

                conexaosql.Open();
                string sql = $"INSERT INTO dbo.Adotante (Nome, CPF, Sexo, DataNascimento, Logradouro, Numero, CEP, Bairro, Complemento, Cidade, UF, Telefone) VALUES ('{adotante.Nome}', '{adotante.CPF}', '{adotante.Sexo}', '{adotante.DataNascimento}', '{adotante.Logradouro}', '{adotante.Numero}', '{adotante.CEP}', '{adotante.Bairro}', '{adotante.Complemento}', '{adotante.Cidade}', '{adotante.UF}','{adotante.Telefone}');";

                SqlCommand cmd = new SqlCommand(sql, conexaosql);
                cmd.ExecuteNonQuery();
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("CHIP JÁ CADASTRADO! Tente cadastrar novamente com outro valor!");
                Console.ReadKey();
            }
            conexaosql.Close();
        }

        //FUNCIONANDO OK - SE DER, TRATAR ERROS
        static void UpdateAdotante()
        {
            string sql;
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());


            Console.WriteLine("Informe o CPF do adotante que deseja editar o cadastro: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine(">>>EDITAR CADASTRO<<<");
            Console.WriteLine("0 - VOLTAR AO MENU ADOTANTE");
            Console.WriteLine("1 - Editar NOME");
            Console.WriteLine("2 - Editar SEXO");
            Console.WriteLine("3 - Editar DATA DE NASCIMENTO");
            Console.WriteLine("4 - Editar ENDEREÇO");
            Console.WriteLine("5 - Editar TELEFONE");
            Console.WriteLine("\nEscolha entre as opções: ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 0:
                    MenuAdotante();
                    break;
                case 1:
                    //FUNCIONANDO
                    conexaosql.Open();
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set Nome='{nome}' WHERE CPF='{cpf}';";
                    SqlCommand cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;

                case 2:
                    //FUNCIONANDO
                    conexaosql.Open();
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
                    //FUNCIONANDO
                    conexaosql.Open();
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
                    //FUNCIONANDO
                    conexaosql.Open();
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


                    Console.WriteLine("UF: [Ex: SP]");
                    string uf = Console.ReadLine();
                    sql = $"UPDATE dbo.Adotante set UF='{uf}' WHERE CPF='{cpf}';";
                    cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;

                case 5:
                    //FUNCIONANDO
                    conexaosql.Open();
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
                    conexaosql.Close();
                    break;

                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                    break;
            }
        }
        static void SelectAdotanteEspecifico()
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            Console.WriteLine(">>>Informe o CPF do adotante que deseja vizualizar o cadastro<<<: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\n");

            string sql = $"SELECT Nome, CPF, Sexo, DataNascimento, Logradouro, Numero, CEP, Bairro, Complemento, Cidade, UF, Telefone FROM dbo.Adotante WHERE CPF= '{cpf}';";
            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Nome: {reader.GetString(0)}");
                    Console.WriteLine($"CPF: {reader.GetString(1)}");
                    Console.WriteLine($"Sexo: {reader.GetString(2)}");
                    Console.WriteLine($"Data de Nascimento: {reader.GetDateTime(3).ToShortDateString()}");
                    Console.WriteLine($"Logradouro: {reader.GetString(4)}");
                    Console.WriteLine($"Numero: {reader.GetInt32(5)}");
                    Console.WriteLine($"CEP: {reader.GetInt32(6)}");
                    Console.WriteLine($"Bairro: {reader.GetString(7)}");
                    Console.WriteLine($"Complemento: {reader.GetString(8)}");
                    Console.WriteLine($"Cidade: {reader.GetString(9)}");
                    Console.WriteLine($"UF: {reader.GetString(10)}");
                    Console.WriteLine($"Telefone: {reader.GetString(11)}");
                }
            }
            Console.ReadKey();
            conexaosql.Close();
        }
        //ok
        static void InsertAnimal(Animal animal)
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            try
            {

                conexaosql.Open();

                string sql = $"INSERT INTO dbo.Animal (CHIP, Familia, Raca, Sexo, Nome) VALUES ('{animal.CHIP}', '{animal.Familia}', '{animal.Raca}', '{animal.Sexo}', '{animal.Nome}');";

                SqlCommand cmd = new SqlCommand(sql, conexaosql);
                cmd.ExecuteNonQuery();
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("CHIP JÁ CADASTRADO! Tente cadastrar novamente com outro valor!");
                Console.ReadKey();
            }
            conexaosql.Close();
        }
        static void UpdateAnimal()
        {
            string sql;
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());

            Console.WriteLine("Informe o numero do CHIP do animal que deseja editar o cadastro: ");
            string chip = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine(">>>EDITAR CADASTRO<<<");
            Console.WriteLine("0 - VOLTAR AO MENU ANIMAL");
            Console.WriteLine("1 - Editar NOME");
            Console.WriteLine("2 - Editar FAMILIA");
            Console.WriteLine("3 - Editar RAÇA");
            Console.WriteLine("4 - Editar SEXO");
            Console.WriteLine("Escolha entre as opções: ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 0:
                    MenuAnimal();
                    break;
                case 1:
                    conexaosql.Open();
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    sql = $"UPDATE dbo.Animal set Nome='{nome}' WHERE CHIP='{chip}';";
                    SqlCommand cmd = new SqlCommand(sql, conexaosql);
                    cmd.ExecuteNonQuery();
                    Console.ReadKey();
                    conexaosql.Close();
                    break;
                case 2:
                    conexaosql.Open();
                    string fam;
                    do
                    {
                        Console.WriteLine("Informe a Familia: [Ex: Gato, Cachorro]");
                        fam = Console.ReadLine();
                        if (fam.Length <= 0 && fam.Length > 50)
                        {
                            Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");
                        }
                        else
                        {
                            sql = $"UPDATE dbo.Animal set Familia='{fam}' WHERE CHIP='{chip}';";
                            cmd = new SqlCommand(sql, conexaosql);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            conexaosql.Close();
                        }
                    } while (fam.Length <= 0 && fam.Length > 50);
                    break;

                case 3:
                    conexaosql.Open();
                    string raca;
                    do
                    {
                        Console.WriteLine("Raça do animal: [Ex: Vira-Lata, Pitbull, ShihTzu]");
                        raca = Console.ReadLine();
                        if (raca.Length <= 0 && raca.Length > 20)
                        {
                            Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                        }
                        else
                        {
                            sql = $"UPDATE dbo.Animal set Raca='{raca}' WHERE CHIP='{chip}';";
                            cmd = new SqlCommand(sql, conexaosql);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            conexaosql.Close();

                        }
                    } while (raca.Length <= 0 && raca.Length > 20);
                    break;

                case 4:
                    conexaosql.Open();
                    char s;
                    do
                    {
                        Console.WriteLine("Informe o novo sexo: [M - Macho, F - Fêmea] : ");
                        s = char.Parse(Console.ReadLine().ToUpper());
                        if (s != 'M' && s != 'F')
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA! INFORME (M, F OU N) ");
                        }
                        else
                        {
                            sql = $"UPDATE dbo.Animal set Sexo='{s}' WHERE CHIP='{chip}';";
                            cmd = new SqlCommand(sql, conexaosql);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            conexaosql.Close();
                        }
                    } while (s != 'M' && s != 'F');
                    break;

                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA! Informe uma das opções segundo o menu!");
                    break;
            }
        }
        static void SelectAnimalEspecifico()
        {
            //Aqui voce pode vizualizar os animais Disponiveis (D) e os Adotados(A)
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            Console.WriteLine("Informe o CHIP do animal que deseja vizualizar o cadastro: ");
            string chip = Console.ReadLine();
            Console.WriteLine("\n");

            string sql = $"SELECT CHIP, Familia, Raca, Sexo, Nome FROM dbo.Animal WHERE CHIP= '{chip}';";
            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"CHIP: {reader.GetInt32(0)}");
                    Console.WriteLine($"Familia: {reader.GetString(1)}");
                    Console.WriteLine($"Raça: {reader.GetString(2)}");
                    Console.WriteLine($"Sexo: {reader.GetString(3)}");
                    Console.WriteLine($"Nome: {reader.GetString(4)}");
                }
            }
            Console.ReadKey();
            conexaosql.Close();

        }
        //Já adicionei o insert nessa função
        static void RealizarAdocao()
        {
            Console.WriteLine("----CADASTRO DE ADOÇÃO----");
            Console.WriteLine("Deseja realmente realizar uma adoção ? [1 - SIM, 2 - NÃO]");
            int escolha = int.Parse(Console.ReadLine());
            if (escolha == 1)
            {
                Console.WriteLine("Informe o CPF do adotante: ");
                string cpf = Console.ReadLine();
                Console.WriteLine("Informe o CHIP de identificação do animal que vai ser adotado: ");
                string chip = Console.ReadLine();
                Console.WriteLine("Confirmar adoção: [1 - SIM, 2 - Não]");
                int ad = int.Parse(Console.ReadLine());
                if (ad == 1)
                {
                    Banco conn = new Banco();
                    SqlConnection conexaosql = new SqlConnection(conn.Caminho());
                    try
                    {

                        conexaosql.Open();
                        string sql = $"INSERT INTO dbo.RegistroAdocao (CPF, CHIP, DataAdocao) VALUES ('{cpf}', '{chip}', '{DateTime.Now}');";
                        SqlCommand cmd = new SqlCommand(sql, conexaosql);
                        cmd.ExecuteNonQuery();
                        Console.ReadKey();
                    }
                    catch (SqlExeption)
                    {
                        Console.WriteLine("Erro! ");
                    }
                    conexaosql.Close();
                }
            }
            else
                MenuAdocao();
        }
        //ok
        static void SelectAdocao()
        {
            Console.WriteLine(">>>CONSULTAR REGISTRO DE ADOÇÕES<<<");
            Console.WriteLine("\n");
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT a.Nome, ra.CPF, ra.CHIP, m.Nome, m.Familia, m.Raca, m.Sexo, ra.DataAdocao FROM registroadocao ra, adotante a, animal m WHERE a.cpf = ra.cpf and m.chip = ra.chip; ";

            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Nome Tutor: {reader.GetString(0)}");
                    Console.WriteLine($"CPF Tutor: {reader.GetString(1)}");
                    Console.WriteLine($"CHIP Animal: {reader.GetInt32(2)}");
                    Console.WriteLine($"Nome Animal: {reader.GetString(3)}");
                    Console.WriteLine($"Familia Animal: {reader.GetString(4)}");
                    Console.WriteLine($"Raça Animal: {reader.GetString(5)}");
                    Console.WriteLine($"Sexo Animal: {reader.GetString(6)}");
                    Console.WriteLine($"Data de Adoção: {reader.GetDateTime(7).ToShortDateString()}");
                }
            }
            Console.ReadKey();
            conexaosql.Close();

        }
        //ok
        static void SelectAdocaoEspecifico()
        {
            Console.WriteLine(">>>CONSULTAR REGISTRO DE ADOÇÕES<<<");
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();
            Console.WriteLine("Informe o CPF do Tutor: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Informe o CHIP do animal que o Tutor adotou: ");
            string chip = Console.ReadLine();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT a.Nome, ra.CPF, ra.CHIP, m.Nome, m.Familia, m.Raca, m.Sexo, ra.DataAdocao FROM registroadocao ra, adotante a, animal m WHERE ra.CPF = @CPF AND ra.CHIP = @CHIP and a.cpf = ra.cpf and m.chip = ra.chip;";
            cmd.Connection = conexaosql;
            cmd.Parameters.AddWithValue("@CPF", cpf);
            cmd.Parameters.AddWithValue("@CHIP", chip);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Nome Tutor: {reader.GetString(0)}");
                    Console.WriteLine($"CPF Tutor: {reader.GetString(1)}");
                    Console.WriteLine($"CHIP Animal: {reader.GetInt32(2)}");
                    Console.WriteLine($"Nome Animal: {reader.GetString(3)}");
                    Console.WriteLine($"Familia Animal: {reader.GetString(4)}");
                    Console.WriteLine($"Raça Animal: {reader.GetString(5)}");
                    Console.WriteLine($"Sexo Animal: {reader.GetString(6)}");
                    Console.WriteLine($"Data de Adoção: {reader.GetDateTime(7).ToShortDateString()}");
                }
            }
            Console.ReadKey();
            conexaosql.Close();
        }
    }
}


