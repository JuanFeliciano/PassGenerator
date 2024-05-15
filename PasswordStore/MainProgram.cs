using PasswordStore;
using System.Reflection.PortableExecutable;
using System.Text;

public class MainProgram
{
    public static void Main(string[] args)
    {
        SearchPass searchpassword = new();
        GeneratePass generatepassword = new();
        RemovePass removepassword = new();
        List<PasswordEntry> passwordEntries = new();    
        
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1- Gerar uma nova senha");
            Console.WriteLine("2- Buscar uma senha");
            Console.WriteLine("3- Remover senha salva");
            Console.WriteLine("4- Editar");
            Console.WriteLine("5- Sair");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    generatepassword.Generatepassword(passwordEntries);
                    break;

                case "2":
                    searchpassword.Searchpassword(passwordEntries);
                    break;

                    case "3":
                    removepassword.RemovePassword(passwordEntries);
                    break;

                case "4":
                    break;

                case "5":
                    Console.WriteLine("Saindo do programa!");
                    return;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;

            }
        }
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

