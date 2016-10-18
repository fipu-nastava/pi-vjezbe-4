using System;
using Gtk;

namespace HelloWorldUI
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// Inicijalizacija GTK-a
			Application.Init();

			// Instanciranje glavnog prozora
			MainWindow win = new MainWindow();

			// Pozivanje metode za prikaz glavnog prozora
			win.Show();

			// Pokretanje Main-loopa
			Application.Run();

			Console.WriteLine("Ja se izvršavam tek na izlasku iz aplikacije" +
							  " zbog beskonačne petlje");
		}
	}
}
