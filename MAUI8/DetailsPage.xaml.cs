using MAUI8.Models;
using MAUI8.Models.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MAUI8
{
	public partial class DetailsPage : ContentPage
	{
		
		public DetailsPage(Pokemon pokemon)
		{
			InitializeComponent();
			label.Text = pokemon.Name;
		}

	}
}