using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Учет расходов");
        Console.WriteLine("Введите количество расходов от 2 до 40:");
        int count = Convert.ToInt32(Console.ReadLine());

        while (count < 2 || count > 40)
        {
            Console.WriteLine("Неверное количество, введите от 2 до 40!");
            count = Convert.ToInt32(Console.ReadLine());
        }

        string[] names = new string[count];
        double[] price = new double[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Операция " + (i + 1));

            string line = Console.ReadLine();
            string[] parts = line.Split(';');

            names[i] = parts[0].Trim();
            price[i] = Convert.ToDouble(parts[1].Trim());
        }

        Console.WriteLine("Список расходов:");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(names[i] + " - " + price[i] + " rub");
        }

        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Вывод данных");
            Console.WriteLine("2. Статистика");
            Console.WriteLine("3. Сортировка по цене");
            Console.WriteLine("4. Конвертация валюты");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");

            Console.Write("Выберите пункт: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Список расходов:");

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + names[i] + " - " + price[i] + " rub");
                        }

                        break;
                    }

                case 2:
                    {
                        double sum = 0;
                        double max = price[0];
                        double min = price[0];

                        for (int i = 0; i < count; i++)
                        {
                            sum = sum + price[i];

                            if (price[i] > max)
                            {
                                max = price[i];
                            }

                            if (price[i] < min)
                            {
                                min = price[i];
                            }
                        }

                        double average = sum / count;

                        Console.WriteLine("Статистика:");
                        Console.WriteLine("Сумма: " + sum + " rub");
                        Console.WriteLine("Максимальное: " + max + " rub");
                        Console.WriteLine("Минимальное: " + min + " rub");
                        Console.WriteLine("Среднее: " + average + " rub");

                        break;
                    }

                case 3:
                    {
                        for (int i = 0; i < count - 1; i++)
                        {
                            for (int j = 0; j < count - 1 - i; j++)
                            {
                                if (price[j] > price[j + 1])
                                {
                                    double tempPrice = price[j];
                                    price[j] = price[j + 1];
                                    price[j + 1] = tempPrice;

                                    string tempName = names[j];
                                    names[j] = names[j + 1];
                                    names[j + 1] = tempName;
                                }
                            }
                        }

                        Console.WriteLine("Сортировка выполнена!");

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + names[i] + " - " + price[i] + " rub");
                        }

                        break;
                    }

                case 4:
                    {
                        Console.Write("Введите курс рубля к доллару: ");
                        double rate = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Расходы в долларах:");

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(names[i] + " - " + (price[i] / rate) + " USD");
                        }

                        break;
                    }

                case 5:
                    {
                        Console.Write("Введите название для поиска: ");
                        string search = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (names[i].ToLower().Contains(search.ToLower()))
                            {
                                Console.WriteLine(names[i] + " - " + price[i] + " rub");
                                found = true;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Расход не найден.");
                        }

                        break;
                    }

                case 0:
                    Console.WriteLine("Выход");
                    break;

                default:
                    Console.WriteLine("Такого пункта нет");
                    break;
            }
        }
    }
}