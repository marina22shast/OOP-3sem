using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AccountException : ArgumentException
{
    /* поддержка обработки исключений, возникающих при регистрации счетов клиентов */

    public string bad_value;
    public AccountException(string message, string val)
        : base(message)
    {
        bad_value = val;
    }
}

class AccountOperException : DivideByZeroException
{
    /* поддержка обработки исключений, возникающих при операциях со счетами клиентов */
    public AccountOperException(string message)
        : base(message)
    {
    }
}

class PayCardException : Exception
{
    /* поддержка обработки исключений, возникающих при регистрации платежных карт */

    public string bad_value;
    public PayCardException(string message, string val)
        : base(message)
    {
        bad_value = val;
    }
}