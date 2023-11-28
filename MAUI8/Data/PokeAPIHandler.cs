using MAUI8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAUI8.Data
{
	public class Result
	{
		public string name { get; set; }
		public string url { get; set; }
	}

	public class Root
	{
		public int count { get; set; }
		public string next { get; set; }
		public object previous { get; set; }
		public List<Result> results { get; set; }

	}

	public class PokeAPIHandler
	{
		public HttpClient client { get; private set; }
		private string url {  get; set; }
		public PokeAPIHandler()
		{
			client = new HttpClient();
			url = "https://pokeapi.co/api/v2/pokemon/";
		}
		public async Task<List<Pokemon>> GetNextPokemonsAsync()
		{
			HttpResponseMessage response = client.GetAsync(url).Result;
			Root root = new();
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				HttpContent content = response.Content;
				string result = await content.ReadAsStringAsync();
				root = JsonSerializer.Deserialize<Root>(result);
				url = root.next;
			}

			List<Pokemon> pokemons = new();
			foreach (Result r in root.results)
			{
				response = client.GetAsync(r.url).Result;
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					HttpContent content = response.Content;
					string result = await content.ReadAsStringAsync();
					pokemons.Add(JsonSerializer.Deserialize<Pokemon>(result));
				}
			}
			return pokemons;
		}
	}
}
