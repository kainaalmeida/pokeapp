using PokeApp.Models;
using PokeApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace PokeApp.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {

        private PokemonPopupPageViewModel ViewModel => BindingContext as PokemonPopupPageViewModel;

        public PokemonPopupPage()
        {
            InitializeComponent();
        }

        public PokemonPopupPage(Pokemon pokemon)
            : this()
        {
            ViewModel.Pokemon = pokemon;
        }
    }
}
