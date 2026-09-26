using System;
using System.Collections.Generic;

enum Category
{
    Products,
    Electronics,
    Clothing
}

class Product
{
    public int Code;
    public string Name;
    public double Price;
    public int Quantity;
    public Category Category;
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        int nextCode = 1;

        Product product1 = new Product
        {
            Code = nextCode,
            Name = "Хлеб",
            Price = 65,
            Quantity = 10,
            Category = Category.Products
        };

        products.Add(product1);
        nextCode++;

        Product product2 = new Product
        {
            Code = nextCode,
            Name = "Наушники",
            Price = 2500,
            Quantity = 5,
            Category = Category.Electronics
        };

        products.Add(product2);
        nextCode++;

        Product product3 = new Product
        {
            Code = nextCode,
            Name = "Футболка",
            Price = 1500,
            Quantity = 7,
            Category = Category.Clothing
        };

        products.Add(product3);
        nextCode++;

        Product product4 = new Product
        {
            Code = nextCode,
            Name = "Молоко",
            Price = 90,
            Quantity = 0,
            Category = Category.Products
        };

        products.Add(product4);
        nextCode++;

        Product product5 = new Product
        {
            Code = nextCode,
            Name = "Клавиатура",
            Price = 3200,
            Quantity = 3,
            Category = Category.Electronics
        };

        products.Add(product5);
        nextCode++;

        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать товары");
            Console.WriteLine("2. Добавить товар");
            Console.WriteLine("3. Удалить товар");
            Console.WriteLine("4. Заказать поставку");
            Console.WriteLine("5. Продать товар");
            Console.WriteLine("6. Поиск товаров");
            Console.WriteLine("0. Выход");

            Console.Write("Выберите команду: ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
            {
                Console.Write("Неверная команда, введите число от 0 до 6: ");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Список товаров:");

                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine(products[i].Code + ". " + products[i].Name + " - " + products[i].Price + " руб.");
                    }

                    break;

                case 2:
                    {
                        Console.Write("Введите название товара: ");
                        string name = Console.ReadLine();

                        while (name == null || name.Trim() == "")
                        {
                            Console.Write("Название не может быть пустым. Введите название: ");
                            name = Console.ReadLine();
                        }

                        Console.Write("Введите цену: ");
                        double price;

                        while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.Write("Неверная цена. Введите цену еще раз: ");
                        }

                        Console.Write("Введите количество: ");
                        int quantity;

                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.Write("Неверное количество. Введите количество еще раз: ");
                        }

                        Console.WriteLine("Выберите категорию:");
                        Console.WriteLine("1. Products");
                        Console.WriteLine("2. Electronics");
                        Console.WriteLine("3. Clothing");

                        int categoryChoice;

                        while (!int.TryParse(Console.ReadLine(), out categoryChoice) ||
                            categoryChoice < 1 || categoryChoice > 3)
                        {
                            Console.Write("Неверная категория. Введите число от 1 до 3: ");
                        }

                        Category category;

                        if (categoryChoice == 1)
                        {
                            category = Category.Products;
                        }
                        else if (categoryChoice == 2)
                        {
                            category = Category.Electronics;
                        }
                        else
                        {
                            category = Category.Clothing;
                        }

                        Product product = new Product
                        {
                            Code = nextCode,
                            Name = name,
                            Price = price,
                            Quantity = quantity,
                            Category = category
                        };

                        products.Add(product);
                        nextCode++;

                        Console.WriteLine("Товар добавлен!");

                        break;
                    }

                case 3:
                    {
                        Console.Write("Введите код товара для удаления: ");
                        int code;

                        while (!int.TryParse(Console.ReadLine(), out code) || code <= 0)
                        {
                            Console.Write("Неверный код. Введите код еще раз: ");
                        }

                        bool found = false;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].Code == code)
                            {
                                products.RemoveAt(i);
                                found = true;
                                Console.WriteLine("Товар удален.");
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Товар с таким кодом не найден.");
                        }

                        break;
                    }

                case 4:
                    {
                        Console.Write("Введите код товара: ");
                        int code;

                        while (!int.TryParse(Console.ReadLine(), out code) || code <= 0)
                        {
                            Console.Write("Неверный код. Введите код еще раз: ");
                        }

                        bool found = false;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].Code == code)
                            {
                                Console.Write("Введите количество товара: ");
                                int quantity;

                                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                                {
                                    Console.Write("Неверное количество. Введите количество еще раз: ");
                                }

                                products[i].Quantity = products[i].Quantity + quantity;

                                Console.WriteLine("Поставка выполнена.");
                                Console.WriteLine("Новое количество: " + products[i].Quantity);

                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Товар с таким кодом не найден.");
                        }

                        break;
                    }

                case 5:
                    {
                        Console.Write("Введите код товара: ");
                        int code;

                        while (!int.TryParse(Console.ReadLine(), out code) || code <= 0)
                        {
                            Console.Write("Неверный код. Введите код еще раз: ");
                        }

                        bool found = false;

                        for (int i = 0; i < products.Count; i++)
                        {
                            if (products[i].Code == code)
                            {
                                Console.WriteLine("Товар: " + products[i].Name);
                                Console.WriteLine("Остаток на складе: " + products[i].Quantity);

                                Console.Write("Введите количество для продажи: ");
                                int quantity;

                                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                                {
                                    Console.Write("Неверное количество. Введите количество еще раз: ");
                                }

                                if (quantity <= products[i].Quantity)
                                {
                                    products[i].Quantity = products[i].Quantity - quantity;

                                    Console.WriteLine("Продажа выполнена.");
                                    Console.WriteLine("Осталось на складе: " + products[i].Quantity);
                                }
                                else
                                {
                                    Console.WriteLine("Нельзя продать больше товара, чем есть на складе.");
                                }

                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Товар с таким кодом не найден.");
                        }

                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("Поиск товаров");
                        Console.WriteLine("1. Поиск по коду");
                        Console.WriteLine("2. Поиск по названию");
                        Console.WriteLine("3. Поиск по категории");

                        Console.Write("Выберите способ поиска: ");
                        int searchChoice;

                        while (!int.TryParse(Console.ReadLine(), out searchChoice) ||
                            searchChoice < 1 || searchChoice > 3)
                        {
                            Console.Write("Неверный выбор. Введите число от 1 до 3: ");
                        }

                        bool found = false;

                        if (searchChoice == 1)
                        {
                            Console.Write("Введите код товара: ");
                            int code;

                            while (!int.TryParse(Console.ReadLine(), out code) || code <= 0)
                            {
                                Console.Write("Неверный код. Введите код еще раз: ");
                            }

                            for (int i = 0; i < products.Count; i++)
                            {
                                if (products[i].Code == code)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Код: " + products[i].Code);
                                    Console.WriteLine("Название: " + products[i].Name);
                                    Console.WriteLine("Цена: " + products[i].Price + " руб.");
                                    Console.WriteLine("Количество: " + products[i].Quantity);

                                    if (products[i].Quantity > 0)
                                    {
                                        Console.WriteLine("На складе: Да");
                                    }
                                    else
                                    {
                                        Console.WriteLine("На складе: Нет");
                                    }

                                    Console.WriteLine("Категория: " + products[i].Category);

                                    found = true;
                                    break;
                                }
                            }
                        }
                        else if (searchChoice == 2)
                        {
                            Console.Write("Введите название товара: ");
                            string search = Console.ReadLine();

                            while (search == null || search.Trim() == "")
                            {
                                Console.Write("Название не может быть пустым. Введите название: ");
                                search = Console.ReadLine();
                            }

                            for (int i = 0; i < products.Count; i++)
                            {
                                if (products[i].Name.ToLower().Contains(search.ToLower()))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Код: " + products[i].Code);
                                    Console.WriteLine("Название: " + products[i].Name);
                                    Console.WriteLine("Цена: " + products[i].Price + " руб.");
                                    Console.WriteLine("Количество: " + products[i].Quantity);

                                    if (products[i].Quantity > 0)
                                    {
                                        Console.WriteLine("На складе: Да");
                                    }
                                    else
                                    {
                                        Console.WriteLine("На складе: Нет");
                                    }

                                    Console.WriteLine("Категория: " + products[i].Category);

                                    found = true;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Выберите категорию:");
                            Console.WriteLine("1. Products");
                            Console.WriteLine("2. Electronics");
                            Console.WriteLine("3. Clothing");

                            int categoryChoice;

                            while (!int.TryParse(Console.ReadLine(), out categoryChoice) ||
                                categoryChoice < 1 || categoryChoice > 3)
                            {
                                Console.Write("Неверная категория. Ведите число от 1 до 3: ");
                            }

                            Category selectedCategory;

                            if (categoryChoice == 1)
                            {
                                selectedCategory = Category.Products;
                            }
                            else if (categoryChoice == 2)
                            {
                                selectedCategory = Category.Electronics;
                            }
                            else
                            {
                                selectedCategory = Category.Clothing;
                            }

                            for (int i = 0; i < products.Count; i++)
                            {
                                if (products[i].Category == selectedCategory)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Код: " + products[i].Code);
                                    Console.WriteLine("Название: " + products[i].Name);
                                    Console.WriteLine("Цена: " + products[i].Price + " руб.");
                                    Console.WriteLine("Количество: " + products[i].Quantity);

                                    if (products[i].Quantity > 0)
                                    {
                                        Console.WriteLine("На складе: Да");
                                    }
                                    else
                                    {
                                        Console.WriteLine("На складе: Нет");
                                    }

                                    Console.WriteLine("Категория: " + products[i].Category);

                                    found = true;
                                }
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Товар не найден.");
                        }

                        break;
                    }

                case 0:
                    Console.WriteLine("Выход");
                    break;
            }
        }
    }
}