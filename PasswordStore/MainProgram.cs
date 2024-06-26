﻿using PasswordStore.Generator;

namespace PasswordStore
{
    public class MainProgram
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            IUserInput userInput = new UserInput();
            SearchPassword searchpassword = new();
            GenerateRandom passwordGenerator = new();
            GeneratePassword generatepassword = new(passwordGenerator, userInput);
            RemovePassword removepassword = new();
            ChangePassword editpassword = new();
            CatchPassword takeelements = new();


            while (true)
            {
                ShowMenu();
                Console.ForegroundColor = ConsoleColor.White;
                var option = Console.ReadLine()!.Trim();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        generatepassword.Generate();
                        break;

                    case "2":
                        Console.Clear();
                        searchpassword.Searchpassword();
                        break;

                    case "3":
                        Console.Clear();
                        removepassword.DeletePassword();
                        break;

                    case "4":
                        Console.Clear();
                        editpassword.EditPassword();
                        break;

                    case "5":
                        Console.Clear();
                        takeelements.PickPassword();
                        break;
                            
                    case "6":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Saindo do programa");
                        return;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Opção inválida");
                        break;

                }
            }
        }
        private static void ShowMenu()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Escolha uma opção:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1- Gerar uma nova senha;");
            Console.WriteLine("2- Buscar uma senha;");
            Console.WriteLine("3- Remover senha salva;");
            Console.WriteLine("4- Editar senha;");
            Console.WriteLine("5- Buscar todas as senhas;");
            Console.WriteLine("6- Sair;");
        }
    }
}