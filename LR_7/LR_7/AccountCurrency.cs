using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Валютный счет - открыт в иностранной валюте*/

public class AccountCurrency : Account
{

    public string CurrenceCode; // код валюты счета

    public AccountCurrency() : base() // конструктор
    {
        CurrenceCode = "USD"; // по умолчанию доллары США
    }
    public AccountCurrency(string AccNumber, double AccBallance, string CurrCode) : base(AccNumber, AccBallance) // конструктор
    {
        //
        Debug.Assert(CurrCode != "BYN", "\nВалютный счет не может открываться в национальной валюте");
        //
        CurrenceCode = CurrCode;
    }

    public override void GetInfo()
    {
        /* вывод информации о валютном счете на консоль */
        base.GetInfo(); // вызываем метод базового класса
        Console.WriteLine("       тип счета - валютный, валюта счета : {0}", CurrenceCode);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Валютный банковский cчет : номер " + AccountNumber.ToString() + " остаток на счете " + AccountBalance.ToString() + " валюта счета : " + CurrenceCode.ToString();

        return objinfo;

    }
}