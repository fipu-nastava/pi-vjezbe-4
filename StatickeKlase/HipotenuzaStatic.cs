using System;
namespace StatickeKlase
{
	public static class HipotenuzaStatic
	{
		public static double Izracunaj(double a, double b)
		{
			return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
		}
	}
}
