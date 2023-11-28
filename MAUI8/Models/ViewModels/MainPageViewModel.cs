using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI8.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI8.Models.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{

		public INavigation Navigation { get; set; }

		private PokeAPIHandler handler;

		[ObservableProperty]
		private ObservableCollection<Pokemon> pokemons = new();
		[ObservableProperty]
		private Pokemon selectedPokemon;
		public MainPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			handler = new();
			GetPokemons();
		}
		public async void GetPokemons()
		{
			List<Pokemon> list = await handler.GetNextPokemonsAsync();
			list.ForEach(Pokemons.Add);
		}
		[RelayCommand]
		public async Task Test()
		{
			await Navigation.PushAsync(new DetailsPage(SelectedPokemon));
			SelectedPokemon = null;
		}
	}
}
