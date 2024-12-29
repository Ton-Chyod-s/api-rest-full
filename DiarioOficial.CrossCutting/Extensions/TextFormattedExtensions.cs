using System.Globalization;

namespace DiarioOficial.CrossCutting.Extensions
{
    public static class TextFormattedExtensions
    {
        public static string TextToTitleCase(this string name)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            var nameLowerCase = name.ToLower();

            var titleCase = textInfo.ToTitleCase(nameLowerCase);
            return titleCase;
        }
    }
}
