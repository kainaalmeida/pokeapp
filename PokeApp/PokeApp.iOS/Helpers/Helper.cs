using PokeApp.iOS.Helpers;
using PokeApp.Utils;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Helper))]
namespace PokeApp.iOS.Helpers
{
    public class Helper : IHelper
    {
        public string GetFilePath(string file)
        {
            string document = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string library = Path.Combine(document, "..", "Library", "Databases");

            if (!Directory.Exists(library))
            {
                Directory.CreateDirectory(library);
            }

            return Path.Combine(library, file);
        }
    }
}