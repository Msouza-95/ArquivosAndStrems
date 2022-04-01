using CsvHelper.Configuration;

namespace ArquivosAndStrems.src.Mapping{


    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Map(x => x.Nome).Name("Nome");
            Map(x => x.Email).Name("Email");
            Map(x => x.Telefone).Name("Telefone");

        }
    }

}



