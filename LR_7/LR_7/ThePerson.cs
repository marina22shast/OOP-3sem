using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Определим Интерфейс */

public interface IFio
{
    string SayFio();

}

/* Персона */
public abstract class ThePerson
{

    /* объявим данный класс абстрактным - мы не будем создавать объекты данного класса */

    public struct RegistrationInfo // информации о регистрации персоны
    {
        public String Organization;    // организация принадлежности персоны
        public String RegDate;         // дата регистрации персоны в системе
    };

    public enum BankingCategory   // банковская категория объекта
    {
        Low = 1,
        Middle,    // 2
        High = 9,
        SuperHigh  // 10
    }

    public string Fio;      // ФИО персоны
    public int Age;         // возраст
    public char Gender;     // пол ('m' - "male" / 'f' - "female" / '-' - uncknown)
    public RegistrationInfo RegInfo; // данные о регистрации персоны
    public BankingCategory Category;

    public ThePerson() // конструктор
    {
        Fio = "";
        Age = 0;
        Gender = '-';

        RegInfo.Organization = "Банк TrustCapital";
        RegInfo.RegDate = DateTime.Today.ToString(); // присваиваем текущую дату
        Category = BankingCategory.Middle; // присваиваем категорию
    }

    public ThePerson(string theFio, int theAge, char theGender) // конструктор
    {

        Fio = theFio;
        Age = theAge;
        Gender = theGender;

        RegInfo.Organization = "Банк TrustCapital";
        RegInfo.RegDate = DateTime.Today.ToString(); // присваиваем текущую дату
        Category = BankingCategory.Middle; // присваиваем категорию
    }

    // объявим абстрактный метод - производный класс (TheClient) обязан буде определить его
    public abstract string SayFio(); // одноименный метод объявлен в интерфейсе IFio

    public virtual void GetInfo()
    {
        /* вывод информации о персоне на консоль */

        Console.WriteLine("\nФИО : {0} Возраст : {1} Пол {2} Дата регистрации в системе : {3} Категория : {4}", Fio, Age, Gender == 'm' ? "мужской" : (Gender == 'f' ? "женский" : "нет данных"), RegInfo.RegDate, Category);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Персона : ФИО " + Fio + " Возраст : " + Age.ToString() + " Пол : " + (Gender == 'm' ? "мужской" : (Gender == 'f' ? "женский" : "нет данных"));

        return objinfo;

    }

    public bool Equals(ThePerson OtherPerson)
    {
        /* переопределим метод проверки равенства Equals() - персоны равны, если равны их ФИО */

        if (OtherPerson == null) return false;

        return (this.Fio.Equals(OtherPerson.Fio));

    }

}