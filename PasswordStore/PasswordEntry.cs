using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    public class PasswordEntry
    {
        public string Name { get; }
        public string Password { get; }

        public PasswordEntry(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public static List<PasswordEntry> passwordEntries = new List<PasswordEntry>();
    }
}