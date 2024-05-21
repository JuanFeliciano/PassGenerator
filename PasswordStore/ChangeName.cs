using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class ChangeName
    {
        public void NamePassword(List<PasswordEntry> passwordEntries)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o nome da senha que deseja alterar o nome: ");
            Console.ForegroundColor = ConsoleColor.White;
            var nameEntry = Console.ReadLine()!.Trim();

            var storedName = passwordEntries.Find(pe => pe.Name.Equals(nameEntry));
            if (storedName != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite o novo nome que deseja para sua senha: ");
                Console.ForegroundColor = ConsoleColor.White;
                string newName = Console.ReadLine()!.Trim();

                passwordEntries.Remove(storedName);
                passwordEntries.Add(new PasswordEntry(newName, storedName.Password));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Nome Atualizado: {newName}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Não existe nenhuma senha com este mesmo nome!");
            }

        }
    }
}
    