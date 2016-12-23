using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow : Gtk.Window
{
	List<Gtk.Entry> unosi;

	public void ForAll<T>(Callback c, Gtk.Container parent = null) where T : Gtk.Object {
		parent = (parent != null) ? parent : this;

		if (parent is Gtk.Container)
		{
			var containerParent = (Gtk.Container)parent;

			containerParent.Forall((widget) =>
			{
				if (widget is T)
				{
					c.Invoke(widget);
				}
				else if (widget is Gtk.Container)
				{
					ForAll<T>(c, (Gtk.Container) widget);
				}
			});
		}
	}

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		// postavi font svim labelama
		this.ForAll<Gtk.Label>((widget) => widget.ModifyFont(Pango.FontDescription.FromString("Sans 24")));

		// stvori listu unosa brojeva
		unosi = new List<Gtk.Entry>() { iBroj1, iBroj2, iBroj3, iBroj4, iBroj5, iBroj6 };

		// stiliziraj font i poravnanje teksta
		foreach (var u in unosi)
		{
			u.ModifyFont(Pango.FontDescription.FromString("Sans 40"));
			u.Alignment = 0.5F;
		}

		lBrojevi.ModifyFont(Pango.FontDescription.FromString("Sans 40"));
		lStatus.ModifyFont(Pango.FontDescription.FromString("Sans 40"));
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnPokreni(object sender, EventArgs e)
	{
		bool stats = ProvjeriBrojeve();
		if (!stats)
		{
			lStatus.LabelProp = "Niste unijeli ispravno brojeve";
			return;
		}

		var brojevi = DohvatiBrojeve();

		var listaBrojeva = new List<int>();

		for (int i = 1; i <= 45; i++)
		{
			listaBrojeva.Add(i);
		}

		var rezultat = new List<int>();

		for (int i = 0; i < 6; i++)
		{
			int izvuceniBroj = Loto.OdabirBrojeva<int>.Odaberi(listaBrojeva);
			rezultat.Add(izvuceniBroj);
		}

		lBrojevi.Text = String.Join(", ", rezultat);

		// usporedba
		int pogodjenoBrojeva = 0;
		foreach (var broj in rezultat)
		{
			if (brojevi.Contains(broj))
			{
				pogodjenoBrojeva++;
			}
		}

		switch (pogodjenoBrojeva)
		{
			case 6:
				lStatus.LabelProp = "Pogodak! Častite svih kavom!";
				break;
			case 1:
				lStatus.LabelProp = String.Format("Nije loše! Pogodili ste {0} broj!", pogodjenoBrojeva);
				break;
			case 2:
			case 3:
			case 4:
				lStatus.LabelProp = String.Format("Nije loše! Pogodili ste {0} broja!", pogodjenoBrojeva);
				break;
			case 5:
				lStatus.LabelProp = String.Format("Nije loše! Pogodili ste {0} brojeva!", pogodjenoBrojeva);
				break;
			default:
				lStatus.LabelProp = "Žao mi je! Nite pogodili niti jedan broj!";
				break;
		}
	}

	List<int> DohvatiBrojeve()
	{
		var retval = new List<int>();
		foreach (var u in unosi)
		{
			retval.Add(Int32.Parse(u.Text));	
		}

		return retval;
	}

	bool ProvjeriBrojeve()
	{
		foreach (var u in unosi)
		{
			try
			{
				int broj = Int32.Parse(u.Text);
				if (broj < 1 || broj > 45)
				{
					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}

		return true;
	}
}
