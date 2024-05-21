using PasswordStore.SubFunction;
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
            GenerateRandomPassword generaterandom = new();
            string? nameEntry = null;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o nome da senha que deseja alterar: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string? namePass = Console.ReadLine()!.Trim();

            if(string.IsNullOrEmpty(namePass))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha inválida ou inexistente;");
                Console.ForegroundColor = ConsoleColor.Red;
                return;
            }

            var entry = passwordEntries.Find(pe => pe.Name == namePass);
            if (entry == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha inválida ou inexistente;");
                Console.ForegroundColor = ConsoleColor.Red;
                return;
            }else
            {
                    nameEntry = entry.ToString();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o tamanho desejado para sua senha (Tamanho MAX = 50): ");
            if (!int.TryParse(Console.ReadLine()!.Trim(), out int lenght) || lenght <= 0 || lenght > 50)
            {
                switch(lenght)
                {
                    case <= 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tamanho inválido;");
                        Console.ForegroundColor = ConsoleColor.Red;
                        return;
                    case > 50:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tamanho inválido;");
                        Console.ForegroundColor = ConsoleColor.Red;
                        return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
            bool includeUpperCase = Console.ReadLine()!.ToLower().Trim() == "s";

            Console.WriteLine("Incluir letras minúsculas? (s/n): ");
            bool includeLowerCase = Console.ReadLine()!.ToLower().Trim() == "s";

            Console.WriteLine("Incluir caracteres especiais? (s/n): ");
            bool includeSpecialChars = Console.ReadLine()!.ToLower().Trim() == "s";

            Console.WriteLine("Incluir números? (s/n): ");
            bool includeNumbers = Console.ReadLine()!.ToLower().Trim() == "s";


            string password = generaterandom.Generate(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);

            Console.WriteLine("Deseja manter o nome atual da sua senha? (s/n): ");
            bool nameEdited = Console.ReadLine()!.ToLower().Trim() == "s";

            switch(nameEdited)
            {
                case false:
                    passwordEntries.Remove(entry);
                    Console.WriteLine("Digite o novo nome: ");
                    string? newName = Console.ReadLine()!.Trim();
                    passwordEntries.Add(new PasswordEntry(newName!, password));
                    Console.WriteLine($"Senha atualizada: [Nome: {newName}][Senha: {password}]");
                    break;
                case true:
                    passwordEntries.Remove(entry);
                    passwordEntries.Add(new PasswordEntry(namePass, password));
                    Console.WriteLine($"Senha atualizada: {password}");
                    break;
            }
        }
    }
}

