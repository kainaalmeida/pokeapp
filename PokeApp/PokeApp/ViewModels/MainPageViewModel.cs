using LiteDB;
using PokeApp.Models;
using PokeApp.Services.Contrato;
using PokeApp.Utils;
using PokeApp.Views;
using PokeApp.Views.Popups;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace PokeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPokeApi _pokeApi;
        private readonly IPageDialogService _pageDialogService;
        private readonly LiteDatabase _db;

        private PokemonList pokemonList;
        public PokemonList PokemonList
        {
            get { return pokemonList; }
            set { SetProperty(ref pokemonList, value); }
        }


        public InfiniteScrollCollection<Pokemon> Pokemons { get; }

        LiteCollection<PokemonList> PokemonsPage;

        private int offset = 0;
        public int OffSet
        {
            get { return offset; }
            set { SetProperty(ref offset, value); }
        }

        public DelegateCommand<Pokemon> NavegarCommand { get; set; }
        public DelegateCommand<Pokemon> GaleriaCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPokeApi pokeApi, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Main Page";

            _pokeApi = pokeApi;
            _pageDialogService = pageDialogService;
            _db = new LiteDatabase(Xamarin.Forms.DependencyService.Get<IHelper>().GetFilePath("Pokemon.db"));
            PokemonsPage = _db.GetCollection<PokemonList>();

            NavegarCommand = new DelegateCommand<Pokemon>(async (pokemon) => await NavegarCommandExecute(pokemon));
            GaleriaCommand = new DelegateCommand<Pokemon>(async (pokemon) => await GaleriaCommandExecute(pokemon));

            Pokemons = new InfiniteScrollCollection<Pokemon>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    var items = new List<Pokemon>();
                    PokemonList = await _pokeApi.ObterListaPokemons(offset: OffSet);

                    if (PokemonList != null)
                    {
                        foreach (var poke in PokemonList.results)
                        {
                            var pokemon = await _pokeApi.ObterPokemon(poke.url);
                            if (pokemon != null)
                                items.Add(pokemon);
                        }
                        offset += 20;
                    }
                    IsBusy = false;

                    return items;
                },
                OnCanLoadMore = () =>
                {
                    if (!string.IsNullOrEmpty(PokemonList.next))
                        return true;

                    return false;
                }

            };

            Pokemons.LoadMoreAsync();

        }

        private async Task GaleriaCommandExecute(Pokemon pokemon)
        {
            var parameter = new NavigationParameters();
            parameter.Add("pokemon", pokemon);

            await NavigationService.NavigateAsync($"{nameof(GaleriaPage)}", parameter);
        }

        private async Task NavegarCommandExecute(Pokemon pokemon)
        {
            await PopupNavigation.Instance.PushAsync(new PokemonPopupPage(pokemon));
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var navigationMode = parameters.GetNavigationMode();
            if (navigationMode != Prism.Navigation.NavigationMode.Back)
            {
                //await LoadPokemons();
            }
        }

        async Task LoadPokemons()
        {
            try
            {
                IsBusy = true;
                await _pokeApi.ObterListaPokemons().ContinueWith(async t =>
                {
                    if (t.Result != null)
                    {
                        foreach (var poke in t.Result.results)
                        {
                            var pokemon = await _pokeApi.ObterPokemon(poke.url);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("PokeApp", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task StoreData(PokemonList pokemonList)
        {
            if (PokemonsPage.Count() == 0)
            {
                PokemonsPage.Insert(pokemonList);
                return;
            }

            var hasNextPage = PokemonsPage.Find(x => x.next == pokemonList.next);
            if (hasNextPage.Count() > 0) return;

            PokemonsPage.Insert(pokemonList);


        }
    }
}
