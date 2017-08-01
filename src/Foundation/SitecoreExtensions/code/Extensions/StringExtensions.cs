using System.Text.RegularExpressions;

namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Strips out the html from string with given length, delimiter and postfix
        /// </summary>
        /// <param name="input"></param>
        /// <param name="delimiter"></param>
        /// <param name="length"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static string Truncate(this string input, string delimiter = " ", int length = 35, string postfix = "...")
        {
            if (input == null)
                return string.Empty;

            if (input.Length < length || input.IndexOf(delimiter, length) == -1)
                return input;

            return input.Substring(0, input.IndexOf(delimiter, length)) + postfix;
        }

        /// <summary>
        /// Strips out the html from string with given length and postfix
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static string TruncateHtml(this string input, int length = 35, string postfix = "...")
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = Regex.Replace(input, "<.*?>", string.Empty);

            return input.Truncate(length: length, postfix: postfix);
        }

        /// <summary>
        /// Strips out the html from string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TruncateHtml(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = Regex.Replace(input, "<.*?>", string.Empty);

            return input;
        }

        /// <summary>
        /// Returns an empty string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string EmptyOrValue(this string source)
        {
            if (source != null)
            {
                return source;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Formats phone number for mobile devices
        /// </summary>
        /// <param name="input"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string FormatPhone(this string input, string prefix = "tel:")
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return string.Format("{0}{1}{2}",
                Sitecore.Context.Language.Name.Equals("ar") ? "&#x200E;" : "",
                prefix,
                input.Replace(" ", ""));
        }

        public static string Humanize(this string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }

        public static string ToCssUrlValue(this string url)
        {
            return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
        }
    }
}