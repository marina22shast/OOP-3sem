/*
   
    1. Создайте класс по варианту, определите в нем свойства и методы, реализуйте указанный интерфейс и другие при необходимости, 
      соберите объекты класса в коллекцию (можно сделать специальных класс с вложенной коллекцией и методами ею управляющими),
      продемонстрируйте работу с ней (добавление/удаление/поиск/вывод).
      Тип                       Интерфейс       Коллекция
      ---------------------------------------------------
      Геометрическая фигура     IEnumerator     Stack
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
        static void Main(string[] args)
        {
            // создадим объект Геометрический набор
            GeomSet MyGSet = new GeomSet();

            // добавим в набор фигуры
            MyGSet.Add(new GeomFigure("Ромб", 56.21, 94.18));
            MyGSet.Add(new GeomFigure("Треугольник", 80.17, 94.18));
            MyGSet.Add(new GeomFigure("Квадрат", 34.12, 94.18));

            // выведем информацию о всех объектах коллекции
            MyGSet.Print();

            // удалим фигуру из коллекции
            Console.WriteLine("Удалим фигуру из коллекции :");
            MyGSet.Remove();
            // выведем информацию о всех объектах Геометрического набора
            MyGSet.Print();

            // найдем объекты Геометрического набора заданного типа
            Console.WriteLine("Введите искомый тип фигуры");
            string figure_type = Console.ReadLine();
            MyGSet.Find(figure_type);


            Console.ReadKey();
        }
    }
}