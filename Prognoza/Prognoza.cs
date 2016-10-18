using System;
namespace Test
{
	public class KisaEventArgs : EventArgs
	{
		public DateTime Vrijeme { get; set; }
		public KisaEventArgs(DateTime vrijemePocetka) : base()
		{
			this.Vrijeme = vrijemePocetka;
		}
	}

	public class Prognoza
	{
		public String Naziv { get; set;}

		public Prognoza(String naziv)
		{
			this.Naziv = naziv;
		}
	
		// definiranje delegata koji će obraživati događaj
		public delegate void PadaKisaEventHandler(Prognoza posiljatelj, KisaEventArgs informacije);

		// definiranje mogućeg događaja i delegata koji je zadužen za obradu događaja
		public event PadaKisaEventHandler PadaKisa;

		protected virtual void SignalizirajKisu()
		{
			// dodatne informacije sadrže vrijeme kad je kiša počela
			KisaEventArgs info = new KisaEventArgs(DateTime.Now);

			// pošalji signal da pada kiša s informacijom o posiljatelju i dodatnim informacijama
			PadaKisa(this, info);
		}

		public void ProvjeraDaLiPadaKisa()
		{
			Console.WriteLine("Signaliziram da pada kiša pomoću metode za signalizaciju");
			SignalizirajKisu();
		}
	}
}
