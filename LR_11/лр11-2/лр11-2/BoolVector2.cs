using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class BoolVector
{

    public override bool Equals(object obj)
    {
        BoolVector v2 = obj as BoolVector;

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

    public override int GetHashCode()
    {

        // занесем в наш ID уникальное значение (хеш)

        int result = 0;

        // создание объекта для генерации случайных чисел
        Random rnd = new Random(++call_random_counter);

        result = result + rnd.Next(0, 999999); // прибавим случайное число от 0 до 999999

        return result;

    }

    public String GetInfo()
    {
        // метод выводит информацию об объекте - его хеш

        String result = "Объект Булев Вектор с хеш-кодом " + ID;

        return result;
    }

    public override String ToString()
    {
        // метод возвращает строковое представление вектора, состоящего из нулей и единиц

        String result = "";

        for (int i = 0; i < vecsize; i++) result += vect[i];

        return result;

    }

    /* в одном из методов класса для работы с аргументами используйте ref - и out-параметры */

    public void get_id(ref string str_id, out int int_id)
    {
        // метод чере ref-параметр (ссылочный) возвращает строковое представление ID,
        // через out-параметр возвращает числовое значение ID

        str_id = ID.ToString();

        int_id = ID;

    }

}