using System;
using System.Collections.Generic;

namespace TestGenerics
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			double a = GenerickaKlasa<double>.kreirajInstancu();

			GenerickaKlasa<double>.usporedi(1.0, 2.0);

			GenerickaKlasa<int>.usporedi(1, 2);

			List<double> lista = new List<double>() { 1.0, 2.0, 0.5, 1.5, 3.5 };

			//double najveci = GenerickaKlasa<double>.Maksimum(lista);
			//System.Console.WriteLine("Najveći je: {0}", najveci);
		}
	}
}
