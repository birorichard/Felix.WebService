using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Felix.WebService.Common.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Determines if the input parameter is a valid JSON.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>
        /// True, if the source string is a JSON datatype, false if not.
        /// Returns null if the source parameter is null.
        /// </returns>
        public static bool? IsValidJson(this string source)
        {
            if (source == null || source == default || string.IsNullOrEmpty(source) ||  string.IsNullOrWhiteSpace(source))
                return null;
            try
            {
                JToken obj = JToken.Parse(source);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}
