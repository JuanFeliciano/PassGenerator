using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class EditPass
    {
        public void Generatepassword(List<PasswordEntry> passwordEntries)
        {
            Console.WriteLine("Digite o nome da senha que deseja alterar: ");
            string? namePass = Console.ReadLine();

            var entry = passwordEntries.FirstOrDefault(pe => pe.Name == namePass);
            string nameEntry = entry.ToString();

            Console.WriteLine("Digite o tamanho desejado para sua senha (Tamanho MAX = 50): ");
            if (!int.TryParse(Console.ReadLine(), out int lenght) || lenght <= 0 || lenght > 50)
            {
                switch(lenght)
                {
                    case <= 0:
                        Console.WriteLine("Tamanho Inválido");
                            break;
                    case > 50:
                            Console.WriteLine("Tamanho não pode ser maior que 50");
                            break;
                }
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


            string password = GenerateRandomPassword(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);

            Console.WriteLine("Deseja manter o nome atual da sua senha? (s/n): ");
            bool nameEdited = Console.ReadLine().ToLower() == "s" ? true : false;

            switch(nameEdited)
            {
                case false:
                    passwordEntries.Remove(entry);
                    Console.WriteLine("Digite o novo nome: ");
                    string? newName = Console.ReadLine();
                    passwordEntries.Add(new PasswordEntry(newName, password));
                    break;
                case true:
                    passwordEntries.Remove(entry);
                    passwordEntries.Add(new PasswordEntry(nameEntry, password));
                    break;
            }

            Console.WriteLine($"Senha atualizada: {password}");
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

