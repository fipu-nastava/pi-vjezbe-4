using System;

namespace Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var hrt = new Prognoza("HRT");
			var novatv = new Prognoza("NovaTV");

			// pretplata na događaj padanja kiše s oba objekta prognoze
			hrt.PadaKisa += MetodaKojaUzimaKisobran;
			novatv.PadaKisa += MetodaKojaUzimaKisobran;

			hrt.ProvjeriVrijeme();
			novatv.ProvjeriVrijeme();

			Console.ReadKey();
		}

		public static void MetodaKojaUzimaKisobran(Prognoza nepoznatiPosiljatelj, KisaEventArgs informacije)
		{
			System.Console.WriteLine("Uzimam kišobran jer {0} prognoza {1} kaže da moram!", nepoznatiPosiljatelj.Naziv, informacije.Vrijeme);
		}
	}
}
