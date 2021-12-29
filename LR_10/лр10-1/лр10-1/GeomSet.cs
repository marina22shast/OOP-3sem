using System;
using System.Collections; // обязательно !!
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GeomSet // класс Геометрический набор
{

    public Stack<GeomFigure> Figures; // коллекция - набор геометрических фигур

    public GeomSet() // конструктор
    {
        Figures = new Stack<GeomFigure>();

    }

    public IEnumerator GetEnumerator()
    {
        /* !! для перебора коллекции через foreach достаточно определить публичный метод GetEnumerator, который бы возвращал объект IEnumerator
         
          и вернуть экземпляр нашего собственного класса GFiguresEnumerator
         */

        return new GFiguresEnumerator(Figures);
    }

    public void Add(GeomFigure var_figure)
    {
        /* метод добавляет фигуру в набор */

        Figures.Push(var_figure);

    }

    public void Remove()
    {
        /* метод удаляет фигуру из набора */

        Figures.Pop();

    }

    public void Find(string find_type)
    {
        /* метод выводит на консоль инфо о всех фигурах искомого типа */

        int c = 0; // счетчик найденных фигур

        foreach (var figure in Figures)
        {

            if (figure.Type.Equals(find_type))
            {
                figure.GetInfo();

                c++;

            }

        }

        if (c == 0) Console.WriteLine("В коллекции нет таких фигур.");

    }

    public void Print()
    {
        /* метод выводит на консоль инофрмацию об объектах Геометрического набора */

        foreach (var figure in Figures) figure.GetInfo();

    }

}