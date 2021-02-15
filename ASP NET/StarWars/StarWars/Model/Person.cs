using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StarWars.Model
{
    public class Person
    {
		/*
        {
			"name": "Luke Skywalker",
			"height": "172",
			"mass": "77",
			"hair_color": "blond",
			"skin_color": "fair",
			"eye_color": "blue",
			"birth_year": "19BBY",
			"gender": "male",
			"homeworld": "https://swapi.dev/api/planets/1/",
			"films": [
				"https://swapi.dev/api/films/2/",
				"https://swapi.dev/api/films/6/",
				"https://swapi.dev/api/films/3/",
				"https://swapi.dev/api/films/1/",
				"https://swapi.dev/api/films/7/"
			],
			"species": [
				"https://swapi.dev/api/species/1/"
			],
			"vehicles": [
				"https://swapi.dev/api/vehicles/14/",
				"https://swapi.dev/api/vehicles/30/"
			],
			"starships": [
				"https://swapi.dev/api/starships/12/",
				"https://swapi.dev/api/starships/22/"
			],
			"created": "2014-12-09T13:50:51.644000Z",
			"edited": "2014-12-20T21:17:56.891000Z",
			"url": "https://swapi.dev/api/people/1/"
		}
		*/

		[JsonPropertyName("name")]
        public string Name { get; set; }

		[JsonPropertyName("height")]
		public string Height { get; set; }

		[JsonPropertyName("mass")]
		public string Mass { get; set; }

		[JsonPropertyName("heir_color")]
		public string HairColor { get; set; }

		[JsonPropertyName("skin_color")]
		public string SkinColor { get; set; }

		[JsonPropertyName("eye_color")]
		public string EyeColor { get; set; }

		[JsonPropertyName("birth_year")] 
		public string BirthYear { get; set; }

		[JsonPropertyName("gender")]
		public string Gender { get; set; }

		[JsonPropertyName("homeworld")]
		public string Homeworld { get; set; }

		[JsonPropertyName("films")]
		public List<string> Films { get; set; }

		[JsonPropertyName("spacies")]
		public List<string> Species { get; set; }

		[JsonPropertyName("vehiles")]
		public List<string> Vehicles { get; set; }

		[JsonPropertyName("starshis")]
		public List<string> Starships { get; set; }

		[JsonPropertyName("created")]
		public DateTime Created { get; set; }

		[JsonPropertyName("edited")]
		public DateTime Edited { get; set; }

		[JsonPropertyName("url")]
		public string Url { get; set; }

        public override string ToString()
        {
			return $"Name: {Name}\nHeight: {Height}\nGender: {Gender}";

		}

    }
}
