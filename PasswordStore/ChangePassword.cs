using PasswordStore.EditChange;

namespace PasswordStore
{
    internal class ChangePassword
    {
        public void EditPassword()
        {
            ChangeName changename = new();
            ChangeValue changevalue = new();
            bool valid = true;

            while (valid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você deseja alterar o nome ou o valor da sua senha? [N = NOME / V = VALOR]");
                Console.ForegroundColor = ConsoleColor.White;
                string option = Console.ReadLine()!.ToUpper().Trim();

                switch (option)
                {
                    case "N":
                        changename.NamePassword();
                        return;
                    case "V":
                        changevalue.ChangePassword();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Digite uma opção válida!");
                        break;
                }
            }
        }
    }
}


