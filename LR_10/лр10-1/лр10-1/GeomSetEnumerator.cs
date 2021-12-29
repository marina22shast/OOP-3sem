using System;
using System.Collections; // обязательно !!
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GFiguresEnumerator : IEnumerator  // реализуем интерфейс IEnumerator
{

    /*
    если мы хотим реализовать сами необобщенный IEnumerator - мы должны реализовать :
    Свойство:
    object Current { get ; }
    Методы:
    bool MoveNext();
    void Reset() ;
    */

    Stack<GeomFigure> Figures;
    int position = -1;
    public GFiguresEnumerator(Stack<GeomFigure> figures)
    {
        this.Figures = figures;
    }
    public object Current
    {
        //чтобы вернуть текущий элемент
        get
        {
            if (position == -1 || position >= Figures.Count)
                throw new InvalidOperationException();
            return Figures.ElementAt(position);
        }
    }

    public bool MoveNext()
    {
        //переместиться на следующий элемент коллекции
        if (position < Figures.Count - 1)
        {
            position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        //сбросить счетчик позиции на начальное значение
        position = -1;
    }
}