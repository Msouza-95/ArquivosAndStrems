namespace ArquivosAndStrems
{
    using System.Text;
    public class MyStringReader
    {

        public void StringBuffer(string[] args){


            var sb = new StringBuilder();

            sb.AppendLine("Caracteres na primeia linha de leitura");
            sb.AppendLine("e a segunda linha de leitura");
            sb.AppendLine("é o fim");

            using var sr = new StringReader(sb.ToString()); 
            var buffer = new char[10];
            var tamnaho = 0;

            do {

                 buffer = new char[10];

                tamnaho = sr.Read(buffer);

                Console.WriteLine(string.Join("", buffer));

            }while(tamnaho >= buffer.Length);

            Console.WriteLine("Digite [enter] para finalizar");
            Console.ReadLine();
        }
        
    }
}