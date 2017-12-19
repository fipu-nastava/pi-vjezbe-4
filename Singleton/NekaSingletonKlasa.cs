using System;
namespace Singleton
{
	public class NekaSingletonKlasa
	{
		public String naziv;

		private static NekaSingletonKlasa jedinaInstanca;

		private NekaSingletonKlasa()
		{
		}

		public static NekaSingletonKlasa dajSingleton()
		{

			if (NekaSingletonKlasa.jedinaInstanca == null)
			{
				NekaSingletonKlasa.jedinaInstanca = new NekaSingletonKlasa();
				return NekaSingletonKlasa.jedinaInstanca;
			}
			else
			{
				return NekaSingletonKlasa.jedinaInstanca;
			}
		}
	}
}
