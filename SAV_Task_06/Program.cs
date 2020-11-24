using System;

namespace SAV_Task_06
{
    class Program
    {
        static void search(string[] addNames, string[] addProfessions, string[] secondNames)
        {
            Console.Clear();
            bool prov = false;
            string secondName;
            Console.Write("Введите фамилию для поиска: ");
            secondName = Console.ReadLine();
                for (int i = 1; i < secondNames.Length; i++)
                {
                    if (secondName == secondNames[i])
                    {
                        Console.WriteLine($"{addNames[i]} - {addProfessions[i]}");
                        prov = true;
                    }
                }
            if (prov == false)
                Console.WriteLine("В досье нет данной фамилии");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();

        }
        static void removeAt(ref string[] removedName, ref string[] removedProf, int index)
        {
            string[] newRemovedName = new string[removedName.Length - 1];
            string[] newRemovedProf = new string[removedProf.Length - 1];
            for (int i = 0; i < index; i++)
                newRemovedName[i] = removedName[i];
            for (int i = index + 1; i < removedName.Length; i++)
                newRemovedName[i - 1] = removedName[i];
            for (int i = 0; i < index; i++)
                newRemovedProf[i] = removedProf[i];
            for (int i = index + 1; i < removedName.Length; i++)
                newRemovedProf[i - 1] = removedProf[i];
            removedName = newRemovedName;
            removedProf = newRemovedProf;

        }
        static void resizePlus(ref string[] resizeName, ref string[] resizeProf, ref string[] resizeSecondNames, int newSize)
        {
            Console.Clear();
            string[] newSizeName = new string[newSize];
            string[] newSizeProf = new string[newSize];
            string[] newSizeSecondNames = new string[newSize];
            for (int i = 0; i < resizeName.Length; i++)
            {
                newSizeName[i] = resizeName[i];
                newSizeProf[i] = resizeProf[i];
                newSizeSecondNames[i] = resizeSecondNames[i];
            }
            resizeName = newSizeName;
            resizeProf = newSizeProf;
            resizeSecondNames = newSizeSecondNames;
        }
        private static void addName(string[] names, string[] professions, string[] secondNames, int i, int j, int size)
        {
            string a, b, c;
            Console.Clear();
            Console.Write("Добавить досье: \n\n" +
                "Введите фамилию: ");
            a = Console.ReadLine();
            secondNames[i] = a;
            Console.Write("Введите имя: ");
            b = Console.ReadLine();
            Console.Write("Введите отчество: ");
            c = Console.ReadLine();
            names[i] = a + " " + b + " " + c;
            Console.Write("Введите должность: ");
            professions[j] = Console.ReadLine();
            Console.WriteLine("Успех!");
        }
        private static void Main(string[] args)
        {
            int i = 0, j = 0, countProf = 1, size = 1, number;
            string menu = "";
            string[] addNames = new string[size];
            string[] addProfessions = new string[size];
            string[] addSecondName = new string[size];
            while (menu != "5")
            {
                Console.Clear();
                Console.Write("Меню\n"+
                    "1 - Добавить досье\n" +
                    "2 - Вывести все досье\n" +
                    "3 - Удалить досье\n" +
                    "4 - Поиск по фамилии\n" +
                    "5 - Выход из программы\n\n" +
                    "Введите нужный Вам пункт: ");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        size += 1;
                        i++;
                        j++;
                        resizePlus(ref addNames, ref addProfessions, ref addSecondName, size);
                        addName(addNames, addProfessions, addSecondName, i, j, size);
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Список всех досье");
                        for (int countNames = 1; countNames < addNames.Length; countNames++)
                        {
                            Console.WriteLine($"{countNames}. {addNames[countNames]} - {addProfessions[countProf]}");
                            countProf++;
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    case "3":
                        if (size > 1)
                        {
                            Console.WriteLine("Введите номер удаляемого досье");
                            number = Convert.ToInt32(Console.ReadLine());
                            removeAt(ref addNames, ref addProfessions, number);
                            Console.WriteLine("Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                            size -= 1;
                        }
                        else
                        {
                            Console.WriteLine("В досье нет ни одной записи\n" +
                                "Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        if (size > 1)
                            search(addNames, addProfessions, addSecondName);
                        else
                        {
                            Console.WriteLine("В досье нет ни одной записи\n" +
                                "Нажмите любую клавишу для продолжения");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }
}
