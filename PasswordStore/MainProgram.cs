using System.Reflection.PortableExecutable;
using System.Text;

namespace PasswordStore
{
    public class MainProgram
    {
        public static void Main()
        {
            SearchPass searchpassword = new();
            GeneratePass generatepassword = new();
            RemovePass removepassword = new();
            EditPass editpassword = new();
            CatchAll catchAllElements = new();
            List<PasswordEntry> passwordEntries = new();


            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1- Gerar uma nova senha");
                Console.WriteLine("2- Buscar uma senha (nome)");
                Console.WriteLine("3- Remover senha salva");
                Console.WriteLine("4- Editar");
                Console.WriteLine("5- Buscar todas as senhas");
                Console.WriteLine("6- Sair");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        generatepassword.Generatepassword(passwordEntries);
                        break;

                    case "2":
                        Console.Clear();
                        searchpassword.Searchpassword(passwordEntries);
                        break;

                    case "3":
                        Console.Clear();
                        removepassword.RemovePassword(passwordEntries);
                        break;

                    case "4":
                        Console.Clear();
                        editpassword.Generatepassword(passwordEntries);
                        break;

                    case "5":
                        Console.Clear();
                        catchAllElements.TakeElements(passwordEntries);
                        break;
                            
                    case "6":
                        Console.Clear();
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
}