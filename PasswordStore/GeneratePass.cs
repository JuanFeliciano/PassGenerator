using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class GeneratePass
    {
        public void Generatepassword(List<PasswordEntry> passwordEntries)
        {
            Console.WriteLine("Digite o tamanho desejado para sua senha: ");
            if (!int.TryParse(Console.ReadLine(), out int lenght) || lenght <= 0)
            {
                Console.WriteLine("Tamanho Inválido");
                return;
            }

            Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
            bool includeUpperCase = Console.ReadLine().ToLower() == "s" ? true : false;

            Console.WriteLine("Incluir letras minúsculas? (s/n): ");
            bool includeLowerCase = Console.ReadLine().ToLower() == "s" ? true : false;

            Console.WriteLine("Incluir caracteres especiais? (s/n): ");
            bool includeSpecialChars = Console.ReadLine().ToLower() == "s" ? true : false;

            Console.WriteLine("Incluir números? (s/n): ");
            bool includeNumbers = Console.ReadLine().ToLower() == "s" ? true : false;


            Console.WriteLine("Digite um nome para sua senha: ");
            string? namePass = Console.ReadLine();

            string password = GenerateRandomPassword(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
            passwordEntries.Add(new PasswordEntry(namePass, password));

            Console.WriteLine($"Senha Gerada: {password}");
        }


        private static string GenerateRandomPassword(int lenght, bool includeUpperCase, bool includeLowerCase, bool includeSpecialChars, bool includeNumbers)
        {

            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_-+=<>?";

            StringBuilder characterPool = new();

            if (includeUpperCase == true)
            {
                characterPool.Append(uppercase);
            }
            if (includeLowerCase == true)
            {
                characterPool.Append(lowercase);
            }
            if (includeSpecialChars == true)
            {
                characterPool.Append(specialChars);
            }
            if (includeNumbers == true)
            {
                characterPool.Append(numbers);
            }

            if (characterPool.Length == 0)
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
    }
}
