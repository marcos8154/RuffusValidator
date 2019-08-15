using System;

namespace RuffusValidator.Standard
{
    public class ValidaNomeESobrenome : ISpecificValidator
    {
        public bool IsValid(object value)
        {
            if (value.ToString().Split(' ').Length == 1)
                return false;

            return true;
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Idade { get; set; }
        public string Apelido { get; set; }
    }

    public class OutraClasse
    {
        public string Nome { get; set; }
    }

    class Program
    {
        static void Setup()
        {
            CoreValidator core = new CoreValidator();
            core.AddDomain(new ValidationDomain(typeof(Cliente))
                .NotNull("Nome", "O nome do cliente é obrigatório")
                .NotEmpty("Nome", "O nome do cliente é obrigatório")
                //     .MinLength("Nome", "O nome do cliente deve ter no minimo 5 caracteres", 5)
                .Min("Id", "A id deve ser no minimo 8", 8)
                .Max("Id", "A id deve ser no maximo 10", 10)
                .EspecificMethod("Nome", typeof(ValidaNomeESobrenome), "Nome e sobre nome é obrigatório"));
        }
        public static void Main(string[] args)
        {
            Setup();

            try
            {
                Cliente c = new Cliente();
                c.Id = 9;
                c.Nome = "";
                Ruffus r = new Ruffus();
                r.Valid(c);

                Console.WriteLine("Cliente válido");
            }
            catch (RuffusValidationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}