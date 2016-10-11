using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		//Build();

		var lab1 = new Label();
		lab1.LabelProp = "Hello World!";

		var vb1 = new VBox();
		vb1.PackStart(lab1, true, true, 0); // dodaj element 'lab1'

		this.Add(vb1); // dodaj element 'vb1'
		this.ShowAll(); // prikaži sve elemente koji su dodani

		// Podešavanje prozora
		this.SetSizeRequest(800, 600);
		this.DeleteEvent += this.OnDeleteEvent;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
