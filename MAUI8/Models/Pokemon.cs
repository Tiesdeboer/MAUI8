using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAUI8.Models
{
	public class Sprites
	{
		[JsonPropertyName("back_default")]
		public string BackDefault { get; set; }
		[JsonPropertyName("front_default")]
		public string FrontDefault { get; set; }
	}
	public class Pokemon
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("height")]
		public int Height { get; set; }
		[JsonPropertyName("id")]
		public int ID { get; set; }
		[JsonPropertyName("sprites")]
		public Sprites Sprites { get; set; }
	}
}
