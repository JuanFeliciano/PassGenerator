using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    public class UserInput : IUserInput
    {
        public int GetPasswordLenght()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o tamanho desejado para sua senha (Tamanho MAX = 50): ");
            Console.ForegroundColor = ConsoleColor.White;
            if (!int.TryParse(Console.ReadLine()!.Trim(), out int length) || length <= 0 || length > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(length <= 0 ? "Tamanho Inválido" : "Tamanho não pode ser maior que 50");
                return -1;
            }
            return length;
        }

        public bool GetYesOrNoInput(string message)
        {
            bool result = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine()!.ToLower().Trim();

            switch(option)
            {
                case "s":
                    result = true; 
                    break;
                case "n":
                    result = false; 
                    break;
                default:
                    Console.WriteLine("Escolha uma opção válida: ");
                    break;

            }

            return result;
        }

        public string GetPasswordName()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite um nome para sua senha: ");
            Console.ForegroundColor = ConsoleColor.White;

            return Console.ReadLine()!.Trim();
        }

        public void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
