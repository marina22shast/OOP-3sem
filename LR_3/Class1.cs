using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* partial - мы можем иметь несколько файлов с определением одного и того же класса, и при компиляции все эти определения будут скомпилированы в одно целое */

partial class BoolVector
{

    public bool Equals(BoolVector v2)
    {

        // метод выполняет поразрядное сравнение двух векторов, 
        // возвращает булево значение (true если вектора поразрядно равны и false в противном случае)

        bool result = true;

        for (int j = 0; j < vectorsize; j++)
        {

            if (vect[j] != v2[j])
            {
                // обнаружено неравенство значений в разряде

                result = false;

                break; // выходим из цикла for
            }

        }

        return result;
    }

    new public static long GetHashCode()
    {
        /* cтатический метод – это метод, который не имеет доступа к полям объекта, и для вызова такого метода не нужно создавать экземпляр (объект) класса, в котором он объявлен */

        /* используем new для переопределения метода object.GetHashCode() */

        // занесем в наш ID уникальное значение (хеш) - возьмем в качестве него количество 100-наносекундных интервалов (тиков), представляющих текущую дату и время

        long result = DateTime.Now.Ticks;

        // добавим случайное значение, чтобы наш хеш был уникален для объектов созданных в одно и то же время с точностью до миллисекунды

        // создание объекта для генерации случайных чисел
        Random rnd = new Random(++call_random_counter);

        result = result + rnd.Next(0, 999999); // прибавим случайное число от 0 до 999999

        return result;
    }

    new public String ToString()
    {
        // метод выводит информацию об объекте - его хеш

        /* используем new для переопределения метода object.ToString() */

        String result = "Объект Булев Вектор с хеш-кодом " + ID;

        return result;
    }

    /* в одном из методов класса для работы с аргументами используйте ref - и out-параметры */

    public void get_id(ref string str_id, out long long_id)
    {
        // метод чере ref-параметр (ссылочный) возвращает строковое представление ID,
        // через out-параметр возвращает числовое значение ID

        str_id = ID.ToString();

        long_id = ID;

    }

}