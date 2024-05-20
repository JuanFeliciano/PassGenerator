using PasswordStore.SubFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal class EditPass
    {
        public void Generatepassword(List<PasswordEntry> passwordEntries)
        {
            ChangeName changename = new();
            GenerateRandomPassword generaterandom = new();
            string? nameEntry = null;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Primeiramente, você deseja alterar o nome ou o valor da senha? (s = Valor / n = Nome)");
            Console.ForegroundColor = ConsoleColor.White;
            bool ask = Console.ReadLine()!.ToLower().Trim() == "s";

            if (ask)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite o nome da senha que deseja alterar: ");
                Console.ForegroundColor = ConsoleColor.White;
                string? namePass = Console.ReadLine()!.Trim();

                if (string.IsNullOrEmpty(namePass))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Senha inválida ou inexistente;");
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                }

                var entry = passwordEntries.Find(pe => pe.Name == namePass);
                if (entry == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Senha inválida ou inexistente;");
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                }
                else
                {
                    nameEntry = entry.ToString();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite o tamanho desejado para sua senha (Tamanho MAX = 50): ");
                Console.ForegroundColor = ConsoleColor.White;
                if (!int.TryParse(Console.ReadLine()!.Trim(), out int lenght) || lenght <= 0 || lenght > 50)
                {
                    switch (lenght)
                    {
                        case <= 0:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Tamanho inválido;");
                            Console.ForegroundColor = ConsoleColor.Red;
                            return;
                        case > 50:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Tamanho inválido;");
                            Console.ForegroundColor = ConsoleColor.Red;
                            return;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Incluir letras maiúsculas? (s/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                bool includeUpperCase = Console.ReadLine()!.ToLower().Trim() == "s";
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Incluir letras minúsculas? (s/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                bool includeLowerCase = Console.ReadLine()!.ToLower().Trim() == "s";
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Incluir caracteres especiais? (s/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                bool includeSpecialChars = Console.ReadLine()!.ToLower().Trim() == "s";
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Incluir números? (s/n): ");
                Console.ForegroundColor = ConsoleColor.White;
                bool includeNumbers = Console.ReadLine()!.ToLower().Trim() == "s";
                Console.ForegroundColor = ConsoleColor.Red;


                string password = generaterandom.GenerateRP(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
                passwordEntries.Remove(entry);
                passwordEntries.Add(new PasswordEntry(namePass, password));
                Console.WriteLine($"Senha atualizada: {password}");
            } else
            {
                changename.ChangeNamePass(passwordEntries);
            }
        }
    }
}

