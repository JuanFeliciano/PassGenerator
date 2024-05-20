using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore.SubFunction
{
    internal class ChangeName
    {
        public void ChangeNamePass(List<PasswordEntry> passwordEntries)
        {
            var validName = true;
            while(validName == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite o nome da senha que deseja alterar: ");
                Console.ForegroundColor = ConsoleColor.White;
                string name = Console.ReadLine()!.Trim();

                if (!string.IsNullOrEmpty(name))
                {
                    if(passwordEntries.Count != 0)
                    {
                        var entry = passwordEntries.Find(pe => pe.Name == name);
                        var entryPass = passwordEntries.Find(pe => pe.Password == entry!.Password)!.ToString();

                        var namesExist = passwordEntries.Any(pe => pe.Name.Equals(name!, StringComparison.OrdinalIgnoreCase));

                        validName = false;
                        if (namesExist)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Digite o novo nome: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string newName = Console.ReadLine()!.ToLower().Trim();

                            passwordEntries.Remove(entry!);
                            passwordEntries.Add(new PasswordEntry(newName, entryPass!));
                        }
                        validName = false;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Não existem itens na lista");
                        return;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Digite algum valor válido");
                }

            }
        }
    }
}
