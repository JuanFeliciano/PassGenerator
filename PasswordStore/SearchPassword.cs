using System;
using System.Collections.Generic;
using System.Linq;
namespace PasswordStore
{
    internal class SearchPassword
    {
        public void Searchpassword()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o nome da senha que deseja buscar: ");
            Console.ForegroundColor = ConsoleColor.White;
            string? name = Console.ReadLine()!.Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Forneça algum valor para busca!");
                return;
            }

            var matchingEntries = PasswordEntry.passwordEntries.Where(pe => pe.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (matchingEntries.Any())
            {
                foreach (var entry in matchingEntries)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Senha encontrada: {entry.Name} = {entry.Password}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhuma senha foi encontrada!");
            }
        }
    }
}