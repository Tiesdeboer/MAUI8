using MAUI8.Data;

namespace MAUI8
{
	public partial class App : Application
	{
		private PokeAPIHandler PokeAPIHandler { get; set; }
		public App()
		{
			PokeAPIHandler = new PokeAPIHandler();
			InitializeComponent();

			MainPage = new AppShell();
		}
	}
}