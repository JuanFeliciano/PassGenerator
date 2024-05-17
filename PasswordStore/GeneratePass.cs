using PasswordStore.SubFunction;
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
            GenerateRandomPassword generaterandom = new();

            Console.WriteLine("Digite o tamanho desejado para sua senha (Tamanho MAX = 50): ");
            Console.ForegroundColor = ConsoleColor.White;
            if (!int.TryParse(Console.ReadLine()!.Trim(), out int lenght) || lenght <= 0 || lenght > 50)
            {
                switch(lenght)
                {
                    case <= 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tamanho Inválido");
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case > 50:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Tamanho não pode ser maior que 50");
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }
                return;
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
            Console.ForegroundColor = ConsoleColor.Red;

            var a = true;

            while(a)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Digite um nome para sua senha: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string? namePass = Console.ReadLine()!.Trim();

                if (namePass == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Digite um valor válido;");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    var existName = passwordEntries.Any(pe => pe.Name.Equals(namePass!, StringComparison.OrdinalIgnoreCase));

                    if (existName)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Já existe uma senha com este nome, por favor escolha outro: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        string password = generaterandom.GenerateRP(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
                        passwordEntries.Add(new PasswordEntry(namePass!, password));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Senha Gerada: {password}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        a = false;
                    }
                }
            }
        }
    }
}
