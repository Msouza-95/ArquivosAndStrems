namespace ArquivosAndStrems
{
    public class Person
    {
        public Person(string nome, string email, long telefone)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;

        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
    }
}