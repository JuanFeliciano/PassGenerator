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

            if(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Forneça algum valor para busca!");
                return;
            }

            var matchingEntries = passwordEntries.Where(pe => pe.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (matchingEntries.Any())
            {
                foreach(var entry in matchingEntries)
                {

                Console.WriteLine($"Senha encontrada: {entry.Name} = {entry.Password}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma senha foi encontrada!");
            }
        }
    }
}
