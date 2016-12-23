using System;
using System.Collections.Generic;

namespace Loto
{
	public class OdabirBrojeva<T> where T : struct
	{
		private static Random rand = new Random();

		public static T Odaberi(List<T> lista)
		{
			int choice = rand.Next(0, lista.Count);

			T retval = lista[choice];

			lista.RemoveAt(choice);

			return retval;
		}
	}
}