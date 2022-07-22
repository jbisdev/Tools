using System.Linq;
using System.Text;

namespace Jbisdev.Tools.Helpers.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Get last character of a string value
        /// </summary>
        /// <param name="input">value to split</param>
        /// <param name="nbCharacters">nb characters to get </param>
        /// <example>value is value and nbCharacters is 3, should return lue</example>
        /// <returns>The last nbCharacters of the value</returns>
        public static string GetLastCharacters(this string input, int nbCharacters)
        {
            if (nbCharacters > input.Length)
            {
                return null;
            }
            var result = new StringBuilder();
            for (int characterIndex = 0; characterIndex < nbCharacters; characterIndex++)
            {
                result.Append(input.Last());
                input = input.Remove(input.Length - 1);
            }
            return new string(result.ToString().Reverse().ToArray());
        }
    }
}