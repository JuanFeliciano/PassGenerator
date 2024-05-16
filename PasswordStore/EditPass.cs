using PasswordStore.SubFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class EditPass
    {
        public void Generatepassword(List<PasswordEntry> passwordEntries)
        {
            GenerateRandomPassword generaterandom = new();
            string? nameEntry = null;


            Console.WriteLine("Digite o nome da senha que deseja alterar: ");
            string? namePass = Console.ReadLine();

            if(string.IsNullOrEmpty(namePass))
            {
                Console.WriteLine("Senha inválida ou inexistente!");
                return;
            }

            var entry = passwordEntries.Find(pe => pe.Name == namePass);
            if (entry == null)
            {
                Console.WriteLine("Senha inválida ou inexistente!");
                return;
            }else
            {
                    nameEntry = entry.ToString();
            }

            Console.WriteLine("Digite o tamanho desejado para sua senha (Tamanho MAX = 50): ");
            if (!int.TryParse(Console.ReadLine(), out int lenght) || lenght <= 0 || lenght > 50)
            {
                switch(lenght)
                {
                    case <= 0:
                        Console.WriteLine("Digite um número maior que 0 e menor que 51");
                        return;
                    case > 50:
                        Console.WriteLine("Tamanho não pode ser maior que 50");
                        return;
                }
            }

            Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
            bool includeUpperCase = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Incluir letras minúsculas? (s/n): ");
            bool includeLowerCase = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Incluir caracteres especiais? (s/n): ");
            bool includeSpecialChars = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Incluir números? (s/n): ");
            bool includeNumbers = Console.ReadLine()!.ToLower() == "s";


            string password = generaterandom.GenerateRP(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);

            Console.WriteLine("Deseja manter o nome atual da sua senha? (s/n): ");
            bool nameEdited = Console.ReadLine()!.ToLower() == "s";

            switch(nameEdited)
            {
                case false:
                    passwordEntries.Remove(entry);
                    Console.WriteLine("Digite o novo nome: ");
                    string? newName = Console.ReadLine();
                    passwordEntries.Add(new PasswordEntry(newName!, password));
                    Console.WriteLine($"Senha atualizada: [Nome: {newName}][Senha: {password}]");
                    break;
                case true:
                    passwordEntries.Remove(entry);
                    passwordEntries.Add(new PasswordEntry(namePass, password));
                    Console.WriteLine($"Senha atualizada: {password}");
                    break;
            }
        }
    }
}

