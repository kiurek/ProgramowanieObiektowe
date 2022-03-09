using System;
using static lab1.Person;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var m1 = Money.OfWithException(10, Currency.USD);
            var m2 = Money.OfWithException(15, Currency.USD);
            Console.WriteLine(m1);
            Console.WriteLine(m1 > m2);
            Console.WriteLine(m1 == m2);
            Console.WriteLine(m1 != m2);
            var m3 = m1.Percent(50);
            Console.WriteLine(m3);
            var m4 = m1.ToCurrency(4, Currency.PLN);
            Console.WriteLine(m4);
        }
    }
        
         public enum Currency
         {
            PLN = 1,
            USD = 2,
            EUR = 3
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
        }

        public class Money : IEquatable<Money>
        {
            private readonly decimal _value;

            private readonly Currency _currency;

            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }

            public override string ToString()
            {
                return $"{_value} {_currency}";
            }

            public static Money? OfWithException(decimal value, Currency currency)
            {
                if (value < 0)
                {
                    throw new Exception("Error value jest mniejsze od zera");
                }
                    
                return new Money(value, currency);
            }

            public static Money ParseValue (string stringValue, Currency currency)
            {
                decimal value = decimal.Parse(stringValue);
                return new Money(value, currency);
            }
            
            public bool Equals(Money? other)
            {
                if (other == null) return false;
                if (_currency != other.Currency) return false;
                return (_value == other.Value);
            }

            public Currency Currency
            {
                get { return _currency;}
            }

            public decimal Value
            {
                get { return _value;}
            }

            public static Money operator *(Money money, decimal factor)
            {
                return new Money(money.Value * factor, money.Currency);
            }
                // money * 5 --> *(money, 5)
                // 5 * money --> *(5, money)

        public static Money operator +(Money moneyA, Money moneyB)
            {
                if (moneyA.Currency != moneyB.Currency) throw new Exception("Error: Currencies are not matching");
                return new Money(moneyA.Value + moneyB.Value, moneyA.Currency);
            }

            public static bool operator <(Money moneyA, Money moneyB)
            {
                if (moneyA.Currency != moneyB.Currency) throw new Exception("Error: Currencies are not matching");
                return (moneyA.Value < moneyB.Value);
            }

            public static bool operator >(Money moneyA, Money moneyB)
            {
                if (moneyA.Currency != moneyB.Currency) throw new Exception("Error: Currencies are not matching");
                return (moneyA.Value > moneyB.Value);
            }

            public static explicit operator float(Money money)
            {
                return (float)money.Value;
            } 
        }

        public static class MoneyExtension
        {
            public static Money Percent(this Money money, decimal percent)
            {
                return Money.OfWithException((money.Value * percent) / 100m, money.Currency);
            }
            public static Money ToCurrency(this Money money, decimal factor, Currency curr)
            {
                return Money.OfWithException(money.Value * factor, curr);
            }
        }

        public class Tank
        {
            public readonly int Capacity;
            private int _level;
            public Tank(int capacity)
            {
                Capacity = capacity;
            }
            public int Level
            {
                get { return _level; }
                set
                {
                    if (value < 0 || value > Capacity) throw new ArgumentOutOfRangeException();
                    _level = value;
                }
            }
            public bool Consume(int w)
            {
                if (w > _level)
                {
                    return false;
                }
                Level = _level - w;
                return true;
            }
            public void Refuel(int amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("Argument cant be non positive!");
                }
                if (_level + amount > Capacity)
                {
                    throw new ArgumentException("Argument is to large!");
                }
                _level += amount;
            }
            public bool Refuel(Tank sourceTank, int amount)
            {
                if (this.Level + amount > Capacity)
                {
                    return false;
                }
                if (sourceTank.Consume(amount))
                {
                    this.Refuel(amount);
                    return true;
                }

                return false;
            }

        }
    }