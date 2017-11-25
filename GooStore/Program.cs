using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using GoodStore.Model;
using GoodStore.Repository;

namespace GoodStore
{
    class Program
    {
        static ProductContext context = new ProductContext();
        static ProductRepository productRepository = new ProductRepository(context);
        static BatchRepository batchRepository = new BatchRepository(context);
        static void Main(string[] args)
        {
            string change;
            Console.WriteLine("Вас приветствует GoodStore");
            do
            {
                Console.WriteLine("Укажите номер действия:");
                Console.WriteLine("1. Добавть новый вид товара");
                Console.WriteLine("2. Добавть накладную с несколькими товарами");
                Console.WriteLine("3. Показать остаток товаров на складе");
                Console.WriteLine("4. Выйти из программы");
                change = Console.ReadLine();
                switch (change)
                {
                    case "1":
                        AddNewProduct();
                        break;
                    case "2":
                        AddWayBill();
                        break;
                    case "3":
                        ShowProductsOnStorage();
                        break;
                    case "4":
                        Console.WriteLine("До новых встреч!");
                        break;
                    default:
                        Console.WriteLine("Повторите, пожалуйста, ввод! Введите число от 1 до 4, " +
                                          "которое соответствует необходимому действию!");
                        break;      
                }
                Console.WriteLine(new string('*', Console.BufferWidth));
            } while (change != "4");
        }

        static void AddNewProduct()
        {
            Product product = new Product();
            try
            {
                Console.WriteLine("Введите название товара:");
                product.Name = Console.ReadLine();
                Console.WriteLine("Введите единицу измерения:");
                product.Unit = Console.ReadLine();
                Console.WriteLine("Введите цену:");
                product.Price = Convert.ToDouble(Console.ReadLine());
                productRepository.Create(product);
                productRepository.SaveChanges();
                Console.WriteLine("Товар успешно добавлен!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            
            
        }

        static void AddWayBill()
        {
            Batch batch = new Batch();
            Console.WriteLine("Введите действие по партии (прибытие или отгрузка)");
            string action = Console.ReadLine().ToLower();
            while (action != "прибытие" && action != "отгрузка")
            {
                Console.WriteLine("Повторите, пожалуйста ввод");
                action = Console.ReadLine().ToLower();
            }
            batch.Action = action;
            batch.Date = DateTime.Now;
            batch.ProductsInBatches = new List<ProductsInBatch>();
            do
            {
                if (batch.ProductsInBatches.Count > 0)
                {
                    Console.WriteLine("Если вы закончили добавлять продукты введите 'выход'");
                }
                ProductsInBatch productsInBatch = new ProductsInBatch();
                Console.WriteLine("Введите продукт ");
                string command = Console.ReadLine();
                if (command.ToLower() == "выход")
                {
                    break;
                }
                Product product = productRepository.Get(command);
                if (product != null)
                {
                    productsInBatch.ProductName = product.Name;
                }
                else
                {
                    Console.WriteLine("Такого продукта в базе нет. Повторите ввод!");
                    continue;
                }
                
                Console.WriteLine("Введите количество");
                productsInBatch.Quantity = Convert.ToInt32(Console.ReadLine());
                batch.ProductsInBatches.Add(productsInBatch);
            } while (true);
            batchRepository.Create(batch);
            batchRepository.SaveChanges();
            Console.WriteLine("Накладная добавлена!");
        }

        static void ShowProductsOnStorage()
        {
            Dictionary<string, int> listOfProducts = new Dictionary<string, int>();
            List<Product> products = productRepository.GetAll().ToList();
            foreach (var product in products)
            {
                listOfProducts.Add(product.Name, 0);
            }
            List<Batch> allBatches = batchRepository.GetAll().ToList();
            foreach (var batch in allBatches)
            {
                if (batch.Action == "прибытие")
                {
                    foreach (var product in batch.ProductsInBatches)
                    {
                        listOfProducts[$"{product.ProductName}"] += product.Quantity;
                    }
                }
                else
                {
                    foreach (var product in batch.ProductsInBatches)
                    {
                        listOfProducts[$"{product.ProductName}"] -= product.Quantity;
                    }
                }
            }
            foreach (var product in listOfProducts)
            {
                Console.WriteLine($"На складе {product.Key} в количестве {product.Value} ");
            }

        }
    }
}
