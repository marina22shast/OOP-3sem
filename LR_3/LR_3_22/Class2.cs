using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* partial - мы можем иметь несколько файлов с определением одного и того же класса, и при компиляции все эти определения будут скомпилированы в одно целое */
/*readonly-поле только для чтения можно инициализировать при его объявлении либо на уровне класса, либо инициилизировать и изменять в конструкторе,
       инициализировать или изменять его значение в других местах нельзя, можно только считывать его значение. */
//GetHashCode()-Служит хэш-функцией по умолчанию. // статическое поле, хранящее количество созданных объектов класса
partial class BoolVector
{
    private int[] vect; // реализация Булева Вектора - массив целых чисел (1 - Истина, 0 - Ложь)
    private int vectorsize = 0; //размерность Булева Вектора - количество элементов в нем

    private const int vectorsize_deflt = 5; 

    public readonly long ID = GetHashCode();
    
    static int total_vectors = 0; // инкрементируется в конструктор
    public static String ClassInfo()
    {
        // статический метод вывода информации о классе - вернем название класса и созданных объектов данного класса
        return "Class BoolVector - " + total_vectors + " объектов данного класса создано на данный момент.";

    }
 // конструктор без параметров
    public BoolVector()
    {
        vectorsize = vectorsize_deflt; //присвоили размерность Булева Вектора по умолчанию
        vect = new int[vectorsize];

    }
    // статический конструктор (конструктор типа) :
    // не должен иметь модификатор доступа и не принимает параметров,
    // используется для инициализации статических данных, либо же выполняет действия, которые требуется выполнить только один раз

    static BoolVector()
    {
       
        total_vectors++;

        BoolVector v1 = new BoolVector("Вызываем закрытый конструктор - создаем экземпляр класса в нашем коде, запрещая его создание снаружи.");
        //экземпляр класса  BoolVector
    }
    // закрытый конструктор,обозначает невозможность создания экземпляров этого класса.// статическое поле, хранящее количество созданных объектов класса
    private BoolVector(string voice_str)
    {
        total_vectors++;

        Console.WriteLine(voice_str); 

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
  //Не менее трех конструкторов (с параметрами и без, а также с   параметрами по умолчанию );
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
    /*это индексатор чтобы 0 и 1 в векторе мы могли к ним обращаться по индексу как в массиве.
когда мы будем обращаться к элементу вектора (а элемент вектора 0 или 1) через индекс, то вызовется get
а если захотим элемент вектора (сменить например первый 0 в векторе на 1) и обратимся по индексу, то вызовется set*/
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

    public void printConsole()// метод выводит элементы вектора на консоль
    {

        // Console.WriteLine("Вектор : {0}", String.Join(" ", vect)) ;
        // Console.WriteLine("Вектор ID={0} : {1}", ID, String.Join(" ", vect));

        Console.WriteLine("{0} : {1}", this.ToString(), String.Join(" ", vect));

    }
    // метод String.Join() сцепляет элементы указанного массива или элементы коллекции, помещая между ними заданный разделитель
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
            else if (vect[j] == 1) tmpVector[j] = 0;

        }

        return tmpVector;
    }

}