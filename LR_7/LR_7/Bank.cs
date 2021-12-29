using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Банк - список персон, являющихся клиентами - обладателями банковских карт и счетов */

public class Bank
{

    // будем хранить реестр персоналий банка в виде списка
    public List<ThePerson> Persons; // список персоналий

    // поддержка логирования событий
    public ConsoleLogger ConsLogger; // консольный логер
    public FileLogger FlLogger; // файловый логер

    public Bank() // конструктор
    {

        Persons = new List<ThePerson>();

        ConsLogger = new ConsoleLogger();
        FlLogger = new FileLogger();

    }

    public ThePerson PersonRegistry // определим Свойство
    {
        get
        {
            // возвращает первый элемент списка
            return Persons.ElementAt(0);    // возвращаем значение свойства
        }
        set
        {
            // добавляет элементв список
            Persons.Add(value);   // устанавливаем новое значение свойства
        }
    }

    public void Add(ThePerson NewPerson)
    {

        /* метод добавляет элемент в список персон */

        Persons.Add(NewPerson);

    }

    public void Remove(string RemFio)
    {

        /* метод удаляет элемент из списка персон */

        ThePerson PDel = null; // персона для удаления

        foreach (ThePerson P in Persons)
        {

            if (P.Fio == RemFio)
            {
                PDel = P; // обнаружили персону с данным ФИО
                break;
            }

        }

        Persons.Remove(PDel);
    }

    public void PrintPersons()
    {
        /* метод выводит на консоль список персон */

        Console.WriteLine("\nБАНКОВСКИЙ РЕЕСТР ПЕРСОНАЛИЙ :");
        foreach (ThePerson P in Persons) P.GetInfo();

    }

}
