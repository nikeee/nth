﻿using System;
using System.Security;

namespace NTH
{
    public static class ConsoleEx
    {
        private const char DefaultPasswordChar = '*';
        private const bool DefaultUseMask = false;

        public static SecureString ReadLineMasked()
        {
            return ReadLineMasked(DefaultUseMask, DefaultPasswordChar);
        }
        public static SecureString ReadLineMasked(bool useMask)
        {
            return ReadLineMasked(useMask, DefaultPasswordChar);
        }
        public static SecureString ReadLineMasked(bool useMask, char mask)
        {
            using (var securePassword = new SecureString())
            {
                while (true)
                {
                    var k = Console.ReadKey(true);

                    if (k.Key == ConsoleKey.Enter)
                        break;
                    if (k.Key == ConsoleKey.Escape)
                        return null;

                    if (k.Key == ConsoleKey.Backspace)
                    {
                        if (securePassword.Length > 0)
                        {
                            securePassword.RemoveChar();
                            Console.Write("\b \b");
                        }
                        continue;
                    }

                    securePassword.AppendChar(k.KeyChar);

                    if (useMask)
                        Console.Write(mask);
                }

                if (securePassword.Length > 0)
                    return securePassword.Copy();
                return null;
            }
        }
    }
}
