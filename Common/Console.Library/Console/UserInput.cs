using System;

namespace Zeck.Common
{
    public static class UserInput
    {
        public static string Get(string message)
        {
            Console.Write($"{message}: ");
            return Console.ReadLine();
        }
    }
}