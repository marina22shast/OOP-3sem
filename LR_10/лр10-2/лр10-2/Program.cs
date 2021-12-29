/*
   
    2. Создайте универсальную коллекцию в соответствии с вариантом задания и заполнить ее данными встроенного типа .Net (int, char,…).
    
      Тип                       Интерфейс       Коллекция
      ---------------------------------------------------
      Геометрическая фигура     IEnumerator<T>   Stack<T>
        a. Выведите коллекцию на консоль
        b. Удалите из коллекции n последовательных элементов
        c. Добавьте другие элементы (используйте все возможные методы добавления для вашего типа коллекции).
        d. Создайте вторую коллекцию (из таблицы выберите другой тип коллекции) и заполните ее данными из первой коллекции.
      Тип                       Интерфейс       Коллекция
      ---------------------------------------------------
                                                 Queue<T>
        e. Выведите вторую коллекцию на консоль.
           (в случае не совпадения количества параметров (например, LinkedList<T> и Dictionary<Tkey, TValue>), при нехватке - генерируйте ключи, в случае избыточности – оставляйте TValue)
        f. Найдите во второй коллекции заданное значение.
*/

using System;
using System.Collections; // обязательно !!
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            // сделали коллекцию задания 1 (член Figures класса GeomSet) УНИВЕРСАЛЬНОЙ (ОБОБЩЕННОЙ) и соответственно сам класс GeomSet также

            // создадим объект Геометрический набор и тем самым в нем - требуемую универсальную коллекцию (Stack<T> Figures)
            GeomSet<int> MyGSet = new GeomSet<int>();

            // добавим в коллекцию объекты
            MyGSet.Add(300);
            MyGSet.Add(254);
            MyGSet.Add(11);
            MyGSet.Add(476);

            Console.WriteLine("\nКоллекция после инициализации:");
            MyGSet.Print(); // выведем коллекцию на консоль

            // удалим из коллекции два последовательных элемента
            MyGSet.Remove();
            MyGSet.Remove();

            Console.WriteLine("\nКоллекция после удаления двух последовательных элементов:");
            MyGSet.Print(); // выведем коллекцию на консоль

            // добавим другие элементы
            MyGSet.Add(100);
            MyGSet.Add(200);
            MyGSet.Add(300);
            MyGSet.Add(750);

            Console.WriteLine("\nКоллекция после добавления элементов:");
            MyGSet.Print(); // выведем коллекцию на консоль

            // создадим вторую коллекцию (тип коллекции Queue) и заполним ее данными из первой коллекции
            Queue<int> MyCollection2 = new Queue<int>(MyGSet.Figures);
            Console.WriteLine("\nВторая коллекция после заполнения ее элементами первой :");
            foreach (var x in MyCollection2) Console.Write(x.ToString() + " ");
            /* либо так можно :
            IEnumerator ie = MyCollection2.GetEnumerator(); // получаем IEnumerator
            while (ie.MoveNext())   // пока операция перехода к следующему элементу не вернет false (этот факт - признак конца коллекции)
            {
                int item = (int)ie.Current; // берем элемент на текущей позиции
                Console.Write(item + " ");
            }
            ie.Reset(); // сбрасываем хранитель текущего положения в коллекции в начало коллекции
            */

            // найдем во второй коллекции заданное знечение
            Console.WriteLine("Введите искомое значение : ");
            int val_search = Convert.ToInt32(Console.ReadLine());
            if (MyCollection2.Contains(val_search)) Console.WriteLine("Данное значение присутствует во второй коллекции.");
            else Console.WriteLine("Данное значение отсутствует во второй коллекции.");

            Console.ReadKey();

        }
    }
}