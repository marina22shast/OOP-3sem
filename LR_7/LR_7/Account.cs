using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Банковский счет */
public class Account
{

    public struct RegistrationInfo // информации о регистрации счета
    {
        public String Organization;    // организация принадлежности счета
        public String RegDate;         // дата регистрации счета в системе
    };

    public enum BankingCategory   // банковская категория объекта
    {
        Low = 1,
        Middle,    // 2
        High = 9,
        SuperHigh  // 10
    }

    public string AccountNumber;  // номер счета
    public double AccountBalance; // остаток на счете

    public bool IsLocked;          // флаг блокировки счета (true/false)

    public RegistrationInfo RegInfo; // данные о регистрации персоны
    public BankingCategory Category;

    public Account() // конструктор
    {
        AccountNumber = "";
        AccountBalance = 0;
        IsLocked = false;

        RegInfo.Organization = "Банк TrustCapital";
        RegInfo.RegDate = DateTime.Today.ToString(); // присваиваем текущую дату
        Category = BankingCategory.Middle; // присваиваем категорию

    }
    public Account(string AccNumber, double AccBallance) // конструктор
    {
        // проверка основных параметров счета на валидность

        foreach (char c in AccNumber)
        {
            if (!Char.IsDigit(c))
            {
                throw new AccountException("Номер счета может содержать только цифры.", AccNumber);
            }
        }

        if (AccBallance < 0)
        {

            throw new AccountException("Отказ в открытии счета с отрицательным балансом.", AccBallance.ToString());

        }

        // 

        AccountNumber = AccNumber;
        AccountBalance = AccBallance;
        IsLocked = false;

        RegInfo.Organization = "Банк TrustCapital";
        RegInfo.RegDate = DateTime.Today.ToString(); // присваиваем текущую дату
        Category = BankingCategory.Middle; // присваиваем категорию
    }

    public virtual void GetInfo()
    {
        /* вывод информации о счете на консоль */

        Console.WriteLine("Счет : номер {0} остаток на счете {1} \n       дата регистрации в системе : {2} категория : {3}", AccountNumber, AccountBalance, RegInfo.RegDate, Category);

    }

    // переопределим в данном классе все методы, унаследованные от Object

    public bool Equals(Account Account2)
    {
        /* производит сравнение двух счетов - данного с переданным в качестве параметра,
         
           возвращает результат сравнения (true/false)
         
         */

        bool result = false;

        if (AccountNumber == Account2.AccountNumber) result = true;

        else result = false;

        return result;
    }

    new public int GetHashCode()
    {

        /* возвращает хеш-код счета,
      
           в качестве хеш-кода счета берем номер счета, поскольку он уникален в банковской системе
         */

        return int.Parse(AccountNumber);

    }

    new public string GetType()
    {

        /* возвращает именование объекта */

        return "Банковский счет";

    }

    new public string ToString()
    {

        /* выводит информацию о типе объекта и его текущих значениях */

        string objinfo = "Банковский cчет : номер " + AccountNumber.ToString() + " остаток на счете " + AccountBalance.ToString();

        return objinfo;

    }
}