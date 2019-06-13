# RuffusValidator
RuffusValidator is a project written in the C # language to facilitate the validation of model classes in projects where they normally do not support or are not implemented using DataAnnotations or FluentValidations

Its deployment is easily possible on desktop projects like WindowsForms or WPF, plus some web application layer scenarios

```C#
    public class Cliente //Model Class
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Idade { get; set; }
        public string Apelido { get; set; }
    }
    
    public class ValidaNomeESobrenome : ISpecificValidator
    {   /*
          When we need to apply
          more complex validation rules,
          we can create a class that implements
          the ISpecificValidator interface that contains the
          bool method IsValid (object value), where
          parameter "value" is the value coming from
          of the class in which it is registered
          no ValidationDomain
         * */
        public bool IsValid(object value)
        {
            if (value.ToString().Split(' ').Length == 1)
                return false;

            return true;
        }
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
                c.Nome = "Naipe nove";


                Ruffus r = new Ruffus();
                r.Valid(c);

                Console.WriteLine("Cliente válido");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
