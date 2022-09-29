using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Currency
    {
        public double Value;
        public Currency(double _value)
        {
            Value = _value;
        }
    }

    class CurrenceUSD : Currency
    {
        public double USDtoRUB;
        public double USDtoEUR;

        public CurrenceUSD(double _value, double _rub, double _eur) : base(_value)
        {
            USDtoRUB = _rub;
            USDtoEUR = _eur;
        }

        public static implicit operator CurrenceUSD(CurrenceRUB _rub)
        {
            return new CurrenceUSD(_rub.Value * _rub.RUBtoUSD, 1 / _rub.RUBtoUSD, _rub.RUBtoEUR / _rub.RUBtoUSD);
        }

        public static explicit operator CurrenceRUB(CurrenceUSD _usd)
        {
            return new CurrenceRUB(_usd.Value * _usd.USDtoRUB, 1 / _usd.USDtoRUB, _usd.USDtoEUR / _usd.USDtoRUB);
        }

        public static implicit operator CurrenceUSD(CurrenceEUR _eur)
        {
            return new CurrenceUSD(_eur.Value * _eur.EURtoUSD, 1 / _eur.EURtoUSD, _eur.EURtoRUB / _eur.EURtoUSD);
        }

        public static explicit operator CurrenceEUR(CurrenceUSD _usd)
        {
            return new CurrenceEUR(_usd.Value * _usd.USDtoEUR, 1 / _usd.USDtoEUR, _usd.USDtoEUR / _usd.USDtoRUB);
        }
    }

    class CurrenceEUR : Currency
    {
        public double EURtoRUB;
        public double EURtoUSD;

        public CurrenceEUR(double _value, double _rub, double _usd) : base(_value)
        {
            EURtoRUB = _rub;
            EURtoUSD = _usd;
        }

        public static implicit operator CurrenceEUR(CurrenceRUB _rub)
        {
            return new CurrenceEUR(_rub.Value * _rub.RUBtoEUR, 1 / _rub.RUBtoEUR, _rub.RUBtoUSD / _rub.RUBtoEUR);
        }


        public static explicit operator CurrenceRUB(CurrenceEUR _eur)
        {
            return new CurrenceRUB(_eur.Value * _eur.EURtoRUB, 1 / _eur.EURtoRUB, _eur.EURtoUSD / _eur.EURtoRUB);
        }

        public static implicit operator CurrenceEUR(CurrenceUSD _usd)
        {
            return new CurrenceEUR(_usd.Value * _usd.USDtoEUR, _usd.USDtoRUB / _usd.USDtoEUR, 1 / _usd.USDtoEUR);
        }
    }

    class CurrenceRUB : Currency
    {
        public double RUBtoUSD;
        public double RUBtoEUR;

        public CurrenceRUB(double _value, double _usd, double _eur) : base(_value)
        {
            RUBtoUSD = _usd;
            RUBtoEUR = _eur;
        }

        public static implicit operator CurrenceRUB(CurrenceEUR _eur)
        {
            return new CurrenceRUB(_eur.Value * _eur.EURtoRUB, _eur.EURtoUSD / _eur.EURtoRUB, 1 / _eur.EURtoRUB);
        }
        public static implicit operator CurrenceRUB(CurrenceUSD _usd)
        {
            return new CurrenceRUB(_usd.Value * _usd.USDtoRUB, 1 / _usd.USDtoRUB, _usd.USDtoEUR / _usd.USDtoRUB);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string check = "";
            Console.WriteLine("Введите курс валют:");
            Console.WriteLine("USD->RUB");
            double USDtoRUB = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("EUR->RUB");
            double EURtoRUB = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("EUR->USD");
            double EURtoUSD = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Какую волюту вы хотите поменять?");
            string currency = Console.ReadLine();
            Console.WriteLine("Сколько вы хотите обменять?");
            double value = Convert.ToDouble(Console.ReadLine());
            CurrenceRUB R;
            CurrenceUSD U;
            CurrenceEUR E;

            if (currency == "RUB")
            {
                R = new CurrenceRUB(value, 1 / USDtoRUB, 1 / EURtoRUB);
                Console.WriteLine("RUB");
                Console.WriteLine(R.Value);
                Console.WriteLine(R.RUBtoUSD);
                Console.WriteLine(R.RUBtoEUR);

                U = (CurrenceUSD)R;
                Console.WriteLine("RUB->USD");
                Console.WriteLine(U.Value);

                E = R;
                Console.WriteLine("RUB->EUR");
            }

            if (currency == "USD")
            {
                U = new CurrenceUSD(value, USDtoRUB, 1 / EURtoUSD);
                Console.WriteLine("USD");
                Console.WriteLine(U.Value);
                Console.WriteLine(U.USDtoRUB);
                Console.WriteLine(U.USDtoEUR);

                R = U;
                Console.WriteLine("USD->RUB");
                Console.WriteLine(R.Value);

                E = U;
                Console.WriteLine("USD->EUR");
                Console.WriteLine(E.Value);
            }

            if (currency == "EUR")
            {
                E = new CurrenceEUR(value, EURtoRUB, EURtoUSD);
                Console.WriteLine("EUR");
                Console.WriteLine(E.Value);
                Console.WriteLine(E.EURtoUSD);
                Console.WriteLine(E.EURtoRUB);

                R = E;
                Console.WriteLine("EUR->RUB");
                Console.WriteLine(R.Value);

                U = (CurrenceUSD)E;
                Console.WriteLine("EUR->USD");
                Console.WriteLine(U.Value);
            }
        }
    }
}
