using PokeApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeApp.ViewModels
{
    public class PokemonPopupPageViewModel : BindableBase
    {

        private Pokemon _pokemon = new Pokemon();
        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set { SetProperty(ref _pokemon, value); }
        }


        public PokemonPopupPageViewModel()
        {

        }
    }
}
