using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Security.Credentials;

namespace PassVault
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PasswordVault vault = new PasswordVault();
            
            IReadOnlyList<PasswordCredential> credentials = vault.RetrieveAll();
            if (credentials.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"未获取到凭证管理器中的Web凭证");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Web凭证来源   用户名 密码");
                for (int i = 0; i < credentials.Count; i++)
                {
                    PasswordCredential cred = credentials.ElementAt(i);
                    
                    cred.RetrievePassword();

                    Console.WriteLine($"{cred.Resource} : {cred.UserName}/{cred.Password}");
                }
            }
            Console.ReadKey();
        }
    }
}
