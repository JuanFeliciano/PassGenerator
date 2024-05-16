using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class GetAll
    {
        public void SearchPass(List<PasswordEntry> passwordEntries)
        {
            foreach (var entry in passwordEntries) {
                Console.WriteLine($"Nome: {entry.Name} - Senha: {entry.Password}");
            }
        }
    }
}
