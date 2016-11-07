using System;
using System.Collections.Generic;

namespace Loto
{
	public static class OdabirBrojeva<T>
	{
		public static T Odaberi(List<T> lista)
		{
			int max = lista.Count;

			Random r = new Random();

			int odabir = r.Next() % max;

			T retval = lista[odabir];

			lista.Remove(retval);

			return retval;
		}
	}
}
