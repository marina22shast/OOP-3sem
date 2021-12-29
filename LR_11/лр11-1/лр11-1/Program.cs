/*
    1. Задайте массив типа string, содержащий 12 месяцев (June, July, May, December, January ….). 
    Используя LINQ to Object напишите :
    запрос выбирающий последовательность месяцев с длиной строки равной n, 
    запрос возвращающий только летние и зимние месяцы, 
    запрос вывода месяцев в алфавитном порядке, 
    запрос выводящий месяцы содержащие букву «u» и длиной имени не менее 4-х.
    запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х
*/

using System;
using System.Collections.Generic;
using System.Linq; //ПОДКЛЮЧАТЬ!
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] montharray = { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November" };

            Console.Write("Введите искомую длину строки с названием месяца : ");
            int reqlen = Convert.ToInt32(Console.ReadLine());

            // a. запрос выбирающий последовательность месяцев с длиной строки равной n
            var selectedMonths = from m in montharray // определяем каждый объект из montharray как m
                                 where m.Length == reqlen // фильтрация по критерию
                                 select m; // выбираем объект
            Console.Write("последовательность месяцев с длиной строки {0} : ", reqlen);
            if (selectedMonths.Count() == 0) Console.Write("нет таких месяцев.");
            else
            {
                foreach (string s in selectedMonths) Console.Write(s + " ");
            }

            // b. запрос возвращающий только летние и зимние месяцы
            selectedMonths = from m in montharray // определяем каждый объект из montharray как m
                             where m.ToUpper()[0] == 'D' || m.ToUpper()[0] == 'J' || m.ToUpper()[0] == 'F' || m.ToUpper()[1] == 'U'  //фильтрация по критерию
                             select m; // выбираем объект
            Console.Write("\n\nпоследовательность летних и зимних месяцев : ");
            foreach (string s in selectedMonths) Console.Write(s + " ");

            // c. запрос вывода месяцев в алфавитном порядке
            selectedMonths = from m in montharray // определяем каждый объект из montharray как m
                             orderby m  // упорядочиваем по возрастанию (по умолчанию)
                             select m; // выбираем объект
            Console.Write("\n\nпоследовательность месяцев в алфавитном порядке : ");
            foreach (string s in selectedMonths) Console.Write(s + " ");

            // d. запрос возвращающий месяцы содержащие букву «u» и длиной имени не менее 4-х
            selectedMonths = from m in montharray // определяем каждый объект из montharray как m
                             where m.Contains('u') && m.Length >= 4  // фильтрация по критерию
                             select m; // выбираем объект
            Console.Write("\n\nпоследовательность месяцев, содержащих букву «u» и длиной имени не менее 4-х : ");
            foreach (string s in selectedMonths) Console.Write(s + " ");

            // e. запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х
            int result = (from m in montharray // определяем каждый объект из montharray как m
                          where m.Contains('u') && m.Length >= 4  // фильтрация по критерию
                          select m).Count(); // выбираем объект
            Console.Write("\nКоличество месяцев, содержащих букву 'u' и длиной имени не мене 4-х: {0}", result);


            Console.ReadKey();
        }
    }
}