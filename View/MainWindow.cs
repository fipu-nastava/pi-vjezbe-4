using System;
using Gtk;
using Narudzba;
using System.Collections.Generic;

namespace Playground
{
	public partial class MainWindow : Gtk.Window
	{
		public List<Artikl> artikli = new List<Artikl>();

		ArtiklNodeStore artikliViewModel;

		public MainWindow() : base(Gtk.WindowType.Toplevel)
		{
			Build();

			artikli.Add(new Artikl("Mlijeko 2.5%", 4.49));
			artikli.Add(new Artikl("Kruh 500g", 5.49));
			artikli.Add(new Artikl("Čipi čips 200g", 15.23));
			artikli.Add(new Artikl("Mlijeko 3.2%", 5.23));

			artikliViewModel = new ArtiklNodeStore();
			artikliViewModel.Dodaj(artikli);

			popisArtikala.NodeStore = artikliViewModel;
			popisArtikala.AppendColumn("Naziv", new Gtk.CellRendererText(), "text", 0);
			popisArtikala.AppendColumn("Cijena", new Gtk.CellRendererText(), "text", 1);

			popisArtikala.NodeSelection.Changed += this.RowSelected;
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}

		protected void RowSelected(object o, EventArgs args)
		{
			var selectedArtikl = (ArtiklNode) popisArtikala.NodeSelection.SelectedNode;

			labelRedak.LabelProp = selectedArtikl.naziv;

			//artikliViewModel.Add(new Artikl("Mlijeko 2.5%", 4.49));
		}
	}
}