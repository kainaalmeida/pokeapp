using PokeApp.Models;
using System.Threading.Tasks;

namespace PokeApp.Services.Contrato
{
    public interface IPokeApi
    {
        Task<PokemonList> ObterListaPokemons(int offset = 20, int limit = 20);

        Task<Pokemon> ObterPokemon(string endpoint);
    }
}
