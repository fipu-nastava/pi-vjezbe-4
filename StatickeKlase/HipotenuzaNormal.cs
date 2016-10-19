using System;
namespace StatickeKlase
{
	public class HipotenuzaNormal
	{
		double a;
		double b;

		public HipotenuzaNormal(double a, double b)
		{
			this.a = a;
			this.b = b;
		}

		public double Izracunaj()
		{
			return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
		}
	}
}