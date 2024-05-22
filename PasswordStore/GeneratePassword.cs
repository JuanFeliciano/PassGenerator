using PasswordStore.Generator;

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


        public void Generate()
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

                if(PasswordEntry.passwordEntries.Any(pe => pe.Name.Equals(namePass)))
                {
                    _userInput.ShowMessage("Já existe uma senha com o mesmo nome, por favor digite outro: ", ConsoleColor.Yellow);
                }
                else
                {
                    string password = _passwordGenerator.Generate(lenght, includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);
                    PasswordEntry.passwordEntries.Add(new PasswordEntry(namePass, password));
                    _userInput.ShowMessage($"Senha Gerada: {password}", ConsoleColor.Green);
                    break;
                }
            }
        }
    }
}