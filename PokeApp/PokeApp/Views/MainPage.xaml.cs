using dotMorten.Xamarin.Forms;
using PokeApp.Models;
using PokeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PokeApp.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        private void AutoSuggestBox_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            AutoSuggestBox box = (AutoSuggestBox)sender;

            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.ItemsSource = null;
                    lv.ItemsSource = ViewModel.Pokemons;
                }
                else
                {
                    var suggestions = ViewModel.AutoComplete(box.Text);
                    box.ItemsSource = suggestions.ToList();
                }
            }
        }

        private void AutoSuggestBox_QuerySubmitted(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e)
        {


        }

        private void AutoSuggestBox_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            var query = e.SelectedItem as string;
            var items = new List<Pokemon>();
            if (!string.IsNullOrEmpty(query))
            {

                ViewModel.Pokemons.ForEach(x =>
                {
                    x.types.ForEach(t =>
                    {
                        if (t.type.name.Equals(query))
                            items.Add(x);
                    });
                });

                if (items.Count > 0)
                    lv.ItemsSource = items;
                    
            }
            else
            {
                lv.ItemsSource = ViewModel.Pokemons;
            }
        }
    }
}