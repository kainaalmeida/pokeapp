using PokeApp.Droid.Helpers;
using PokeApp.Utils;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Helper))]
namespace PokeApp.Droid.Helpers
{
    public class Helper : IHelper
    {
        public string GetFilePath(string file)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }
    }
}