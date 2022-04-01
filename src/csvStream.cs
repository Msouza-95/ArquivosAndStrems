using static System.Console;

namespace ArquivosAndStrems
{
    public class csvStream
    {
        public csvStream()
        {

        }
        public void readFileCsv(string path)
        {

            using var sr = new StreamReader(path);

            var header = sr.ReadLine()?.Split(',');

            while (true)
            {
                var registry = sr.ReadLine()?.Split(',');

                if (registry == null)
                    break;

                for (int i = 0; i < registry.Length; i++)
                {
                    WriteLine($"{header?[i]}:{registry[i]}");
                }

                WriteLine("-----------------");

            }


            WriteLine("\n\n Digite [Enter] para Terminar");

        }


        public void WriteFileCsv(string path)
        {

            var dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                dir.Create();
                path = Path.Combine(path, "User.csv");
            }


            using var sw = new StreamWriter(path);

            sw.WriteLine("nome,email,telefone");

            var people = new List<Person>(){
               {new Person("matheus Santos", "ms@gmail.com", 39829834)},
               {new Person("Eduardo Barroca", "ed@gmail.com", 39829834)},
               {new Person("Luan Mais", "lm@gmail.com", 39829834)},
               {new Person("Juca Silva", "js@gmail.com", 39829834)},
           };

            foreach (var item in people)
            {

                var linha = $"{item.Nome},{item.Email},{item.Telefone}";
                sw.WriteLine(linha);
            }

        }



    }
}