using System;

namespace StatickeKlase
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			HipotenuzaNormal h = new HipotenuzaNormal(3, 4);
			Console.WriteLine("Rezultat je {0}", h.Izracunaj());

			Console.WriteLine("Rezultat je {0}", HipotenuzaStatic.Izracunaj(3, 4));

			Automobil a = new Automobil("Tesla Model S");

			//int brojKotaca = a.brojKotaca;

			int brojKotaca = Automobil.brojKotaca;
		}
	}
}
