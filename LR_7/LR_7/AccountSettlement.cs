using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Расчетный счет - это счет в национальной валюте «до востребования» клиентов-юридических лиц */

public class AccountSettlement : Account
{

    public string Company; // название компании - владельца счета

    public AccountSettlement() : base() // конструктор
    {
        Company = "";
    }
    public AccountSettlement(string AccNumber, double AccBallance, string FirmName) : base(AccNumber, AccBallance) // конструктор
    {
        Company = FirmName;
    }

    public override void GetInfo()
    {
        /* вывод информации о расчетном счете на консоль */
        base.GetInfo(); // вызываем метод базового класса
        Console.WriteLine("       тип счета - расчетный, владелец счета : {0}", Company);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Расчетный банковский cчет : номер " + AccountNumber.ToString() + " остаток на счете " + AccountBalance.ToString() + " владелец счета : " + Company.ToString();

        return objinfo;

    }
}