using System;
using Gtk;

/*
 * Svaki prozor je klasa koja mora naslijediti Gtk.Window klasu
 */

public partial class MainWindow : Window
{
	/*
	 * Konstruktor najprije poziva konstruktuor iz nasljeđene klase s 
	 * parametrom WindowType.Toplevel što znači da je to glavni prozor
	 * aplikacije
	 */
	public MainWindow() : base(WindowType.Toplevel)
	{

		// instanciranje labele za prikaz teksta
		var lab1 = new Label();
		lab1.LabelProp = "Hello World!";

		// instanciranje VBox spremnika u kojem će biti labela
		var vb1 = new VBox();
		vb1.PackStart(lab1, true, true, 0); // dodaj element 'lab1'

		this.Add(vb1); // dodaj element 'vb1' na prozor
		this.ShowAll(); // prikaži sve elemente koji su dodani na prozor

		// Podešavanje veličine prozora
		this.SetSizeRequest(400, 300);

		// Postavljanje handlera na event "DeleteEvent"
		this.DeleteEvent += this.OnDeleteEvent;

	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
