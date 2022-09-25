using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG
{
    internal class Animal
    {
        public int CHIP { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public char Situacao { get; set; }


        public Animal()
        {

        }
        public Animal(int chip, string familia, string raca, char sexo, string nome, char situacao)
        {
            this.CHIP = chip;
            this.Familia = familia;
            this.Raca = raca;
            this.Sexo = sexo;
            this.Nome = nome;
            this.Situacao = situacao;
        }

        public void CadastrarAnimal()
        {
            Console.WriteLine("Numero do CHIP de identificação do animal: ");
            CHIP = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("A qual Familia o animal pertence: [Ex: Gato, Cachorro]");
                Familia = Console.ReadLine();
                if (Familia.Length > 50)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Familia.Length > 50);

            do
            {
                Console.WriteLine("Raça do animal: [Ex: Vira-Lata, Pitbull, ShihTzu]");
                Raca = Console.ReadLine();
                if (Raca.Length > 20)
                {
                    Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                }
            } while (Raca.Length > 20);

            do
            {
                Console.WriteLine("Sexo do animal : [M - Macho, F - Fêmea] : ");
                Sexo = char.Parse(Console.ReadLine().ToUpper());
                if (Sexo != 'M' && Sexo != 'F')
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA! INFORME [M ou F] ");
                }
            } while (Sexo != 'M' && Sexo != 'F');
            Console.WriteLine("Animal já possui um nome? [1 - SIM, 2 - NÃO]");
            int op = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                do
                {
                    Console.WriteLine("Nome do animal: ");
                    Nome = Console.ReadLine();
                    if (Nome.Length > 50)
                    {
                        Console.WriteLine("\nIMPOSSÍVEL CADASTRAR! \nTENTE NOVAMENTE!");

                    }
                } while (Nome.Length > 50);

            }
            else
                Nome = "--";
            Situacao = 'D'; //D - DISPONIVEL P/ ADOÇÃO           

        }
        
    }
}
