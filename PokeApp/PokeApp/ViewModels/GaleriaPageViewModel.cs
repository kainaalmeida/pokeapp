using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PokeApp.Models;
using Prism.Navigation;

namespace PokeApp.ViewModels
{
    public class GaleriaPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> Images { get; } = new ObservableCollection<string>();

        public GaleriaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var pokemon = parameters.GetValue<Pokemon>("pokemon");

            if (pokemon != null)
                LoadGalery(pokemon).ConfigureAwait(false);

        }

        async Task LoadGalery(Pokemon pokemon)
        {
            Images.Add(pokemon.sprites.back_default);
            Images.Add(pokemon.sprites.back_shiny);
            Images.Add(pokemon.sprites.front_default);
            Images.Add(pokemon.sprites.front_shiny);
        }

    }
}
