using System;

namespace SAV_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int healthBoss = rnd.Next(500, 1000);
            int damageBoss;
            int healthPlayer = rnd.Next(250, 500);
            int healthShadow =0;
            bool startGame = true;
             bool activatedBeast = false;
             bool activatedDimension = false;
            bool activatedFire = false;
            string spell;

            Console.WriteLine("\nПеред вами возник ужасающий Босс.\n");
            Console.WriteLine($"\nСтатистика Босса: \n Здоровье: {healthBoss} \n\nСтатистика игрока: \n Здоровье: {healthPlayer}\n\nБосс атакует приготовьтесь к бою\n ");

            while (startGame)
            {
                damageBoss = rnd.Next(25, 100);
                if (healthBoss <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nБосс повержен");
                }
                if (healthPlayer <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                if ((activatedDimension == true) && (startGame != false))
                {
                    if (healthShadow <= 0)
                    {
                        Console.Write("\nВаша теневая копия мертва. Необходимо вернутся в мир босса.\n");
                        activatedDimension = false;
                    }
                    if (healthShadow > 0)
                    {
                        Console.WriteLine("\n\nВы находитесь в паралельном измерении. Босс атакует вашу теневую копию, если она умрет вам придется вернутся обратно в мир босса. Доступные навыки:\n" +
                            "1. Иной мир - Позволяет остаться в паралельном измерении и востанавливаеть 50 ед. здоровья\n\n" +
                            "2. Возвращение - создает портал возвращая вас к Боссу, после того как он атакует Вашу теневую копию.\n");
                        if (activatedBeast == true)
                            Console.WriteLine("3. Назад в преисподнюю - отзывает огненого зверя.\n");

                        Console.Write("\nВведите заклинание указав его номер: ");
                        spell = Console.ReadLine();
                        switch (spell)
                        {
                            case "1":
                                if (activatedBeast == true)
                                {
                                    healthPlayer -= 100;
                                    Console.WriteLine("У вас призван Огненый зверь, Ваше здоровье уменьшилось на 100 ед.\n");
                                }
                                healthPlayer += 50;
                                healthShadow -= damageBoss;
                                if (healthPlayer >= 500)
                                {
                                    healthPlayer = 500;
                                    Console.WriteLine("Ваше здоровье достигло максимума: 500 ед. здоровья");
                                    if (healthShadow > 0)
                                        Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                            $"Текущие здоровье теневой копии: {healthShadow}\n" +
                                            $"Текущее здоровье Босса равно: {healthBoss} \n");
                                    if (healthShadow <= 0)
                                        Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                            $"Текущее здоровье Босса равно: {healthBoss} \n");
                                }
                                else
                                {
                                    if (healthShadow > 0)
                                        Console.WriteLine("Вы остались паралельном мире и востановили 50 ед. здоровья.\n" +
                                            $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                            $"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                            $"Текущие здоровье теневой копии: {healthShadow}\n" +
                                            $"Текущее здоровье Босса равно: {healthBoss} \n");
                                    if (healthShadow <= 0)
                                        Console.WriteLine("Вы остались паралельном мире и востановили 50 ед. здоровья.\n" +
                                            $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                            $"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                            $"Текущее здоровье Босса равно: {healthBoss} \n");
                                }
                                break;
                            case "3":
                                if (activatedBeast == true)
                                {
                                    activatedBeast = false;
                                    healthPlayer += 50;
                                    healthShadow -= damageBoss;
                                    if (healthPlayer >= 500)
                                    {
                                        healthPlayer = 500;
                                        Console.WriteLine("Ваше здоровье достигло максимума: 500 ед. здоровья");
                                        if (healthShadow > 0)
                                            Console.WriteLine("Вы отзываете огненого зверя\n" +
                                                $"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                                $"Текущие здоровье теневой копии: {healthShadow}\n" +
                                                $"Текущее здоровье Босса равно: {healthBoss} \n");
                                        if (healthShadow <= 0)
                                            Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                                $"Текущее здоровье Босса равно: {healthBoss} \n");
                                    }
                                    else
                                    {
                                        if (healthShadow > 0)
                                            Console.WriteLine("Вы отзываете огненого зверя оставаясь в паралельном мире и востановили 50 ед. здоровья.\n" +
                                                $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                                $"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                                $"Текущие здоровье теневой копии: {healthShadow}\n" +
                                                $"Текущее здоровье Босса равно: {healthBoss} \n");
                                        if (healthShadow <= 0)
                                            Console.WriteLine("Вы отзываете огненого зверя оставаясь в паралельном мире и востановили 50 ед. здоровья.\n" +
                                                $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                                $"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                                $"Текущее здоровье Босса равно: {healthBoss} \n");
                                    }
                                }
                                else
                                    Console.WriteLine("Вы не можете использовать данное заклинание так как Огненый зверь не призван. Выберети другое заклинание. ");
                                break;
                            case "2":
                                if (activatedBeast == true)
                                {
                                    healthPlayer -= 100;
                                    Console.WriteLine("У вас призван Огненый зверь, Ваше здоровье уменьшилось на 100 ед.\n");
                                }
                                healthPlayer += 50;
                                healthShadow -= damageBoss;
                                activatedDimension = false;
                                if (healthPlayer >= 500)
                                {
                                    healthPlayer = 500;
                                    Console.WriteLine("Ваше здоровье достигло максимума: 500 ед. здоровья");
                                    Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                        "Вы возвращаетесь в мир Босса. Теневая копия исчезает\n" +
                                        $"Текущее здоровье Босса равно: {healthBoss} \n");
                                }
                                else
                                {
                                    Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                        "Вы возвращаетесь в мир Босса востановив 50 ед. здоровья. Теневая копия исчезает\n" +
                                        $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                        $"Текущее здоровье Босса равно: {healthBoss} \n");
                                }
                                break;
                            default:
                                Console.WriteLine($"\nВам незнакомо <<{spell}>> это заклинание");
                                break;
                        }
                    }
                }
                if ((activatedDimension == false) && (startGame != false))
                {
                    Console.WriteLine("\nДоступные заклинания: \n" +
                        "1. Огненый шар - наносит 50 ед. урона, позволяет использовать навык << Возгарание >> в течение следующего хода.\n"); 
                    if (activatedFire == true)
                        Console.WriteLine("2. Возгорание - наносит 150 ед. урона. Можно использовать только если в прошлых ход был использован навык <<Огненый шар>> или <<Огненый зверь>>\n");
                    Console.WriteLine("3. Иной мир - создает портал в паралельное измерение где востанавливается 50 ед. здоровья каждый ход и теневую копию для атак босса. В паралельном измерении нельзя атаковать босса.\n"); 
                    if (activatedBeast == false)
                        Console.WriteLine("4. Огненый Зверь - Призывает огненого зверя который позволяет в течение следующиго хода использовать навык <<Возгарание>>. Каждый ход призванный зверь отнимает 100 ед. здоровья у хозяина, кроме хода-призыва и вовремя отзыва зверя.\n");
                    if (activatedBeast == true)
                    Console.WriteLine("5. Назад в преисподнюю - отзывает огненого зверя.\n\n" +
                        "6. Пылающая лапа - Огненый зверь атакует босса и наносит 200 ед. урона. Навык может быть использован только если призван огненый зверь.\n");
                    
                    Console.Write("\nВведите заклинание указав его номер: ");
                    spell = Console.ReadLine();
                    if ((activatedFire == true) && (spell != "2"))
                        activatedFire = false;
                    switch (spell)
                    {
                        case "1":
                            if (activatedBeast == true)
                            {
                                healthPlayer -= 100;
                                Console.WriteLine("У вас призван Огненый зверь, Ваше здоровье уменьшилось на 100 ед.\n");
                            }
                            healthPlayer -= damageBoss;
                            healthBoss -= 50;
                            activatedFire = true;
                            if ((healthBoss > 0) && (healthPlayer > 0))
                                Console.WriteLine($"Босс наносит вам {damageBoss} ед. урона\n" +
                                    $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                    "Вы наносите 50 ед. урона\n" +
                                    $"Текущее здоровье Босса равно: {healthBoss} \n");
                            if (healthBoss <= 0)
                                Console.WriteLine("Вы наносите 50 ед. урона\n");
                            if (healthPlayer <= 0)
                                Console.WriteLine($"Босс наносит вам {damageBoss} ед. урона\n");
                            break;
                        case "2":
                            if (activatedFire == true)
                            {
                                if (activatedBeast == true)
                                {
                                    healthPlayer -= 100;
                                    Console.WriteLine("У вас призван Огненый зверь, Ваше здоровье уменьшилось на 100 ед.\n");
                                }
                                healthPlayer -= damageBoss;
                                healthBoss -= 150;
                                activatedFire = false;
                                if ((healthBoss > 0) && (healthPlayer > 0))
                                    Console.WriteLine($"Босс наносит вам {damageBoss} ед. урона\n" +
                                        $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                        "Вы наносите 150 ед. урона\n" +
                                        $"Текущее здоровье Босса равно: {healthBoss} \n");
                                if (healthBoss <= 0)
                                    Console.WriteLine("Вы наносите 150 ед. урона\n");
                                if (healthPlayer <= 0)
                                    Console.WriteLine($"Босс наносит вам {damageBoss} ед. урона\n");
                            }
                            else Console.WriteLine("Вы не можете использовать данное заклинание, выберите другое. ");
                            break;
                        case "3":
                            if (activatedBeast == true)
                            {
                                healthPlayer -= 100;
                                Console.WriteLine("У вас призван Огненый зверь, Ваше здоровье уменьшилось на 100 ед.\n");
                            }
                            healthShadow = healthPlayer;
                            Console.WriteLine("Вы создали теневую копию, и вошли в портал паралельного мира.\n" +
                                $"Текущие здоровье теневой копии: {healthShadow}\n");
                            healthPlayer += 50;
                            healthShadow -= damageBoss;
                            activatedDimension = true;
                            if ((healthBoss > 0) && (healthShadow > 0))
                                Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n" +
                                    $"Текущие здоровье теневой копии: {healthShadow}\n" +
                                    "Вы восстановили 50 ед. здоровья\n" +
                                    $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                    $"Текущее здоровье Босса равно: {healthBoss} \n");
                            if (healthShadow <= 0)
                            {
                                Console.WriteLine($"Босс наносит теневой копии {damageBoss} ед. урона. \n");
                            }
                            break;
                        case "4":
                            if (activatedBeast == true)
                            {
                                Console.WriteLine("Огненый зверь уже призван. Выберети другое заклинание. ");
                            }
                            else
                            {
                                healthPlayer -= damageBoss;
                                activatedBeast = true;
                                activatedFire = true;
                                if ((healthBoss > 0) && (healthPlayer > 0))
                                    Console.WriteLine("Вы призвали огненого зверя.\n" +
                                        $"Босс наносит вам {damageBoss} ед. урона\n" +
                                        $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                        $"Текущее здоровье Босса равно: {healthBoss} \n");
                                if (healthPlayer <= 0)
                                    Console.WriteLine("Вы призвали огненого зверя.\n" +
                                        $"Босс наносит вам {damageBoss} ед. урона\n");
                            }
                            break;
                        case "5":
                            if (activatedBeast == true)
                            {
                                activatedBeast = false;
                                healthPlayer -= damageBoss;
                                if ((healthBoss > 0) && (healthPlayer > 0))
                                    Console.WriteLine("Вы отзываете огненого зверя.\n" +
                                        $"Босс наносит вам {damageBoss} ед. урона\n" +
                                        $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                        $"Текущее здоровье Босса равно: {healthBoss} \n");
                                if (healthPlayer <= 0)
                                    Console.WriteLine("Вы отзываете огненого зверя.\n" +
                                        $"Босс наносит вам {damageBoss} ед. урона\n");
                            }
                            else
                                Console.WriteLine("\nВы не можете использовать данное заклинание так как Огненый зверь не призван. Выберети другое заклинание.\n ");
                            break;
                        case "6":
                            if (activatedBeast == true)
                            {
                                healthPlayer -= 100;
                                Console.WriteLine("У вас призван Огненый зверь, Ваше здоровье уменьшилось на 100 ед.\n");
                                healthBoss -= 200;
                                healthPlayer -= damageBoss;
                                if ((healthBoss > 0) && (healthPlayer > 0))
                                    Console.WriteLine($"Босс наносит вам {damageBoss} ед. урона\n" +
                                        $"Ваше текущее здоровье равно: {healthPlayer}\n" +
                                        "Огненый зверь нанес Боссу 200 ед. урона.\n" +
                                        $"Текущее здоровье Босса равно: {healthBoss} \n");
                                if (healthBoss <= 0)
                                    Console.WriteLine("Огненый зверь нанес Боссу 200 ед. урона.\n");
                                if (healthPlayer <= 0)
                                    Console.WriteLine($"Босс наносит вам {damageBoss} ед. урона\n");
                            }
                            else
                                Console.WriteLine("\nВы не можете использовать данное заклинание так как Огненый зверь не призван. Выберети другое заклинание.\n ");
                            break;
                        default:
                            Console.WriteLine($"\nВам незнакомо {spell} это заклинание");
                            break;
                    }
                }
                        
            }
        }
    }
}
