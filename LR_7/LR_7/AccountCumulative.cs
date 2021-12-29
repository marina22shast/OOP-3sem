using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Накопительный счет - по нему идет % - по сути депозитный */
public class AccountCumulative : Account
{

    public int DepPercent; // депозитный процент

    public AccountCumulative() : base() // конструктор
    {
        DepPercent = 0; // по умолчанию накопление выключено (0%)
    }
    public AccountCumulative(string AccNumber, double AccBallance, int PercentVal) : base(AccNumber, AccBallance) // конструктор
    {
        DepPercent = PercentVal;
    }

    public override void GetInfo()
    {
        /* вывод информации о накопительном счете на консоль */
        base.GetInfo(); // вызываем метод базового класса
        Console.WriteLine("       тип счета - накопительный, депозитная ставка : {0}%", DepPercent);

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Накопительный банковский cчет : номер " + AccountNumber.ToString() + " остаток на счете " + AccountBalance.ToString() + " депозитная ставка : " + DepPercent.ToString() + "%";

        return objinfo;

    }
}