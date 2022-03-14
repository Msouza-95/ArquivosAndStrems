

namespace ArquivosAndStrems
{

    class Program
    {

        static void Main(string[] args)
        {

            var pathEntrada = Path.Combine(Environment.CurrentDirectory, "csv", "Entrada", "userExport.csv");

            var pathSaida = Path.Combine(Environment.CurrentDirectory, "csv", "Saida");

            Console.WriteLine("-----------------------");
            Console.WriteLine(" Escolha uma opção");
            Console.WriteLine(" 1 - Read csv");
            Console.WriteLine(" 2 - Write csv ");
            Console.WriteLine(" 3 -  ");
            Console.WriteLine(" 4 - o ");
            Console.WriteLine(" 0  - Finalizar ");
            Console.WriteLine("-----------------------");

            var file = new MyFiles();

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                throw new ArgumentException("A opção precisa ser um numero Inteiro");
            }

            var csv = new csvStream();

            switch (option)
            {

                case 1:

                    if (file.ExistFiles(pathEntrada))
                    {

                        csv.readFileCsv(pathEntrada);
                    }
                    break;

                case 2:


                    csv.WriteFileCsv(pathSaida);
                    break;

                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }

        }
    }
}