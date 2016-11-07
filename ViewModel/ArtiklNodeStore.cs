using System;
using System.Collections.Generic;
using Narudzba;

namespace Playground
{
	public class ArtiklNodeStore : Gtk.NodeStore
	{
		public ArtiklNodeStore() : base(typeof(ArtiklNode))
		{
		}

		public void Add(Artikl a)
		{
			this.AddNode(new ArtiklNode(a));	
		}

		public void Dodaj(List<Artikl> artikli)
		{
			foreach (var a in artikli)
			{
				this.Add(a);
			}
		}
	}
}
