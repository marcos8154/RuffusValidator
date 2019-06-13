# RuffusValidator
C# framework for model validation

```C#
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
