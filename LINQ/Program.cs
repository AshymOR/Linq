using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise11();
            //Exercise12();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise29();
            //Exercise30();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var OutofStock = products.Where(product => product.UnitsInStock < 1);

            PrintProductInformation(OutofStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = products.Where(product => product.UnitsInStock > 0 && product.UnitPrice > 3);

            PrintProductInformation(result);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var result = customers.Where(customer => customer.Region == "WA");

            PrintCustomerInformation(result);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                          select new { ProductName = product.ProductName };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                         select new { PriceIncrease = product.UnitPrice * 1.25M };
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                         select new { UpperName = product.ProductName.ToUpper() + ", " + product.Category.ToUpper() };

            foreach (var product in result)
            {
                Console.WriteLine(product.UpperName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                         select new { ID = product.ProductID, name = product.ProductName, price = product.UnitPrice, cat = product.Category, stock = product.UnitsInStock, ReOrder = product.UnitsInStock < 3 };

            foreach(var product in result)
            {
                Console.WriteLine(product.ID + ", " + product.name + ", " + product.price + ", " + product.cat + ", " + product.stock + ", " + product.ReOrder);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                         select new { StockPrice = product.UnitPrice * product.UnitsInStock + ", " + product.ProductID + ", " + product.ProductName + ", " + product.Category + ", " + product.UnitPrice + ", " + product.UnitsInStock };

            foreach(var product in result)
            {
                Console.WriteLine(product.StockPrice);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var result = DataLoader.NumbersA.Where(i => i % 2 == 0);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            

            
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            IEnumerable<int> result = (from i in DataLoader.NumbersC
                                           where i % 2 == 1
                                           select i).Take(3);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            IEnumerable<int> result = DataLoader.NumbersB.Skip(3);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            

            
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            IEnumerable<int> result = DataLoader.NumbersC.TakeWhile(i => i < 6);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            IEnumerable<int> result = DataLoader.NumbersC.SkipWhile(i => !(i % 3 == 0)).Skip(1);
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            IEnumerable<Product> OrderedProducts = DataLoader.LoadProducts().OrderBy(p => p.ProductName);
            PrintProductInformation(OrderedProducts);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            IEnumerable<Product> OrderedProduct = DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock);
            PrintProductInformation(OrderedProduct);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> result = DataLoader.LoadProducts();
            IEnumerable<Product> sortedProducts = from p in result
                                                  orderby p.Category, p.UnitPrice descending
                                                  select p;
            PrintProductInformation(sortedProducts);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            foreach (int i in DataLoader.NumbersB.Reverse())
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var result = from p in DataLoader.LoadProducts()
                        group p by p.Category into pCategories
                        select new
                        {
                            CatName = pCategories.Key,
                            Contents = pCategories
                        };
            foreach (var category in result)
            {
                Console.WriteLine(category.CatName);
                foreach (var product in category.Contents)
                {
                    Console.WriteLine(product.ProductName);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var result = from p in DataLoader.LoadProducts()
                             group p by p.Category into cats
                             select cats.Key;
            foreach (string category in result)
            {
                Console.WriteLine(category);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var result = from p in DataLoader.LoadProducts()
                                where p.ProductID == 789
                                select p;
            if (result.Count() != 0)
            {
                Console.WriteLine("Product 789 is real");
            }
            else
            {
                Console.WriteLine("Ther is no Product 789.");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var result = from p in DataLoader.LoadProducts()
                             group p by p.Category;
            var OutofStock = from cat in result
                            where cat.Min(p => p.UnitsInStock) == 0
                            select cat.Key;
            foreach (var category in OutofStock)
            {
                Console.WriteLine(category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var result = from p in DataLoader.LoadProducts()
                         group p by p.Category;
            var InStock = from cat in result
                          where cat.Min(p => p.UnitsInStock) >= 1
                          select cat.Key;
            foreach (var category in InStock)
            {
                Console.WriteLine(category);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {

            int oddCount = DataLoader.NumbersA.Count(i => i % 2 == 1);
            Console.WriteLine("There are " + oddCount + "odd numbers in NumbersA");
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var result = from p in DataLoader.LoadProducts()
                             group p by p.Category into cats
                             select new
                             {
                                 cats.Key,
                                 Count = cats.Sum(p => p.UnitsInStock)
                             };
            foreach (var category in result)
            {
                Console.WriteLine(category.Key + " has " + category.Count + " items in stock");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var result = from p in DataLoader.LoadProducts()
                         group p by p.Category into cats
                         select new
                         {
                             cats.Key,
                             lowProduct = (from prod in cats
                                           orderby prod.UnitPrice
                                           select prod.ProductName).First()
                         };

            foreach (var category in result)
            {
                Console.WriteLine("The lowest priced product in " + category.Key + " is " + category.lowProduct);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }
    }
}
