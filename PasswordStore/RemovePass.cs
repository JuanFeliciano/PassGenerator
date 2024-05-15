﻿using System;
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
            Console.WriteLine("Digite o nome da senha que deseja remover: ");
            string? name = Console.ReadLine();

            var entry = passwordEntries.FirstOrDefault(pe => pe.Name == name);

            if (entry is not null)
            {
                passwordEntries.Remove(entry);
            }
            else
            {
                Console.WriteLine("Não existe uma senha com esse nome");
            }

            Console.WriteLine("Senha removida com sucesso!");
        }
    }
}
