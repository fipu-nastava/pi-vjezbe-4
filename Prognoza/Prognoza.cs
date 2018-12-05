using System;
namespace Test
{
	public class KisaEventArgs : System.EventArgs
	{
		public DateTime Vrijeme { get; set; }
		public KisaEventArgs(DateTime vrijemePocetka) : base()
		{
			this.Vrijeme = vrijemePocetka;
		}
	}

	public class Prognoza
	{
		private enum MoguceVrijeme { Kisa, Sunce };

		public String Naziv { get; set;}

		public Prognoza(String naziv)
		{
			this.Naziv = naziv;
		}
	
		// definiranje delegata koji će obraživati događaj
		public delegate void PadaKisaEventHandler(Prognoza posiljatelj, KisaEventArgs informacije);

		// definiranje mogućeg događaja i delegata koji je zadužen za obradu događaja
		public event PadaKisaEventHandler PadaKisa;

		// događaj prestanka padanja kiše
		public event PadaKisaEventHandler Suncano;

		protected void SignalizirajKisu()
		{
			// dodatne informacije sadrže vrijeme kad je kiša počela
			KisaEventArgs info = new KisaEventArgs(DateTime.Now);

			// pošalji signal da pada kiša s informacijom o pošiljatelju i dodatnim informacijama
			if (PadaKisa != null) // da li uopće netko sluša?
			{
				PadaKisa(this, info);
			}
		}

		protected void SignalizirajPrestanakKise()
		{
			// dodatne informacije sadrže vrijeme kad je kiša prestala padati
			KisaEventArgs info = new KisaEventArgs(DateTime.Now);

			// pošalji signal da pada kiša s informacijom o pošiljatelju i dodatnim informacijama
			if (Suncano != null) // da li uopće netko sluša?
			{
				Suncano(this, info);
			}
		}

		public void ProvjeriVrijeme()
		{
			// kod koji nasumično postavlja trenutno vrijeme na jednu od vrijednosti: kiša, sunce, oblačno
			Random r = new Random();
			Array vrijednosti = Enum.GetValues(typeof(MoguceVrijeme));
			MoguceVrijeme trenutnoVrijeme = (MoguceVrijeme) vrijednosti.GetValue(r.Next(vrijednosti.Length));

			if (trenutnoVrijeme == MoguceVrijeme.Kisa)
			{
				Console.WriteLine("{0} prognoza šalje signal da pada kiša", this.Naziv);
				SignalizirajKisu();
			}
			else if (trenutnoVrijeme == MoguceVrijeme.Sunce)
			{
				Console.WriteLine("{0} prognoza šalje signal da je sunce", this.Naziv);
				SignalizirajPrestanakKise();
			}
		}
	}
}
