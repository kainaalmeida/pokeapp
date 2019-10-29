using Flurl;
using Flurl.Http;
using PokeApp.Models;
using PokeApp.Services;
using PokeApp.Services.Contrato;
using PokeApp.Utils;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(PokeApi))]
namespace PokeApp.Services
{
    public class PokeApi : IPokeApi
    {

        public async Task<PokemonList> ObterListaPokemons(int offset = 20, int limit = 20)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) return null;

            try
            {
                var url = $"{EndPoints.BaseUrl}?offset={offset}&limit={limit}";

                var response = await url
                    .AllowAnyHttpStatus()
                    .GetAsync()
                    .ReceiveJson<PokemonList>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var msg = await ex.GetResponseStringAsync();
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Pokemon> ObterPokemon(string endpoint)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet) return null;

            try
            {
                var response = await endpoint
                    .AllowAnyHttpStatus()
                    .GetAsync()
                    .ReceiveJson<Pokemon>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                var msg = await ex.GetResponseStringAsync();
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
