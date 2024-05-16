using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class CatchAll
    {
        public void TakeElements(List<PasswordEntry> passwordEntries)
        {
            if (passwordEntries != null)
            {
                foreach (var entry in passwordEntries)
                {
                    if (entry != null)
                    {
                        Console.WriteLine($"Nome: {entry.Name} - Senha: {entry.Password}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não existem senhas armazenas");
            }
        }
    }
}
