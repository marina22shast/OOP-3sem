using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Адрес */
public sealed partial class Address
{
    /* объявили класс как sealed - от данного класса наследовтаь запрещается */

    public string City;           // город
    public string Street;         // улица
    public int HouseNumber;       // номер дома
    public int AppartmentNumber;  // номер квартиры

    public Address() // конструктор
    {
        City = "";
        Street = "";
        HouseNumber = 0;
        AppartmentNumber = 0;
    }

    public Address(string TheCity, string TheStreet, int TheHouseNumber, int TheAppartmentNumber) // конструктор
    {
        City = TheCity;
        Street = TheStreet;
        HouseNumber = TheHouseNumber;
        AppartmentNumber = TheAppartmentNumber;
    }

}