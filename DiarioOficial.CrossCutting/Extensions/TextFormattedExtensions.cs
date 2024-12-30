using System.Globalization;
using DiarioOficial.CrossCutting.Errors.Person;
using System.Xml.Linq;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

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

        public static OneOf<string, BaseError> EnsureValidName(this string name)
        {
            var sizeName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

            if (sizeName < 2)
                return new PersonNotSavedName();

            return name;
        }

    }
}
