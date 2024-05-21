using PasswordStore.SubFunction;

namespace PasswordStore
{
    internal class GeneratePassword
    {
        private readonly GenerateRandom _passwordGenerator;
        private readonly IUserInput _userInput;
        
        public GeneratePassword(GenerateRandom passwordGenerator, IUserInput userInput)
        {
            _passwordGenerator = passwordGenerator;
            _userInput = userInput;
        }


        public void Generate(List<PasswordEntry> passwordEntries)
        {
            int lenght = _userInput.GetPasswordLenght();

            if (lenght == -1) return;

            bool includeUpperCase = _userInput.GetYesOrNoInput("Incluir letras maiúsculas? (s/n): ");
            bool includeLowerCase = _userInput.GetYesOrNoInput("Incluir letras minúsculas? (s/n): ");
            bool includeSpecialChars = _userInput.GetYesOrNoInput("Incluir caracteres especiais? (s/n): ");
            bool includeNumbers = _userInput.GetYesOrNoInput("Incluir números? (s/n): ");

            while(true)
            {
                string namePass = _userInput.GetPasswordName();
                if (namePass == string.Empty) continue;

                if(passwordEntries.Any(pe => pe.Name.Equals(namePass)))
                {
                    _userInput.ShowMessage("Já existe uma senha com o mesmo nome, por favor digite outro: ", ConsoleColor.Yellow);
                }
                else
                {
                    string password = _passwordGenerator.Generate(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
                    passwordEntries.Add(new PasswordEntry(namePass, password));
                    _userInput.ShowMessage($"Senha Gerada: {password}", ConsoleColor.Green);
                    break;
                }
            }
        }


        public interface IUserInput
        {
            int GetPasswordLenght();
            bool GetYesOrNoInput(string message);
            string GetPasswordName();
            void ShowMessage(string message, ConsoleColor color);
        }

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
                bool result = Console.ReadLine()!.ToLower().Trim() == "s";

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
}