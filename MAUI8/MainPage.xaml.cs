using MAUI8.Models;
using MAUI8.Models.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MAUI8
{
	public partial class MainPage : ContentPage
	{
		public MainPageViewModel vm;
		public MainPage()
		{
			InitializeComponent();
			vm = new MainPageViewModel(Navigation);
			BindingContext = vm;
		}

		private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
		{
			if(e.LastVisibleItemIndex == vm.Pokemons.Count - 1)
			{
				vm.GetPokemons();
			}
		}

	}
}