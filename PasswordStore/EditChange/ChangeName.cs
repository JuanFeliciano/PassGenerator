namespace PasswordStore.EditChange
{
    internal class ChangeName
    {
        public void NamePassword()
        {
            bool validation = true;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Digite o nome da senha que deseja alterar o nome: ");
            Console.ForegroundColor = ConsoleColor.White;
            var nameEntry = Console.ReadLine()!.Trim();

            var storedName = PasswordEntry.passwordEntries.Find(pe => pe.Name.Equals(nameEntry));
            if (storedName != null)
            {
                while (validation)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite o novo nome que deseja para sua senha: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    string newName = Console.ReadLine()!.Trim();
                    bool validName = PasswordEntry.passwordEntries.Any(pe => pe.Name.Equals(newName));

                    switch (validName)
                    {
                        case true:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Já existe uma senha com este nome!");
                            break;
                        case false:
                            PasswordEntry.passwordEntries.Remove(storedName);
                            PasswordEntry.passwordEntries.Add(new PasswordEntry(newName, storedName.Password));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Nome Atualizado: {newName}");
                            validation = false;
                            break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Não existe nenhuma senha com este mesmo nome!");
            }

        }
    }
}