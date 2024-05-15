using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class SearchPass
    { 
        public void Searchpassword(List<PasswordEntry> passwordEntries)
        {
            Console.WriteLine("Digite o nome da senha que deseja buscar: ");
            string? name = Console.ReadLine();

            var entry = passwordEntries.FirstOrDefault(pe => pe.Name == name);

            if (entry != null)
            {
                Console.WriteLine($"Senha encontrada: {entry.Password}");
            }
            else
            {
                Console.WriteLine("Nenhuma senha foi encontrada!");
            }
        }
    }
}
