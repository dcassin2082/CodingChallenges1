using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace CodingChallenges1
{
    public class Udemy
    {
        public static string StringReversal(string s)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                result = s[i] + result;
            }
            return result;
        }

        public static bool IsAPalindrome(string s)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                result = s[i] + result;
            }
            return result.Equals(s);
        }

        public static int IntegerReversal(int n)
        {
            int sign = Math.Sign(n);
            string s = string.Empty;

            if (n < 0)
                n *= sign;

            while (n > 0)
            {
                s += n % 10;
                n /= 10;
            }
            return int.TryParse(s, out int result) ? result * sign : 0;
        }

        public static char MaxChars(string s)
        {
            /* Given a string, return the character that is most commonly used in the string. */
            // aaaabbbccc === a
            int counter = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c]++;
                counter++;
            }
            return map.OrderByDescending(x => x.Value).First().Key;
        }

        public static char MaxCharsNaiveSolution(string s)
        {
            /* Given a string, return the character that is most commonly used in the string. */
            // Example: aaaabbbccc ==> max char is 'a'
            int maxChars = 0;
            char result = new char();

            for (int i = 0; i < s.Length; i++)
            {
                int count = 0;
                char c = s[i];
                for (int j = 1; j < s.Length; j++)
                {
                    if (s[j] == s[i])
                    {
                        count++;
                    }
                }
                if (count > maxChars)
                {
                    maxChars = count;
                    result = s[i];
                }
            }
            return result;
        }

        public static char FewestChars(string s)
        {
            /* Given a string, return the character that is most commonly used in the string. */
            // aaaabbbccc === a
            int counter = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c]++;
                counter++;
            }
            return map.OrderByDescending(x => x.Value).LastOrDefault().Key;
        }

        public static int[][] ChunkArray(int[] arr, int n)
        {
            /* Given an array and chunk size, divide the array into many subarrays where each subarray is of the provided size.*/
            // Example: {1,2,3,4,5,6,7,8}, 3 ==> {{1,2,3}, {4,5,6}, {7,8}}

            int ceiling = (int)Math.Ceiling((double)arr.Length / n);
            int[][] result = new int[ceiling][];
            int counter = 0;

            while (arr.Length > 0)
            {
                int[] sub;
                if (n < arr.Length)
                {
                    sub = arr.Take(n).ToArray();
                    arr = arr.Skip(n).ToArray();
                }
                else
                {
                    sub = arr.Take(arr.Length).ToArray();
                    arr = arr.Skip(arr.Length).ToArray();
                }
                result[counter] = sub;
                counter++;
            }
            return result;
        }

        public static bool AreAnagrams(string s, string t)
        {
            /*Check to see if two provided strings are anagrams of each other. 
             * One string is an anagram of another if it uses the same characters in the same quantity. 
             * Ignore spaces, case, and punctuation */

            s = s.Replace(" ", "").ToLower();
            t = t.Replace(" ", "").ToLower();
            if (s.Length != t.Length)
                return false;
            Dictionary<char, int> mapS = new Dictionary<char, int>();
            Dictionary<char, int> mapT = new Dictionary<char, int>();
            bool result = false;

            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                {
                    if (!mapS.ContainsKey(c))
                        mapS.Add(c, 1);
                    else
                        mapS[c]++;
                }
            }
            foreach (char c in t.Replace(" ", "").ToLower())
            {
                if (!char.IsPunctuation(c))
                {
                    if (!mapT.ContainsKey(c))
                        mapT.Add(c, 1);
                    else
                        mapT[c]++;
                }
            }
            foreach (char c in mapS.Keys)
            {
                if (mapT.ContainsKey(c) && mapT[c] == mapS[c])
                    result = true;
                else
                    return false;
            }
            return result;
        }

        public static string? SentenceCapitalization(string s)
        {
            /*  Write a function that accepts a string. The function should capitalize the first letter of 
             *      each word in the string and return the result. */

            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(s))
            {
                string[] arr = s.Split(" ");

                arr = arr.Where(a => !string.IsNullOrWhiteSpace(a)).ToArray();
                foreach (var item in arr)
                {
                    char c = item[0];
                    result += char.ToUpper(c) + item.Substring(1, item.Length - 1) + " ";
                }
            }

            return result;
        }

        public static void Steps(int n)
        {
            /*Write a function that accepts a positive number N. The function should console log a step shape  
             * with N levels using the # character. Make sure the step has spaces on the right hand side! */

            if (n < 1)
            {
                Console.WriteLine("No steps to print");
                return;
            }

            string s = "";
            string[] levels = new string[n];
            for (int i = 0; i < n; i++)
            {
                s += "#";
            }
            levels[n - 1] = s;
            int counter = 1;
            while (counter < n)
            {
                s = s.Remove(s.Length - counter, 1).Insert(s.Length - 1, " ");
                levels[n - counter - 1] = s;
                counter++;
            }
            foreach (var level in levels)
            {
                Console.WriteLine($"'{level}' \t length = {level.Length}");
            }
        }

        public static string[] StepsSimplerSolution(int n)
        {
            // n must contain at least 1 symbol
            if (n < 1)
                return new string[] { };  //  Alternatively:   return Array.Empty<string>();

            // Create an array to hold all of our levels that we will print out
            string[] results = new string[n];

            // Set a default string then fill it up with symbols up to length n
            string s = string.Empty;
            for (int i = 0; i < n; i++)
            {
                s += "#";
            }

            // Set the last element of the array to our default string (i.e. string is filled up with #'s)
            results[results.Length - 1] = s;

            // Set a j counter to length of array minus 1 so we know where we are in each string for replacing the symbol with space
            int j = n - 1;

            // Now we will start from the second to last element of the array and replace # symbol with empty space " "
            //      this may seem counter-intuitive since we are looping from  (i = 1 to n)
            for (int i = 1; i < n; i++)
            {
                s = s.Remove(s.Length - i, 1).Insert(s.Length - 1, " ");
                results[--j] = s;
            }

            return results;
        }
        public static void Pyramid(int n)
        {
            /*Write a function that accepts a positive number N. The function should console log a step shape with N levels using the # character. 
             * Make sure the step has spaces on the right hand side! Note that each string will be of length 2n - 1  */
            /*'  #  '
            * ' ### '
            * '#####'
            * */
            int length = 2 * n - 1;
            string s = string.Empty;
            string[] levels = new string[n];
            for (int i = 0; i < length; i++)
            {
                s += "#";
            }
            levels[n - 1] = s;
            int right = 1, left = 0;

            for (int i = 0; i < n - 1; i++)
            {
                // remove last char and replace it with " "
                s = s.Remove(s.Length - right, 1).Insert(s.Length - right, " ").Remove(left, 1).Insert(left, " ");
                levels[n - right - 1] = s;
                right++;
                left++;
            }
        }

        public static int FibonacciIterative(int n)
        {
            if (n < 2)
                return n;

            int[] arr = new int[n + 1];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n];
        }

        public static int FibonacciRecursive(int n)
        {
            if (n < 2)
                return n;
            else
            {
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
            }
        }

        public static int FindTheVowels(string s)
        {
            // count the number of vowels in a given string
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;

            foreach (char c in s.ToLower())
            {
                if (vowels.Contains(c))
                    count++;
            }
            return count;
        }

        public static Dictionary<char, int> FindTheVowels(string s, char[] vowels)
        {
            // find the count of each vowel in a string
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char c in s.ToLower())
            {
                if (vowels.Contains(c))
                {
                    if (!map.ContainsKey(c))
                    {
                        map.Add(c, 1);
                    }
                    else
                    {
                        map[c]++;
                    }
                }
            }
            return map;
        }

        public static int[,] SpiralMatrix(int n)
        {
            /* Write a function that accepts an integer N and returns a NxN spiral matrix:   [[1, 2, 3], [8, 9, 4], [7, 6, 5]]  */
            int[,] matrix = new int[n, n];
            int startRow = 0, endRow = n - 1, startCol = 0, endCol = n - 1;
            int counter = 1;

            while (startRow <= endRow && startCol <= endCol)
            {
                // start row = 1,2,3,4  13,14
                for (int i = startCol; i <= endCol; i++)
                {
                    matrix[startRow, i] = counter++;
                }
                startRow++;

                // end col = (4),5,6,7  15
                for (int i = startRow; i <= endRow; i++)
                {
                    matrix[i, endCol] = counter++;
                }
                endCol--;

                // end row = 10,9,8,(7) 16
                for (int i = endCol; i >= startCol; i--)
                {
                    matrix[endRow, i] = counter++;
                }
                endRow--;

                // start col = (1), 12, 11, (10)
                for (int i = endRow; i >= startRow; i--)
                {
                    matrix[i, startCol] = counter++;
                }
                startCol++;
            }

            return matrix;
        }
    }
}