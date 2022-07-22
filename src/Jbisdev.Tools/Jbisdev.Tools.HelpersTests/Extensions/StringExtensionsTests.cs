using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Helpers.Extensions.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        [TestMethod("GetLastCharacters : When input is value and nbCharacters is 3, should return lue")]
        public void GetLastCharacters()
        {
            var input = "value";
            var expected = "lue";

            var result = input.GetLastCharacters(3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("GetLastCharacters : When input is value and nbCharacters is 6, should return null")]
        public void GetLastCharactersNbCharactersGreaterThanInputLength()
        {
            var input = "value";

            var result = input.GetLastCharacters(6);

            Assert.IsNull(result);
        }

        [TestMethod("GetLastCharacters : When input is value and nbCharacters is 5, should return value")]
        public void GetLastCharactersSameNbCharactersThanInputLength()
        {
            var input = "value";
            var expected = input;

            var result = input.GetLastCharacters(5);

            Assert.AreEqual(expected, result);
        }
    }
}