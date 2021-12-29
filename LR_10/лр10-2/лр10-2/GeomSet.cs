using System;
using System.Collections; // обязательно !!
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// в соответствии с условием преобразовали необобщенный класс (тип) GeomSet в обобщенный GeomSet<T>

public class GeomSet<T> // класс Геометрический набор
{

    public Stack<T> Figures; // коллекция - набор геометрических фигур

    public GeomSet() // конструктор
    {
        Figures = new Stack<T>();

    }

    public IEnumerator GetEnumerator()
    {
        /* !! для перебора коллекции через foreach достаточно определить публичный метод GetEnumerator, который бы возвращал объект IEnumerator
         
          и вернуть экземпляр нашего собственного класса GFiguresEnumerator
         */

        return new GFiguresEnumerator<T>(Figures);
    }

    public void Add(T var_figure)
    {
        /* метод добавляет фигуру в набор */

        Figures.Push(var_figure);

    }

    public void Remove()
    {
        /* метод удаляет фигуру из набора*/

        Figures.Pop();

    }

    public void Find(T find_val)
    {
        /* метод выводит на консоль инфо о всех фигурах искомого типа */

        int c = 0; // счетчик найденных фигур

        foreach (var figure in Figures)
        {

            if (figure.Equals(find_val))
            {
                Console.WriteLine("Заданное значение присутствует в коллекции : {0}", figure.ToString());

                c++;

            }

        }

        if (c == 0) Console.WriteLine("В коллекции нет таких значений.");

    }

    public void Print()
    {
        /* метод выводит на консоль инофрмацию об объектах Геометрического набора */

        foreach (var figure in Figures)
        {
            Console.Write(figure.ToString() + " ");

        }

    }

}