namespace PasswordStore
{
    internal class CatchPassword
    {
        public void PickPassword()
        {
            if (PasswordEntry.passwordEntries.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var entry in PasswordEntry.passwordEntries)
                    Console.WriteLine($"Nome: {entry.Name} - Senha: {entry.Password}");
                Console.ForegroundColor = ConsoleColor.Red;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Senha inválida ou inexistente;");
                Console.ForegroundColor = ConsoleColor.Red;

            }
        }
    }
}
