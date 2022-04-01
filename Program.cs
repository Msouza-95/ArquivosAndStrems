

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
            Console.WriteLine(" 3 - Create and Write arquivo .txt ");
            Console.WriteLine(" 4 - Read arquivo .txt and show details ");
            Console.WriteLine(" 5 - Create dir ");
            Console.WriteLine(" 6 - Listen dir");
            Console.WriteLine(" 7 - read with csvHelper");
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

                case 3:
                    file.CreateFile();
                    break;
                case 4:
                    var pathRead = Path.Combine(Environment.CurrentDirectory);
                    file.ReadFile(pathRead); 
                    break;
                 case 5:
                    file.CreateDirectory(); 
                    break;
                case 6:
                    var pathListen = Path.Combine(Environment.CurrentDirectory);
                    file.Watcher(pathListen); 
                    break;
                case 7:
                    var patHelper =Path.Combine(Environment.CurrentDirectory, "csv", "Entrada", "Produtos.csv");
                    var myCsvHelper = new MyCsvHelper();
                    myCsvHelper.readCsv(patHelper);
                    break ;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }

        }
    }
}