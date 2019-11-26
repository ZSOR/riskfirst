using AddressMicroService.Extensions;
using NUnit.Framework;

namespace AddressMicroServiceTests
{
    public class StringExtensionTests
    {

        [TestCase("string", "string", 0, ExpectedResult = true)]
        [TestCase("Test", "Test", 0, ExpectedResult = true)]
        [TestCase("123", "123", 0, ExpectedResult = true)]
        [TestCase("abcdefghi", "abcdefghi", 0, ExpectedResult = true)]
        [TestCase("    Test    ", "    Test    ", 0, ExpectedResult = true)]
        public bool TestSameStringsTrue(string string1, string string2, int score)
        {
            return string1.FuzzyCompare(string2, score);
        }

        [TestCase("abc", "def", 0, ExpectedResult = false)]
        [TestCase("abc", "Abc", 0, ExpectedResult = false)]
        [TestCase(" abc", "abc", 0, ExpectedResult = false)]
        [TestCase("1234", "5678", 0, ExpectedResult = false)]
        public bool TestCompleteSameStringsFalse(string string1, string string2, int score)
        {
            return string1.FuzzyCompare(string2, score, compareCapitalisation: true, compareTrailingWhiteSpace: true);
        }

        [TestCase("abc", "def", 0, ExpectedResult = false)]
        [TestCase("abc", "Abc", 0, ExpectedResult = true)]
        [TestCase(" abc", "abc", 0, ExpectedResult = true)]
        [TestCase("1234", "5678", 0, ExpectedResult = false)]
        public bool TestSanitisedSameStrings(string string1, string string2, int score)
        {
            return string1.FuzzyCompare(string2, score);
        }

        [TestCase("Abc", "abc", 1, ExpectedResult = true)]
        [TestCase("string", "sTring", 1, ExpectedResult = true)]
        [TestCase("STring", "string", 1, ExpectedResult = false)]
        [TestCase("ABC", "abc", 1, ExpectedResult = false)]
        public bool TestFirstCharacterCapitilisation(string string1, string string2, int score)
        {
            return string1.FuzzyCompare(string2, score, compareCapitalisation:true);
        }

        [TestCase("a b", "ab", 1, ExpectedResult = true)]
        [TestCase("a  b", "ab", 1, ExpectedResult = false)]
        [TestCase(" ab", "ab", 0, ExpectedResult = false)]
        [TestCase(" ab", "ab", 1, ExpectedResult = true)]
        [TestCase(" ab ", "ab", 1, ExpectedResult = false)]
        public bool TestWhiteSpace(string string1, string string2, int score)
        {
            return string1.FuzzyCompare(string2, score, compareTrailingWhiteSpace: true);
        }

        [TestCase("abcdef","xyzdef", 3, ExpectedResult = true)]
        [TestCase("Ross","Riss", 3, ExpectedResult = true)]
        [TestCase("yellow","yellaw", 3, ExpectedResult = true)]
        [TestCase("blue","bloo", 3, ExpectedResult = true)]
        public bool TestSpellingMistakes(string string1, string string2, int score)
        {
            return string1.FuzzyCompare(string2, score);
        }
    }
}