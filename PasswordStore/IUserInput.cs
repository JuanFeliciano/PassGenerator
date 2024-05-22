using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordStore
{
    internal interface IUserInput
    {
        int GetPasswordLenght();
        bool GetYesOrNoInput(string message);
        string GetPasswordName();
        void ShowMessage(string message, ConsoleColor color);
    }
}
