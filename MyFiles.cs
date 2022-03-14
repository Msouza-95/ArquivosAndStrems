namespace ArquivosAndStrems;
using static System.Console;

class MyFiles
{


    public bool ExistFiles(string path)
    {

        if (File.Exists(path))
            return true;
        else
            Console.WriteLine("Arquivo Não existe digiter [enter] para finalizar");
        Console.ReadLine();
        return false;
    }

    public void demoCreateFile()
    {

        WriteLine("Digite o nome do arquivo");

        var name = ReadLine();
        if (name != null)
        {

            name = this.ClearName(name);

            var path = Path.Combine(Environment.CurrentDirectory, $"{name}.txt");
            // ou sddim : var path = Path.Combine(@"C:/" ,"teste.txt" );


        }
        else
        {

            WriteFile("você deixou o campo em branco");
        }




    }


    public string ClearName(string name)
    {
        foreach (var @char in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(@char, '-');
        }
        return name;

    }

    public void WriteFile(string path)
    {
        try
        {
            var sw = File.CreateText(path);
            sw.WriteLine(" gerando a primeria linha do arquivo");
            sw.WriteLine(" gerando a segunda linha do arquivo");
            sw.Flush(); // para poder salvar o texto no arquivo

        }
        catch
        {

            WriteFile(" O nome do arquivo esta invalido");

        }

    }


    public void demoCreateDirectory()
    {

        var path = Path.Combine(Environment.CurrentDirectory, "globo");

        if (!Directory.Exists(path))
        {
            var dirGlobo = Directory.CreateDirectory(path);

            var dirAmericaNorte = dirGlobo.CreateSubdirectory("America do norte");
            var dirAmericaSul = dirGlobo.CreateSubdirectory("America do Sul");
            var dirAmericaCentral = dirGlobo.CreateSubdirectory("America Central");

            dirAmericaNorte.CreateSubdirectory("USA");
            dirAmericaNorte.CreateSubdirectory("Mexico");
            dirAmericaNorte.CreateSubdirectory("Canada");

            dirAmericaCentral.CreateSubdirectory("Costa Rica");
            dirAmericaCentral.CreateSubdirectory("Panama");

            dirAmericaSul.CreateSubdirectory("Brasil");
            dirAmericaSul.CreateSubdirectory("Argentina");
            dirAmericaSul.CreateSubdirectory("Paraguai");




        }

        this.createFileBrasil();





    }

    public void createFileBrasil()
    {

        var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");

        if (!File.Exists(path))
        {

            using var sw = File.CreateText(path);

            sw.WriteLine("população: 213MM");
            sw.WriteLine("IDH: 0,902");
            sw.WriteLine("Dados Atulizados em: 13/03;2022");
        }

    }

    public void validPathOrigeAndDist(string pathOrige, string pathDist)
    {

        if (!File.Exists(pathOrige))
        {
            Console.WriteLine("Arquivo de origem não existe");
            return;
        }

        if (File.Exists(pathDist))
        {
            WriteLine("Arquivo já existe na pasta de destini");

            return;
        }
    }

    public void MoveFile(string pathOrige, string pathDist)
    {

        this.validPathOrigeAndDist(pathOrige, pathDist);


        File.Move(pathOrige, pathDist);

    }

    public void CopyFile(string pathOrige, string pathDist)
    {

        validPathOrigeAndDist(pathOrige, pathDist);

        File.Copy(pathOrige, pathDist);
    }

    public void readDirectory(string path)
    {


        if (Directory.Exists(path))
        {
            var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            foreach (var dir in diretorios)
            {
                var dirInfo = new DirectoryInfo(dir);
                Console.WriteLine($"[Nome]:{dirInfo.Name}");
                Console.WriteLine($"[raiz]:{dirInfo.Root}");

                if (dirInfo.Parent != null)
                    Console.WriteLine($"[pai]:{dirInfo.Parent.Name}");

                WriteLine("----------------------------------");
            }

        }
        else
        {
            WriteLine($"{path} não existe");
        }


    }



    public void ReadFile(string path)
    {



        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var fileInfo = new FileInfo(file);

            Console.WriteLine($"[Name]:{fileInfo.Name}");
            Console.WriteLine($"[tamanho]:{fileInfo.Length}");
            Console.WriteLine($"[Ultimo acesso ]:{fileInfo.LastAccessTime}");
            Console.WriteLine($"[Pasta]:{fileInfo.DirectoryName}");
            Console.WriteLine($"-------------------");
        }
    }

    static void Watcher(string path)
    {

        using var fsw = new FileSystemWatcher(path);

        fsw.Created += OnCreated;
        fsw.Deleted += OnDelete;
        fsw.Renamed += OnRenamed;

        fsw.EnableRaisingEvents = true; // habiliat para escutar os eventos;
        fsw.IncludeSubdirectories = true;

        Console.ReadLine();


        void OnRenamed(object sender, FileSystemEventArgs e)
        {

            WriteLine($" o arquivo{e.Name} foi renomeado para {e.Name}");
        }

        void OnDelete(object sender, FileSystemEventArgs e)
        {
            WriteLine($" Foi Excluido o arquivo{e.Name}");
        }

        void OnCreated(object sender, FileSystemEventArgs e)
        {
            WriteLine($" Foi criado o arquivo{e.Name}");

        }

    }



}








//demoCreateDirectory();

// var pathOrige = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
// var pathDist = Path.Combine(Environment.CurrentDirectory, "globo", "America do Sul", "Brasil", "brasil.txt");

//MoveFile(pathOrige, pathDist);



//var path2 = @"D:\Projetos\DIO\aulas\dotnet\ArquivosAndStrems\globo";

//readDirectory(path2);

// var path3 = @"D:\Projetos\DIO\aulas\dotnet\ArquivosAndStrems";

//ReadFile(path3);






// WriteLine("Estamos escutando:");
// Watcher(path2);
