
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

namespace ArquivosAndStrems;

public class MyCsvHelper
{

    public void readCsv(string path)
    {

        var fi = new FileInfo(path);

        if (!fi.Exists)
        {
            throw new FileNotFoundException($"o arquivo {path} não Existe");
            }

        using var sr = new StreamReader(fi.FullName);

        var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture){
        Delimiter = ","
        };

        using var csvReader = new CsvReader(sr, csvConfig);

       
        // NO lugar do dynamic pode ser passado uma classe para maper de acordo com os seus artibutos 
        var registros = csvReader.GetRecords<dynamic>();

        foreach (var registro in registros)
        {

            Console.WriteLine("----------------------------");
            Console.WriteLine($"nome:{registro.Nome}");
            Console.WriteLine($"marca:{registro.Marca}");
            Console.WriteLine($"preço:{registro.Preco}");
            Console.WriteLine("----------------------------");
        }

    }
}
