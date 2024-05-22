using System.Text;

namespace PasswordStore.Generator
{
    internal class GenerateRandom
    {
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "0123456789";
        private const string SpecialChars = "!@#$%^&*()_-+=<>?";

        public string Generate(int lenght, bool includeUpperCase, bool includeLowerCase, bool includeSpecialChars, bool includeNumbers)
        {
            if (lenght <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                throw new ArgumentException("O tamanho da senha deve ser maior do que zero!");
            }

            var characterPool = BuildCharacterPool(includeUpperCase, includeLowerCase, includeSpecialChars, includeNumbers);


            if (characterPool.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                throw new ArgumentException("Nenhuma categoria de caracteres foi selecionada!");
            }

            return GeneratePassword(lenght, characterPool);
        }

        private StringBuilder BuildCharacterPool(bool includeUpperCase, bool includeLowerCase, bool includeSpecialChars, bool includeNumbers)
        {
            var characterPool = new StringBuilder();

            if (includeUpperCase)
            {
                characterPool.Append(Uppercase);
            }
            if (includeLowerCase)
            {
                characterPool.Append(Lowercase);
            }
            if (includeSpecialChars)
            {
                characterPool.Append(SpecialChars);
            }
            if (includeNumbers)
            {
                characterPool.Append(Numbers);
            }

            return characterPool;
        }

        private string GeneratePassword(int lenght, StringBuilder characterPool)
        {
            var password = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < lenght; i++)
            {
                int index = random.Next(characterPool.Length);
                password.Append(characterPool[index]);
            }

            return password.ToString();
        }
    }
}