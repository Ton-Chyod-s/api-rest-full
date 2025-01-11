using System.Globalization;
using DiarioOficial.CrossCutting.Errors.Person;
using System.Xml.Linq;
using DiarioOficial.CrossCutting.Errors;
using OneOf;
using DiarioOficial.CrossCutting.Errors.Common;

namespace DiarioOficial.CrossCutting.Extensions
{
    public static class StringFormattedExtensions
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

        public static OneOf<string, BaseError> EnsureValidYear(this string year)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(year, @"\b20\d{2}\b"))
                return new InvalitYear();

            return year;
        }

        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Insira uma palavra diferente de nula ou vazia");

            return input.Length > 1 ? char.ToUpper(input[0]) + input.Substring(1) : input.ToUpper();
        }

    }
}
