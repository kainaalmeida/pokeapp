using Prism;
using Prism.Ioc;
using PokeApp.ViewModels;
using PokeApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApp.Services;
using PokeApp.Services.Contrato;
using PokeApp.Views.Popups;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PokeApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();



            containerRegistry.Register<IPokeApi, PokeApi>();
            containerRegistry.RegisterForNavigation<PokemonPopupPage, PokemonPopupPageViewModel>();
            containerRegistry.RegisterForNavigation<GaleriaPage, GaleriaPageViewModel>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                App.Current.MainPage.DisplayAlert("Aviso", "No momento você está sem conexão com a internet!", "OK");
            else if(e.NetworkAccess == NetworkAccess.Internet)
                App.Current.MainPage.DisplayAlert("Aviso", "Conectado a internet!", "OK");
        }
    }
}
