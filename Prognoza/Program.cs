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

            hrt.Suncano += MetodaKojaUzimaNaocale;
			novatv.Suncano += MetodaKojaUzimaNaocale;

			hrt.ProvjeriVrijeme();
			novatv.ProvjeriVrijeme();

			Console.ReadKey();
		}

		public static void MetodaKojaUzimaKisobran(Prognoza nepoznatiPosiljatelj, KisaEventArgs informacije)
		{
			System.Console.WriteLine("Uzimam kišobran jer {0} prognoza {1} kaže da je kiša!", nepoznatiPosiljatelj.Naziv, informacije.Vrijeme);
		}

		public static void MetodaKojaUzimaNaocale(Prognoza posiljatelj, KisaEventArgs info)
		{
			System.Console.WriteLine("Uzimam naočale jer {0} prognoza {1} kaže da je sunce!", posiljatelj.Naziv, info.Vrijeme);
		}
	}
}
