using System;

namespace KES_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "minami";
            string userPassword;
            int attempt = 3;

            Console.WriteLine("Введите пароль: ");

            for (attempt = 3; attempt >= 1; --attempt)
            {
                userPassword = Console.ReadLine();
                if (userPassword == password)
                {
                    Console.WriteLine("\nСекретное сообщение!!!");
                    break;
                }
                if ((userPassword != password) && (attempt > 1))
                {
                    Console.WriteLine("Повторите попытку: ");
                }
            }
        }
    }
}
