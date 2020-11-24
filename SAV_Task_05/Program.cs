using System;
using System.IO;
using System.Threading;

namespace SAV_Task_05
{
    class Program
    {
        //Bar показывающий процент нарисованной 9
        static void Bar(int barpainted , char[,] mappassage, int performerX, int performerY, out int painted)
        {
            if (mappassage[performerX, performerY] == '█')
                barpainted++;
            if (barpainted == 1)
            {
                Console.SetCursorPosition(40, 29);
                Console.Write("Прогресс:");
            }
            if (barpainted <51)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[__________]");
            }
            if (barpainted < 102 && barpainted >= 51)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[#_________]");
            }
            if (barpainted < 153 && barpainted >= 102)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[##________]");
            }
            if (barpainted < 204 && barpainted >= 153)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[###_______]");
            }
            if (barpainted < 255 && barpainted >= 204)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[####______]");
            }
            if (barpainted < 306 && barpainted >= 255)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[#####_____]");
            }
            if (barpainted < 357 && barpainted >= 306)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[######____]");
            }
            if (barpainted  < 408 && barpainted >= 357)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[#######___]");
            }
            if (barpainted < 459 && barpainted >= 408)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[########__]");
            }
            if (barpainted < 509 && barpainted >= 459)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[#########_]");
            }
            if (barpainted == 509)
            {
                Console.SetCursorPosition(50, 29);
                Console.Write("[##########]");
            }
            painted = barpainted;
        }

        //Подсчет шагов
        static void counterstep(int Numberstep)
        {
            Console.SetCursorPosition(40, 27);
            Console.Write($"Сделано шагов: {Numberstep}/509.");
        }

        //Чтение мапы
        static char[,] ReadMap(string mapName, out int performerX, out int performerY)
        {
            performerX = 0;
            performerY = 0;

            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '■')
                    {
                        performerX = i;
                        performerY = j;
                    }
                }
            }
            return map;
        }

        //Вывод мапы
        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        //шаг вниз
        static void Down(char[,] map, int DownperformerX, int DownperformerY, out int performerX, out int performerY)
        {
            //Задаем положение курсора
            Console.SetCursorPosition(DownperformerY, DownperformerX);
            //Рисуем след
            Console.Write('█');
            map[DownperformerX, DownperformerY] = '█';
            //Перемещаем персонажа
            Console.SetCursorPosition(DownperformerY, ++DownperformerX);
            Console.Write('■');
            //Возвращаем новые координаты
            performerX = DownperformerX;
            performerY = DownperformerY;
        }

        //шаг вверх
        static void Up(char[,] map, int UpperformerX, int UpperformerY, out int performerX, out int performerY)
        {
            Console.SetCursorPosition(UpperformerY, UpperformerX);
            Console.Write('█');
            map[UpperformerX, UpperformerY] = '█';
            Console.SetCursorPosition(UpperformerY, --UpperformerX);
            Console.Write('■');
            performerX = UpperformerX;
            performerY = UpperformerY;
        }

        //шаг влево
        static void Left(char[,] map, int LeftperformerX, int LeftperformerY, out int performerX, out int performerY)
        {
            Console.SetCursorPosition(LeftperformerY, LeftperformerX);
            Console.Write('█');
            map[LeftperformerX, LeftperformerY] = '█';
            Console.SetCursorPosition(--LeftperformerY, LeftperformerX);
            Console.Write('■');
            performerX = LeftperformerX;
            performerY = LeftperformerY;
        }

        //шаг вправо
        static void Right(char[,] map, int RightperformerX, int RightperformerY, out int performerX, out int performerY)
        {
            Console.SetCursorPosition(RightperformerY, RightperformerX);
            Console.Write('█');
            map[RightperformerX, RightperformerY] = '█';
            Console.SetCursorPosition(++RightperformerY, RightperformerX);
            Console.Write('■');
            performerX = RightperformerX;
            performerY = RightperformerY;
        }

        static void Main(string[] args)
        {
            //Задаем размеры окна
            Console.CursorVisible = false;
            Console.WindowWidth = 120;
            Console.WindowHeight = 48;

            int painted = 0;
            bool startGame = true;
            int Numberstep = 0;
            int performerX, performerY;
            int a, b;
            char[,] map = ReadMap("level01", out performerX, out performerY);
            char[,] mappassage = ReadMap("level01passage",out a, out b);
            DrawMap(map);

            //Менюшечка с инструкцией
            Console.SetCursorPosition(40, 16);
            Console.Write("Лабиринт 'Нарисуй '9''.");
            Console.SetCursorPosition(40, 18);
            Console.Write("Ваша задача пройти лабиринт при этом нарисовать число 9.");
            Console.SetCursorPosition(40, 19);
            Console.Write("Всягда помните корткий и легкий путь не всегда правильный и верный!");
            Console.SetCursorPosition(40, 21);
            Console.Write("Данный лабиринт можно пройти за 509 шагов.");
            Console.SetCursorPosition(40, 23);
            Console.Write("Стрелки - сделать шаг в указаном стрелкой направлении");
            Console.SetCursorPosition(40, 24);
            Console.Write("F1 - подсказка по прохождению");
            Console.SetCursorPosition(40, 25);
            Console.Write("ESC - выход.");

            //Начало игры
            while (startGame)
            {
                ConsoleKeyInfo step;

                step = Console.ReadKey();
                switch (step.Key)
                {
                    case ConsoleKey.DownArrow:
                        //Шаг на "выход"
                        if (map[performerX + 1, performerY] == '▼')
                        {
                            startGame = false;
                            Console.SetCursorPosition(performerY, performerX);
                            Console.Write('█');
                            map[performerX, performerY] = '█';
                            Console.SetCursorPosition(performerY, ++performerX);
                            Console.Write('■');
                            Numberstep++;
                            counterstep(Numberstep);
                        }
                        // Проверка "startGame != false" необходима для того что бы мы не вышли за приделы массива после того как достикли финиша
                        if (startGame != false)
                        {
                            //Шаг если нет стены
                            if (map[performerX + 1, performerY] == ' ')
                            {
                                Down(map, performerX, performerY, out performerX, out performerY);
                                Numberstep++;
                                counterstep(Numberstep);
                                Bar(painted, mappassage, performerX, performerY, out painted);

                            }
                            // Шаг назад
                            if (map[performerX + 1, performerY] == '█')
                            {
                                Console.SetCursorPosition(performerY, performerX);
                                Console.Write(' ');
                                map[performerX, performerY] = ' ';
                                Console.SetCursorPosition(performerY, ++performerX);
                                Console.Write('■');
                                Numberstep++;
                                counterstep(Numberstep);
                            }
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        //Шаг на "выход"
                        if (map[performerX - 1, performerY] == '▼')
                        {
                            startGame = false;
                            Console.SetCursorPosition(performerY, performerX);
                            Console.Write('█');
                            map[performerX, performerY] = '█';
                            Console.SetCursorPosition(performerY, --performerX);
                            Console.Write('■');
                            Numberstep++;
                            counterstep(Numberstep);
                        }
                        if (startGame != false)
                        {
                            //Шаг если нет стены
                            if (map[performerX - 1, performerY] == ' ' )
                            {
                                Up(map, performerX, performerY, out performerX, out performerY);
                                Numberstep++;
                                counterstep(Numberstep);
                                Bar(painted, mappassage, performerX, performerY, out painted);
                            }
                            // Шаг назад
                            if (map[performerX - 1, performerY] == '█')
                            {
                                Console.SetCursorPosition(performerY, performerX);
                                Console.Write(' ');
                                map[performerX, performerY] = ' ';
                                Console.SetCursorPosition(performerY, --performerX);
                                Console.Write('■');
                                Numberstep++;
                                counterstep(Numberstep);
                            }
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        //Шаг на "выход"
                        if (map[performerX, performerY - 1] == '▼')
                        {
                            startGame = false;
                            Console.SetCursorPosition(performerY, performerX);
                            Console.Write('█');
                            map[performerX, performerY] = '█';
                            Console.SetCursorPosition(--performerY, performerX);
                            Console.Write('■');
                            Numberstep++;
                            counterstep(Numberstep);
                        }
                        if (startGame != false)
                        {
                            //Шаг если нет стены
                            if (map[performerX, performerY - 1] == ' ')
                            {
                                Left(map, performerX, performerY, out performerX, out performerY);
                                Numberstep++;
                                counterstep(Numberstep);
                                Bar(painted, mappassage, performerX, performerY, out painted);

                            }
                            // Шаг назад
                            if (map[performerX, performerY - 1] == '█')
                            {
                                Console.SetCursorPosition(performerY, performerX);
                                Console.Write(' ');
                                map[performerX, performerY] = ' ';
                                Console.SetCursorPosition(--performerY, performerX);
                                Console.Write('■');
                                Numberstep++;
                                counterstep(Numberstep);
                            }
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        //Шаг на "выход"
                        if (map[performerX, performerY + 1] == '▼')
                        {
                            startGame = false;
                            Console.SetCursorPosition(performerY, performerX);
                            Console.Write('█');
                            map[performerX, performerY] = '█';
                            Console.SetCursorPosition(++performerY, performerX);
                            Console.Write('■');
                            Numberstep++;
                            counterstep(Numberstep);

                        }
                        if (startGame != false)
                        {
                            //Шаг если нет стены 
                            if (map[performerX, performerY + 1] == ' ')
                            {
                                Right(map, performerX, performerY, out performerX, out performerY);
                                Numberstep++;
                                counterstep(Numberstep);
                                Bar(painted, mappassage, performerX, performerY, out painted);
                            }
                            // Шаг назад
                            if (map[performerX, performerY + 1] == '█')
                            {
                                Console.SetCursorPosition(performerY, performerX);
                                Console.Write(' ');
                                map[performerX, performerY] = ' ';
                                Console.SetCursorPosition(++performerY, performerX);
                                Console.Write('■');
                                Numberstep++;
                                counterstep(Numberstep);
                            }

                        }
                        
                        break;

                    case ConsoleKey.Escape:
                        Console.SetCursorPosition(0,45);
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.F1:
                        //Цикнл прохода по лабиринту
                        for (int i = 0; i < 507; i++)
                        {
                            //Сравнение с мапой прохождения
                            if (mappassage[performerX + 1, performerY] == '█' && map[performerX + 1, performerY ] == ' ')
                            {
                                Down(map, performerX, performerY, out performerX, out performerY);
                                Thread.Sleep(500);
                            }
                            if (mappassage[performerX - 1, performerY] == '█' && map[performerX - 1, performerY] == ' ')
                            {
                                Up(map, performerX, performerY, out performerX, out performerY);
                                Thread.Sleep(500);
                            }
                            if (mappassage[performerX, performerY + 1] == '█' && map[performerX, performerY + 1] == ' ')
                            {
                                Right(map, performerX, performerY, out performerX, out performerY);
                                Thread.Sleep(500);
                            }
                            if (mappassage[performerX, performerY - 1] == '█' && map[performerX, performerY -1] == ' ')
                            {
                                Left(map, performerX, performerY, out performerX, out performerY);
                                Thread.Sleep(500);
                            }
                        }
                        //Шаг на "выход"
                        Console.SetCursorPosition(performerY, performerX);
                        Console.Write('█');
                        map[performerX, performerY] = '█';
                        Console.SetCursorPosition(++performerY, performerX);
                        Console.Write('■');
                        startGame = false;
                        break;
                    default:
                        break;
                }
            }

            Console.SetCursorPosition(40,30);
            Console.Write("Игра окончена.");
            Console.SetCursorPosition(0, 45);
            Console.ReadKey();
        }

    }
}
