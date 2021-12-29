using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* partial - мы можем иметь несколько файлов с определением одного и того же класса, и при компиляции все эти определения будут скомпилированы в одно целое */

partial class BoolVector
{
    private int[] vect; // реализация Булева Вектора - массив целых чисел (1 - Истина, 0 - Ложь)
    private int vectorsize = 0; //размерность Булева Вектора - количество элементов в нем

    /* константы должны быть определены во время компиляции, следовательно инициализировать константу можно только при ее определении */
    private const int vectorsize_deflt = 5; // размерность Булева Вектора по умолчанию

    /* поле только для чтения можно инициализировать при его объявлении либо на уровне класса, либо инициилизировать и изменять в конструкторе,
       инициализировать или изменять его значение в других местах нельзя, можно только считывать его значение. */

    public readonly long ID = GetHashCode();

    // статическое поле, хранящее количество созданных объектов класса
    static int total_vectors = 0; // инкрементируется в конструкторе

    public static String ClassInfo()
    {
        // статический метод вывода информации о классе - вернем название класса и созданных объектов данного класса
        return "Class BoolVector - " + total_vectors + " объектов данного класса создано на данный момент.";

    }

    public BoolVector()
    {
        // конструктор без параметров
        vectorsize = vectorsize_deflt;
        vect = new int[vectorsize];

    }

    static BoolVector()
    {
        // статический конструктор (конструктор типа) :
        // не должен иметь модификатор доступа и не принимает параметров,
        // используется для инициализации статических данных, либо же выполняет действия, которые требуется выполнить только один раз

        total_vectors++;

        BoolVector v1 = new BoolVector("Вызываем закрытый конструктор - создаем экземпляр класса в нашем коде, запрещая его создание снаружи.");

    }

    private BoolVector(string voice_str)
    {
        // закрытый (private) конструктор
        //
        // Если не использовать с конструктором модификатор доступа, то по умолчанию он все равно будет закрытым,
        // однако обычно используется модификатор private, чтобы явно обозначить невозможность создания экземпляров этого класса.
        // Закрытые конструкторы используются, чтобы не допустить создания экземпляров класса при отсутствии полей или методов экземпляра.
        // Обычно используется в классах, содержащих только статические элементы.
        //
        // к примеру мы получим ошибку защиты в программе, если напишем код BoolVector myvector = new BoolVector("That's my Bool Vector");
        //
        // варианты его вызова:
        //
        // см. в статическом конструкторе

        total_vectors++;

        Console.WriteLine(voice_str); // выведем переданную в конструктор параметром строку на консоль

        vectorsize = vectorsize_deflt;
        vect = new int[vectorsize];
    }

    public BoolVector(int size)
    {
        // конструктор с параметром size - размерность вектора

        total_vectors++;

        vectorsize = size;
        vect = new int[vectorsize];
    }

    public BoolVector(int size, int initval = 1)
    {
        // конструктор с параметром по умолчанию
        // второй параметр - значение, которым будут инициализированы все элементы вектора (по умолчанию Истина)

        total_vectors++;

        vectorsize = size;
        vect = new int[vectorsize];

        for (var i = 0; i < vectorsize; i++)
        {
            vect[i] = initval;
        }
    }

    // далее определим специальные методы доступа - Свойства, они обеспечивают простой доступ к полям классов и структур, позволяют узнать их значение или выполнить их установку

    public int vecsize      // свойство для размерности Вектора
    {
        /* пусть метод доступа get получит уровень доступа самого свойства (public), а к методу set явным образом применим модификатор доступа protected 

           protected (защищенный) - доступ к защищенному элементу базового класса может быть получен в производном классе

         */
        get { return vectorsize; }

        protected set { vectorsize = value; }

    }

    public int[] vecdata    // свойство для реализации Вектора
    {
        get { return vect; }
        set
        {
            vect = value;

        }
    }

    // зададим индексатор для доступа к элементам Вектора

    public int this[int index]
    {

        get
        {

            return vect[index];

        }

        set
        {

            vect[index] = value;

        }

    }

    public void fillConsole()
    {
        // метод считывает элементы вектора с консоли

        for (int j = 0; j < vectorsize; j++)
        {

            Console.Write("Введите {0}-й элемент Вектора :", j + 1);

            int consval = Convert.ToInt32(Console.ReadLine());

            if (consval == 0) vect[j] = 0;

            else vect[j] = 1; // если вводится ненулевое значение , то полагаем это Истина

        }

    }

    // статическая переменная - счетчик обращений к генератору случайных чисел - 
    // используется для задания начального значения генератора, чтобы при последовательных вызовах
    // получать разные случайные числа
    static int call_random_counter = 0;

    public void fillRandom()
    {

        // метод заполняет вектор рандомно

        // создание объекта для генерации случайных чисел
        Random rnd = new Random(++call_random_counter);

        for (int j = 0; j < vectorsize; j++)
        {
            // получим случайное число (в диапазоне от 0 до 1)
            int value = rnd.Next(0, 2); // у метода Next() верхний предел не включается в диапазон, поэтому граница диапазона - 2

            vect[j] = value;

        }

    }

    public void printConsole()
    {

        // метод выводит элементы вектора на консоль

        // метод String.Join() сцепляет элементы указанного массива или элементы коллекции, помещая между ними заданный разделитель

        // Console.WriteLine("Вектор : {0}", String.Join(" ", vect)) ;
        // Console.WriteLine("Вектор ID={0} : {1}", ID, String.Join(" ", vect));

        Console.WriteLine("{0} : {1}", this.ToString(), String.Join(" ", vect));

    }

    public int calcZeros()
    {

        // метод подсчитывает количество нулей в векторе

        int zeroQtt = 0; // количество нулей в векторе

        for (int j = 0; j < vectorsize; j++)
        {
            if (vect[j] == 0) zeroQtt++;

        }

        return zeroQtt;

    }

    public int calcOnes()
    {

        // метод подсчитывает количество единиц в векторе

        int onesQtt = 0; // количество единиц в векторе

        for (int j = 0; j < vectorsize; j++)
        {
            if (vect[j] == 1) onesQtt++;

        }

        return onesQtt;
    }

    public BoolVector logicAND(BoolVector v2)
    {

        // метод выполняет поразрядную конъюнкцию двух векторов, возвращает Вектор

        BoolVector tmpVector = new BoolVector(vectorsize);

        for (int j = 0; j < vectorsize; j++)
        {

            tmpVector[j] = vect[j] & v2[j];

        }

        return tmpVector;
    }

    public BoolVector logicOR(BoolVector v2)
    {

        // метод выполняет поразрядную дизъюнкцию двух векторов, возвращает Вектор

        BoolVector tmpVector = new BoolVector(vectorsize);

        for (int j = 0; j < vectorsize; j++)
        {

            tmpVector[j] = vect[j] | v2[j];

        }

        return tmpVector;
    }

    public BoolVector logicNOT()
    {

        // метод выполняет поразрядное отрицание вектора, возвращает Вектор

        BoolVector tmpVector = new BoolVector(vectorsize);

        for (int j = 0; j < vectorsize; j++)
        {

            if (vect[j] == 0) tmpVector[j] = 1;
            else
                if (vect[j] == 1) tmpVector[j] = 0;

        }

        return tmpVector;
    }

}