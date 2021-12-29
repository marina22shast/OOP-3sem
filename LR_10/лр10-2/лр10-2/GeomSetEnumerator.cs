using System;
using System.Collections; // обязательно !!
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// в соответствии с условием преобразовали необобщенный класс (тип) GFiguresEnumerator в обобщенный GFiguresEnumerator<T>

class GFiguresEnumerator<T> : IEnumerator  // реализуем обобщенный интерфейс IEnumerator
{

    /*
    если мы хотим реализовать сами IEnumerator - мы должны реализовать :
    Свойство:
    object Current { get ; }
    Методы:
    bool MoveNext();
    void Reset() ;
    */

    Stack<T> Figures;
    int position = -1;

    public GFiguresEnumerator(Stack<T> figures)
    {
        this.Figures = figures;
    }
    public object Current
    {
        get
        {
            if (position == -1 || position >= Figures.Count)
                throw new InvalidOperationException();
            return Figures.ElementAt(position);
        }
    }

    public bool MoveNext()
    {
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
        position = -1;
    }
}