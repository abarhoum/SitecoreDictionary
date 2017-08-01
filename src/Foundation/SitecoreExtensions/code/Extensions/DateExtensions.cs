using System;
using System.Globalization;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Formats date in current language with given pattern
        /// </summary>
        /// <param name="input"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Format(this DateTime input, string format = "dd MMM yyyy")
        {
            if (input == null)
                return string.Empty;
            else if (input == DateTime.MinValue)
                return string.Empty;

            if (Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName == "ar")
            {
                return input.ToString(format, new CultureInfo("ar-AE").DateTimeFormat);
            }

            return input.ToString(format, Sitecore.Context.Language.CultureInfo);
        }
    }
}