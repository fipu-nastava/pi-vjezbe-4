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
			return new T();
		}

		// primjer metode koja prima parametre tipa T
		public static void usporedi(T a, T b)
		{
			int usporedba = a.CompareTo(b);

			if (usporedba < 0)
			{
				Console.WriteLine("{0} je veći od {1}", a, b);
			}
			else if (usporedba > 0)
			{
				Console.WriteLine("{0} je veći od {1}", b, a);
			}
			else 
			{
				Console.WriteLine("{0} i {1} su isti", a, b);
			}
		}

		public static T maksimum(List<T> lista)
		{
			return default(T);
		}
	}
}
