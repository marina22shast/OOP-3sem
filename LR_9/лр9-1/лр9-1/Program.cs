/*
1. Используя делегаты (множественные) и события промоделируйте ситуации, приведенные в таблице ниже. 
Можете добавить новые типы (классы), если существующих недостаточно. При реализации методов везде где возможно использовать лямбда-выражения.

Создать класс Пользователь с событиями upgrade и work. В main создать некоторое количество объектов (ПО). 
Подпишите объекты на события произвольным образом. Реакция на события может быть следующая: обновление версии, вывод сообщений и т.п. 
Проверить результаты изменения объектов после наступления событий.
ТЕОРИЯ:
Делегаты представляют такие объекты, которые указывают на методы. 
То есть делегаты - это указатели на методы и с помощью делегатов мы можем вызвать данные методы.
Анонимные методы представляют собой безымянный кодовый блок, передаваемый конструктору делегата.
Анонимные методы используются для создания экземпляров делегатов.
Анонимный метод не может существовать сам по себе, он используется для инициализации экземпляра делегата.
Лямбда-выражения есть упрощенная запись анонимных методов!
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // определим делегат на метод, который (метод) не принимает и не возвращает значение
        delegate void PrintPOInfo();

        static void Main(string[] args)
        {
            // создаем объект пользователя
            SoftWareUser myuser = new SoftWareUser("Шастовская Марина", "secret21", "инженер по сопровождению");
            myuser.GetUserFullInfo();
            // создаем три объекта ПО
            Software soft1 = new Software("Adobe Photoshop", 11);
            Software soft2 = new Software("MS Word", 8);
            Software soft3 = new Software("Visual Studio", 9);
            // выведем текущее состояние ПО:
            Console.WriteLine("\nТекущее состояние ПО :");
            PrintPOInfo dlgt_print = null;
            // множественный делегат
            dlgt_print += soft1.PrnSoftInfo;
            dlgt_print += soft2.PrnSoftInfo;
            dlgt_print += soft3.PrnSoftInfo;
            dlgt_print();
            // регистрируем обработчики - по сути подписываем объекты ПО на события
            myuser.UpgradeNotify += soft1.OnUpgrade;
            myuser.WorkNotify += soft2.OnWork;
            myuser.WorkNotify += soft3.OnWork;

            myuser.DoUpgrade(12); // инициируем обновление ПО (Upgrade) на версию 12
            myuser.DoWork(); // инициируем запуск ПО (Work)

            // выведем текущее состояние ПО:
            Console.WriteLine("\nТекущее состояние ПО :");
            dlgt_print();

            Console.ReadKey();

        }
    }
}