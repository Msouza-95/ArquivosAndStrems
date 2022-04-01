
using CsvHelper.Configuration;

namespace ArquivosAndStrems{
public class ProdutoMap : ClassMap<Produto>
{
    public ProdutoMap()
    {
        Map(x => x.Nome).Name("Nome");
        Map(x => x.Preco).Name("Preco");
        Map(x => x.Marca).Name("Marca");

    }
}


}
