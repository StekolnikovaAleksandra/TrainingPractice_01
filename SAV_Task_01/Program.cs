using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAV_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int price = 15;
            int crystals;
            bool optionPurchase;

        Link:
            Console.Write("Хотите ли вы обменять золото на алмазы? Ответьте только 'Да' или 'Нет'.\n");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "Да":
                    Console.Write("Сколько у вас золотых монет?\n");
                    gold = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Цена кристалла {price} монет. Сколько вы хотите купить кристаллов?\n");
                    crystals = Convert.ToInt32(Console.ReadLine());

                    optionPurchase = gold >= price * crystals;
                    crystals *= Convert.ToInt32(optionPurchase);
                    gold -= price * crystals;
                    Console.WriteLine($"У вас в сумке осталось {gold} монет и появилось {crystals} кристаллов.");
                    break;

                case "Нет":
                    Console.Write("Если все же все же захотите обменять мнеты на кристаллы, то я всегда к вашим услугам. Приходите еще.\n");
                    break;

                default:
                    Console.Write("Введите, пожалуйста, корректный ответ.\n");
                    goto Link;
                    break;
            }
        }
    }
}
