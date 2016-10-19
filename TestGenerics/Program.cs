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
		}
	}
}
