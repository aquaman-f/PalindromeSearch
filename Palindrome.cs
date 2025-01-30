using System.Text.RegularExpressions;
using System.Linq;

namespace PalindromeSearch
{
    public class Palindrome
    {
        public string Syote { get; set; }

        public Palindrome(string syote)
        {
            Syote = syote;
        }
        public bool OnkoPalindromi()
        {   
            // String to lowercase and remove any excess 
            string normalized = Regex.Replace(Syote.ToLower(), "[^a-z0-9]", "");

            string backwards = "";

            for (int i = normalized.Length - 1; i >= 0; i--)
            {
                backwards += normalized[i];
            }

            bool isTrue = backwards == normalized;
            return isTrue;
        }

        public string PisimmanPalindrominHaku()
        {
            // Normalize the input to ignore case and non-alphanumeric characters
            string normalized = Regex.Replace(Syote.ToLower(), "[^a-z0-9]", "");

            if (string.IsNullOrEmpty(normalized)) return "";

            int maxLength = 0;
            string foundPalindrome = "";

            for (int i = 0; i < normalized.Length; i++)
            {
                // Check for odd-length palindromes
                string oddPalindrome = ExpandAroundCenter(normalized, i, i);
                if (oddPalindrome.Length > maxLength)
                {
                    maxLength = oddPalindrome.Length;
                    foundPalindrome = oddPalindrome;
                }

                // Check for even-length palindromes
                string evenPalindrome = ExpandAroundCenter(normalized, i, i + 1);
                if (evenPalindrome.Length > maxLength)
                {
                    maxLength = evenPalindrome.Length;
                    foundPalindrome = evenPalindrome;
                }
            }
            if (foundPalindrome.Length > 1)

            { 
                return foundPalindrome; 
            }
            else return "";
        }

        private string ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            // Substring from the expanded bounds
            return s.Substring(left + 1, right - left - 1);
        }
    }
}
