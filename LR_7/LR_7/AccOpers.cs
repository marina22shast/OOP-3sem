using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Операции со счетом */
public static class AccOpers
{

    /* В сравнении с нестатическим классом, статический класс имеет следующие свойства(отличия) :
       - нельзя создавать объекты статического класса;
       - статический класс должен содержать только статические члены.
    */

    public static void AccLock(Account Acc)
    {
        /* операция блокировки счета */
        Acc.IsLocked = true;
    }

    public static void AccUnLock(Account Acc)
    {
        /* операция разблокировки счета */
        Acc.IsLocked = false;
    }

    public static void AccDelete(Account Acc)
    {
        /* операция удаления счета */

        Acc.AccountNumber = null;
        Acc.AccountBalance = 0;

    }

    public static double GetLookBallance(Account Acc, double сoeff)
    {
        /* операция получения прогнозного остатка по счету 
         
           сoeff - прогнозный коэффициент
         */

        // проверка прогнозного коэффициента на валидность

        if (сoeff == 0) throw new AccountOperException("попытка деления на ноль.");

        return (Acc.AccountBalance / сoeff);

    }


}