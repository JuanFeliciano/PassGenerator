using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class CatchAll
    {
        public void TakeElements(List<PasswordEntry> passwordEntries)
        {
            if (passwordEntries.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var entry in passwordEntries)
                Console.WriteLine($"Nome: {entry.Name} - Senha: {entry.Password}");
                Console.ForegroundColor = ConsoleColor.Red;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha inexistente;");
                Console.ForegroundColor = ConsoleColor.Red;

            }
        }
    }
}

