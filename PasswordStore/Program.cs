using System.Reflection.PortableExecutable;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        List<PasswordEntry> passwordEntries = new();    
        
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1- Gerar uma nova senha");
            Console.WriteLine("2- Buscar uma senha");
            Console.WriteLine("3- Remover senha salva");
            Console.WriteLine("4- Sair");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    GeneratePassword(passwordEntries);
                    break;

                case "2":
                    SearchPassword(passwordEntries);
                    break;

                    case "3":
                    RemovePassword(passwordEntries);
                    break;

                case "4":
                    Console.WriteLine("Saindo do programa!");
                    return;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;

            }
        }
    }

    private static void GeneratePassword(List<PasswordEntry> passwordEntries)
    {
        Console.WriteLine("Digite o tamanho desejado para sua senha: ");
        if (!int.TryParse(Console.ReadLine(), out int lenght) || lenght <= 0)
        {
            Console.WriteLine("Tamanho Inválido");
            return;
        }

        Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
        bool includeUpperCase = Console.ReadLine().ToLower() == "s";

        Console.WriteLine("Incluir letras minúsculas? (s/n): ");
        bool includeLowerCase = Console.ReadLine().ToLower() == "s";

        Console.WriteLine("Incluir carcteres especiais? (s/n): ");
        bool includeSpecialChars = Console.ReadLine().ToLower() == "s";

        Console.WriteLine("Incluir números? (s/n): ");
        bool includeNumbers = Console.ReadLine().ToLower() == "s";


        Console.WriteLine("Digite um nome para sua senha: ");
        string? namePass = Console.ReadLine();

        string password = GenerateRandomPassword(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
        passwordEntries.Add(new PasswordEntry(namePass, password));

        Console.WriteLine($"Senha Gerada: {password}");
    }

    private static void SearchPassword(List<PasswordEntry> passwordEntries)
    {
        Console.WriteLine("Digite o nome da senha que deseja buscar: ");
        string? name = Console.ReadLine();

        var entry = passwordEntries.FirstOrDefault(pe => pe.Name == name);

        if(entry != null)
        {
            Console.WriteLine($"Senha encontrada: {entry.Password}");
        } else
        {
            Console.WriteLine("Nenhuma senha foi encontrada!");
        }
    }

    private static string GenerateRandomPassword(int lenght, bool includeUpperCase, bool includeLowerCase, bool includeNumbers, bool includeSpecialChars)
    {

        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";
        const string specialChars = "!@#$%^&*()_-+=<>?";

        StringBuilder characterPool = new();  

        if(includeUpperCase == true)
        {
            characterPool.Append(uppercase);
        }
        if(includeLowerCase == true)
        {
            characterPool.Append(lowercase);
        }
        if(includeNumbers == true)
        {
            characterPool.Append(numbers);
        }
        if(includeSpecialChars == true)
        {
            characterPool.Append(specialChars);
        }

        if(characterPool.Length == 0)
        {
            Console.WriteLine("Nenhuma categoria de caracteres selecionado!");
        }

        StringBuilder password = new();
        Random random = new();

        for (int i = 0; i < lenght; i++)
        {
            int index = random.Next(characterPool.Length);
            password.Append(characterPool[index]);
        }

        return password.ToString();
    }




    private static void RemovePassword(List<PasswordEntry> passwordEntries)
    {
        Console.WriteLine("Digite o nome da senha que deseja remover: ");
        string? name = Console.ReadLine();

        var entry = passwordEntries.FirstOrDefault(pe => pe.Name == name);

        if(entry is not null)
        {
            passwordEntries.Remove(entry);
        } else
        {
            Console.WriteLine("Não existe uma senha com esse nome");
        }

        Console.WriteLine("Senha removida com sucesso!");
    }

}

public class PasswordEntry
{
    public string Name { get; }
    public string Password { get; }

    public PasswordEntry(string name, string password)
    {
        Name = name;
        Password = password;
    }
}

