using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow : Gtk.Window
{
	struct Entry
	{
		public double number;
		public string operation;
	}

	List<Entry> stack = new List<Entry>();
	Boolean newNumber = false;
	string currentOperation = null;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		entry1.ModifyFont(Pango.FontDescription.FromString("Sans 40"));

		ForAll<Gtk.Label>((widget) => widget.ModifyFont(Pango.FontDescription.FromString("Sans 40")));
		ForAll<Gtk.Button>((widget) => (widget as Button).Clicked += HandleClick);
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	void HandleClick(object sender, EventArgs e)
	{
		Button trenutni = sender as Button;

		if (trenutni != null)
		{
			String label = (trenutni.Children[0] as Label).Text;
			HandleKey(label);
		}
	}

	protected void KeyPress(object o, KeyReleaseEventArgs args)
	{
		uint keycode = args.Event.KeyValue;

		HandleKey("" + (char) keycode);
	}

	void HandleKey(string label)
	{
		var operations = new HashSet<string>() { "+", "-", "/", "*" };

		double trenutnaVrijednost;
		double.TryParse(entry1.Text, out trenutnaVrijednost);

		int brojka;
		int.TryParse(label, out brojka);

		if (newNumber && (brojka != 0 || label == "0"))
		{
			newNumber = false;
			entry1.Text = "";
		}

		if (brojka != 0)
		{
			if (entry1.Text == "0")
			{
				entry1.Text = "";
			}

			entry1.Text += label;

		}
		else if (label == "0" && entry1.Text != "0")
		{
			entry1.Text += label;
		}
		else if (operations.Contains(label))
		{
			stack.Add(new Entry() { number = trenutnaVrijednost, operation = currentOperation });
			currentOperation = label;
			newNumber = true;
		}
		else if (label == "C")
		{
			if (Math.Abs(trenutnaVrijednost - 0.0) < double.Epsilon)
			{
				stack.Clear();
			}
			entry1.Text = "0";
		}
		else if (label == ".")
		{
			if (!entry1.Text.Contains("."))
			{
				entry1.Text += ".";
			}
		}
		else if (label == "=")
		{
			stack.Add(new Entry() { number = trenutnaVrijednost, operation = currentOperation });

			double result = DoMath();

			entry1.Text = result.ToString("0.#####");
			stack.Clear();
			currentOperation = null;
		}
	}

	double DoMath()
	{
		double result = 0;
		foreach (Entry e in stack)
		{
			var oper = e.operation;
			var a = e.number;

			if (oper == "*")
			{
				result *= a;
			}
			else if (oper == "/")
			{
				result /= a;
			}
			else if (oper == "+")
			{
				result += a;
			}
			else if (oper == "-")
			{
				result -= a;
			}
			else if (oper == null)
			{
				result = a;
			}
		}

		return result;
	}

	// Pronađi sve elemente unutar prozora tipa "T" i provedi metodu "c" nad njima
	public void ForAll<T>(Callback c, Gtk.Container parent = null) where T : Gtk.Object
	{
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
					ForAll<T>(c, (Gtk.Container)widget);
				}
			});
		}
	}

	protected void Stisnutoje7(object sender, EventArgs e)
	{
		//entry1.t
	}
}
