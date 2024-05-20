using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class RemovePass
    {
        public void RemovePassword(List<PasswordEntry> passwordEntries)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o nome da senha que deseja remover: ");
            Console.ForegroundColor = ConsoleColor.White;
            string? name = Console.ReadLine()!.Trim();

            var entry = passwordEntries.Find(pe => pe.Name == name);

            if (entry is not null)
            {
                passwordEntries.Remove(entry);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha removida com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Não existe uma senha com esse nome");
            }
        }
    }
}
