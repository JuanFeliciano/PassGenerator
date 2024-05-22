using PasswordStore.SubFunction;

namespace PasswordStore.EditChange
{
    internal class ChangeValue
    {
        public void ChangePassword()
        {
            GenerateRandom generaterandom = new();
            string? nameEntry = null;


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o nome da senha que deseja alterar o valor: ");
            Console.ForegroundColor = ConsoleColor.White;
            string? namePass = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(namePass))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha inválida ou inexistente;");
                return;
            }

            var entry = PasswordEntry.passwordEntries.Find(pe => pe.Name == namePass);
            if (entry == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha inválida ou inexistente;");
                return;
            }
            else
            {
                nameEntry = entry.ToString();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o tamanho desejado para sua senha (MAX = 50): ");
            Console.ForegroundColor = ConsoleColor.White;
            if (!int.TryParse(Console.ReadLine()!.Trim(), out int lenght) || lenght <= 0 || lenght > 50)
            {
                switch (lenght)
                {
                    case <= 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tamanho inválido;");
                        return;
                    case > 50:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tamanho inválido;");
                        return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
            Console.ForegroundColor = ConsoleColor.White;
            bool includeUpperCase = Console.ReadLine()!.ToLower().Trim() == "s";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incluir letras minúsculas? (s/n): ");
            Console.ForegroundColor = ConsoleColor.White;
            bool includeLowerCase = Console.ReadLine()!.ToLower().Trim() == "s";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incluir caracteres especiais? (s/n): ");
            Console.ForegroundColor = ConsoleColor.White;
            bool includeSpecialChars = Console.ReadLine()!.ToLower().Trim() == "s";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incluir números? (s/n): ");
            Console.ForegroundColor = ConsoleColor.White;
            bool includeNumbers = Console.ReadLine()!.ToLower().Trim() == "s";


            string password = generaterandom.Generate(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);

            PasswordEntry.passwordEntries.Remove(entry);
            PasswordEntry.passwordEntries.Add(new PasswordEntry(namePass, password));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Senha atualizada: {password}");

        }

    }

}
