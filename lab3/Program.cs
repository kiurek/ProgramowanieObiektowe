using System;
using static lab1.Person;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.Of("Kuba");
            Console.WriteLine(person.FirstName);
            Money money1 = Money.Of(-1, Currency.PLN);
            
        }
    }
        class Person
        {

            private string _firstName;

            private Person(string firstName)
            {
                _firstName = firstName;
            }

            public static Person Of(string firstName)
            {
                if (firstName.Length >= 2)
                {
                    return new Person(firstName);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię jest zbyt krótkie");
                }
            }

            public string FirstName
            {
                get
                {
                    return _firstName;
                }
                set
                {
                    if (value.Length >= 2)
                    {
                        _firstName = value;
                    }
                }
            }

            public enum Currency
            {
                PLN = 1,
                USD = 2,
                EUR = 3
            }

            public class Money
            {
                private readonly decimal _value;

                private readonly Currency _currency;

                private Money(decimal value, Currency currency)
                {
                    _value = value;
                    _currency = currency;
                }

                public static Money? Of(decimal value, Currency currency)
                {
                    if (value < 0)
                    {
                        return value < 0 ? null : new Money(value, currency);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Nie można wykonać działania");
                    }
                }
            public static Money? OfWithException(decimal value, Currency currency)
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return new Money(value, currency);
                }

            }
            public static Money operator *(Money money, decimal value)
            {
                return Money.Of(money._value * value, money._currency);
            }
            // money * 5 --> *(money, 5)
            // 5 * money --> *(5, money)
            
            public static Money? ParseValue (string ValueStr, Currency currency)
            {
                decimal parsedValue;
                bool success = decimal.TryParse(ValueStr, out parsedValue);
                if (success)
                {
                    return Money.Of(parsedValue, currency);
                }
                else
                {
                    throw new ArgumentException("Invalid argument/s");
                }
            }
        }
        
    }
}
