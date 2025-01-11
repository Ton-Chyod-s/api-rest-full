using System;
using System.Globalization;

namespace DiarioOficial.CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {
        public static string StringToDateTime(this string date)
            => DateTime.Parse(date).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}
