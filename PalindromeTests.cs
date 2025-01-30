using PalindromeSearch;
using Xunit;

namespace PalindromeSearch.Tests
{
    public class PalindromeTests
    {
        [Fact]
        public void TestPalindrome_returnTrue_ifPalindrome()
        {
            //Arrange
            var palindrome = new Palindrome("abba");

            //Act
            var result = palindrome.OnkoPalindromi();

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("abc", false)]
        [InlineData("A man a plan a canal Panama", true)]
        public void TestPalindrome_handlesEdgeCases(string syote, bool expected)
        {
            //Arrange
            var palindrome = new Palindrome(syote);

            //Act
            var result = palindrome.OnkoPalindromi();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindLongestPalindrome()
        {
            //Arrange
            var palindrome = new Palindrome("babad");

            //Act
            var result = palindrome.PisimmanPalindrominHaku();

            //Assert
            Assert.True(result == "aba" || result == "bab");

        }

        [Theory]
        [InlineData("cbbd", "bb")]
        [InlineData("hello", "ll")]
        [InlineData("xyz", "")]
        public void FindPalindrome_handlesEdgeCases(string syote, string expected)
        {
            //Arrange
            var palindrome = new Palindrome(syote);

            //Act
            var result = palindrome.PisimmanPalindrominHaku();

            //Assert
            Assert.Equal(expected, result);
        }
    }
}