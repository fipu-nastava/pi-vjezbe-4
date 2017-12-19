using System;

namespace Singleton
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var k1 = NekaSingletonKlasa.dajSingleton();

			k1.naziv = "OK";

			Console.WriteLine(k1.naziv);

			var k2 = NekaSingletonKlasa.dajSingleton();

			Console.WriteLine(k2.naziv);
		}
	}
}
