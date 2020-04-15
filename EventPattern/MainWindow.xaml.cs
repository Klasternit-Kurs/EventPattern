using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventPattern
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		EventP p = new EventP();
		public MainWindow()
		{
			InitializeComponent();
			p.PrimerEventa += MetodaZaDelegat;
		}

		private void Klik(object sender, RoutedEventArgs e)
		{
		}

		public void MetodaZaDelegat(object x, PrimerEventaArgs a)
		{ 
		}
	}

	public class PrimerEventaArgs //Argumente stavljamo u zasebnu klasu da bi se zastitili pri izmenama
	{
		public decimal Cena;
		public string Naziv;
		public int Marza;

		public PrimerEventaArgs(decimal c, string n, int m)
		{
			Cena = c;
			Naziv = n;
			Marza = m;
		}
	}
	public class EventP
	{
		public delegate void PrimerEventaHandler(object KoSalje, PrimerEventaArgs a); //postfix kod delegata Handler
		                                                          //object kao prvi parametar, uvek saljemo referencu ka sebi
																  //da bi svi znali ko pokrece event
		public event PrimerEventaHandler PrimerEventa;

		public void OnPrimerEventa()
		{
			PrimerEventa?.Invoke(this, new PrimerEventaArgs(234, "asd", 14));
		}
	}
}
