/* C#, lesson_42  29.04.2023
 * 
Task № 1:
Реалізуйте користувацький тип «Фірма». В ньому має бути інформація про:
- назву фірми,
- дату заснування, 
- профіль бізнесу (маркетинг, IT, і т. д.), 
- ПІБ директора, 
- кількість працівників, 
- адреса. 

Для масиву фірм реалізуйте такі запити: 
• Отримати інформацію про всі фірми. 
• Отримати фірми, які мають у назві слово «Food». 
• Отримати фірми, які працюють у галузі маркетингу. 
• Отримати фірми, які працюють у галузі маркетингу або IT. 
• Отримати фірми з кількістю працівників більшою, ніж 100. 
• Отримати фірми з кількістю працівників у діапазоні від 100 до 300. 
• Отримати фірми, які знаходяться в Лондоні. 
• Отримати фірми, в яких прізвище директора White. 
• Отримати фірми, які засновані більше двох років тому. 
• Отримати фірми з дня заснування яких минуло 123 дні. 
• Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White». 

*/
//--------------------------------------------------------------------------------------------------------
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lesson_42_task_1
{

    public class Company
    {
        public string NAME { get; set; }
        public DateTime DATA { get; set; }
        public string BUSINESS { get; set; }
        public string DIR_NAME { get; set; }
        public string DIR_SURNAME { get; set; }
        public int COUNT_WORKERS { get; set; }
        public string ADDRESS { get; set; }

        public override string ToString()
        {
            return $"Firm name: {NAME}, create data: {DATA:d}, type of activity: {BUSINESS},\n" +
                   $"director: { DIR_NAME } { DIR_SURNAME}, count of workers: { COUNT_WORKERS}, address: { ADDRESS }\n";
        }
    }
//--------------------------------------------------------------------------------------------------------
    class Program
    {
        static void Print (IEnumerable<Company> firms)
        {
            foreach (var firm in firms)
            {
                Console.WriteLine(firm);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_42 \"task 1\"\n");

            List<Company> Firms = new List<Company> {
                new Company { NAME = "IBM", DATA = new DateTime(2023, 05, 01), BUSINESS = "IT", DIR_NAME = "Barak",
                              DIR_SURNAME = "Obama", COUNT_WORKERS = 176, ADDRESS = "Chicago" },
                new Company { NAME = "Apple/Fruit FOOD", DATA = new DateTime(2023, 03, 01), BUSINESS = "Food", DIR_NAME = "Bill",
                              DIR_SURNAME = "Gates", COUNT_WORKERS = 246, ADDRESS = "Atalanta" },
                new Company { NAME = "Samsung", DATA = new DateTime(2023, 01, 01), BUSINESS = "Marketing", DIR_NAME = "Jack",
                              DIR_SURNAME = "Black", COUNT_WORKERS = 132, ADDRESS = "Tokio" },
                new Company { NAME = "Xiaomi", DATA = new DateTime(2022, 01, 01), BUSINESS = "IT", DIR_NAME = "Donald",
                              DIR_SURNAME = "Tramp", COUNT_WORKERS = 82, ADDRESS = "Shanhai" },
                new Company { NAME = "White LG", DATA = new DateTime(2021, 01, 01), BUSINESS = "Transport", DIR_NAME = "John",
                              DIR_SURNAME = "Snow", COUNT_WORKERS = 366, ADDRESS = "London" },
                new Company { NAME = "Cisco", DATA = new DateTime(2020, 01, 01), BUSINESS = "Marketing", DIR_NAME = "Bill",
                              DIR_SURNAME = "Clinton", COUNT_WORKERS = 476, ADDRESS = "Washington" },
                new Company { NAME = "Sony", DATA = new DateTime(2019, 07, 01), BUSINESS = "IT", DIR_NAME = "Joe",
                              DIR_SURNAME = "White", COUNT_WORKERS = 51, ADDRESS = "Osaka" },
                new Company { NAME = "Toyota", DATA = new DateTime(2020, 07, 01), BUSINESS = "Transport", DIR_NAME = "Ronald",
                              DIR_SURNAME = "Reigan", COUNT_WORKERS = 192, ADDRESS = "Paris" },
                new Company { NAME = "ATB-fastfood", DATA = new DateTime(2021, 07, 01), BUSINESS = "Food", DIR_NAME = "George",
                              DIR_SURNAME = "Bush", COUNT_WORKERS = 569, ADDRESS = "Kyiv" },
                new Company { NAME = "Ocean-Sea-Food", DATA = new DateTime(2022, 07, 01), BUSINESS = "Food", DIR_NAME = "Joe",
                              DIR_SURNAME = "Baiden", COUNT_WORKERS = 226, ADDRESS = "Lviv" },
                new Company { NAME = "GM White", DATA = new DateTime(2023, 02, 01), BUSINESS = "Transport", DIR_NAME = "Aaron",
                              DIR_SURNAME = "Black", COUNT_WORKERS = 276, ADDRESS = "London" },
                new Company { NAME = "Google", DATA = new DateTime(2023, 04, 01), BUSINESS = "Marketing", DIR_NAME = "Serg",
                              DIR_SURNAME = "White", COUNT_WORKERS = 97, ADDRESS = "New York" }
            };

            Console.WriteLine("\n------------------- request # 1 -------------------\n");
            var firms = from index in Firms
                       select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 2 -------------------\n");
            firms = from index in Firms
                    where index.NAME.ToLower().Contains("food")
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 3 -------------------\n");
            firms = from index in Firms
                    where index.BUSINESS.ToLower() == "marketing"
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 4 -------------------\n");
            firms = from index in Firms
                    where index.BUSINESS.ToLower() == "marketing" ||
                          index.BUSINESS.ToLower() == "it" 
                    orderby index.BUSINESS
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 5 -------------------\n");
            firms = from index in Firms
                    where index.COUNT_WORKERS > 100 
                    orderby index.COUNT_WORKERS descending
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 6 -------------------\n");
            firms = from index in Firms
                    where index.COUNT_WORKERS > 100 && index.COUNT_WORKERS < 300
                    orderby index.COUNT_WORKERS ascending
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 7 -------------------\n");
            firms = from index in Firms
                    where index.ADDRESS.ToLower() == "london"
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 8 -------------------\n");
            firms = from index in Firms
                    where index.DIR_SURNAME.ToLower() == "white"
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 9 -------------------\n");
            firms = from index in Firms
                    where (DateTime.Now -  index.DATA).Days > 730
                    orderby index.DATA
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 10 -------------------\n");
            firms = from index in Firms
                    where (DateTime.Now - index.DATA).Days > 123
                    orderby index.DATA descending
                    select index;

            Print(firms);


            Console.WriteLine("\n------------------- request # 11 -------------------\n");
            firms = from index in Firms
                    where index.DIR_SURNAME.ToLower() == "black" &&
                          index.NAME.ToLower().Contains("white")
                    select index;

            Print(firms);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
