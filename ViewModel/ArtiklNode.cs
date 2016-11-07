using System;
namespace Playground
{
	public class ArtiklNode : Gtk.TreeNode
	{
		[Gtk.TreeNodeValue(Column = 0)]
		public String naziv;

		[Gtk.TreeNodeValue(Column = 1)]
		public double cijena;

		public ArtiklNode(Narudzba.Artikl a)
		{
			this.naziv = a.Naziv;
			this.cijena = a.Cijena;
		}
	}
}
