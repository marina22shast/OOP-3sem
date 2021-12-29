using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Общий счет - доступен группе лиц (юридических и физических) */

public class AccountTotal : Account
{

    public int OwnersQtt; // количество владельцев счета

    public AccountTotal() : base() // конструктор
    {
        OwnersQtt = 1; // по умолчанию при открытии у счета один владелец
    }
    public AccountTotal(string AccNumber, double AccBallance, int Owners) : base(AccNumber, AccBallance) // конструктор
    {
        OwnersQtt = Owners;
    }

    public override void GetInfo()
    {
        /* вывод информации об общем счете на консоль */
        base.GetInfo(); // вызываем метод базового класса
        Console.WriteLine("       тип счета - общий, количество владельцев счета : {0}", OwnersQtt);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Общий банковский cчет : номер " + AccountNumber.ToString() + " остаток на счете " + AccountBalance.ToString() + " количество владельцев счета : " + OwnersQtt.ToString();

        return objinfo;

    }

}