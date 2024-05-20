using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore.SubFunction
{
    internal class GenerateRandomPassword
    {
        public string GenerateRP(int lenght, bool includeUpperCase, bool includeLowerCase, bool includeSpecialChars, bool includeNumbers)
        {


            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_-+=<>?";

            StringBuilder characterPool = new();

            if (includeUpperCase)
            {
                characterPool.Append(uppercase);
            }
            if (includeLowerCase)
            {
                characterPool.Append(lowercase);
            }
            if (includeSpecialChars)
            {
                characterPool.Append(specialChars);
            }
            if (includeNumbers)
            {
                characterPool.Append(numbers);
            }

            if (characterPool.Length == 0)
            {
                Console.WriteLine("Nenhuma categoria de caracteres selecionado!");
            }

            StringBuilder password = new();
            Random random = new();

            for (int i = 0; i < lenght; i++)
            {
                int index = random.Next(characterPool.Length);
                password.Append(characterPool[index]);
            }

            return password.ToString();
        }
    }
}

