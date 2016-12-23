using System;
using System.Collections.Generic;

namespace TestGenerics
{
	// primjer klase koja je generička sa ograničenjima na T
	public class GenerickaKlasa<T> where T : IComparable<T>, new()
	{
		// primjer metoda koja vraća instancu tipa T (još nepoznatog)
		public static T kreirajInstancu()
		{
			// sigurni smo da tip T (koji god bude) će imati prazan konstruktor zbog uvjeta where T : new()
			return new T();
		}

		// primjer metode koja prima parametre tipa T
		public static void usporedi(T a, T b)
		{
			// sigurni smo da tip T ima CompareTo metodu zbog uvjeta where T : IComparable<T>
			int usporedba = a.CompareTo(b);

			if (usporedba < 0)
			{
				Console.WriteLine("{0} je manji od {1}", a, b);
			}
			else if (usporedba > 0)
			{
				Console.WriteLine("{0} je veći od {1}", a, b);
			}
			else 
			{
				Console.WriteLine("{0} i {1} su isti", a, b);
			}
		}

		// metoda koja vraća najveću vrijednost
		public static T Maksimum(List<T> lista)
		{
			T najveci = default(T);

			foreach (var l in lista)
			{
				if (l.CompareTo(najveci) > 0)
				{
					najveci = l;
				}
			}

			return najveci;
		}
	}
}
