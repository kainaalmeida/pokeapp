using System.Collections.Generic;

namespace PokeApp.Models
{
    public class PokemonType
        {
            public int count { get; set; }
            public object next { get; set; }
            public object previous { get; set; }
            public List<Results> results { get; set; }
        }

        public class Results
        {
            public string name { get; set; }
            public string url { get; set; }
        }
}
