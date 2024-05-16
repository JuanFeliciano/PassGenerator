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
            bool includeUpperCase = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Incluir letras minúsculas? (s/n): ");
            bool includeLowerCase = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Incluir caracteres especiais? (s/n): ");
            bool includeSpecialChars = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Incluir números? (s/n): ");
            bool includeNumbers = Console.ReadLine()!.ToLower() == "s";


            Console.WriteLine("Digite um nome para sua senha: ");
            string? namePass = Console.ReadLine();

            string password = generaterandom.GenerateRP(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
            passwordEntries.Add(new PasswordEntry(namePass!, password));

            Console.WriteLine($"Senha Gerada: {password}");
        }
    }
}
