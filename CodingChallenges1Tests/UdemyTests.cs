using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenges1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodingChallenges1.Tests
{
    [TestClass()]
    public class UdemyTests
    {
        [TestMethod()]
        public void StringReversalTest()
        {
            string s = "reverse this string";
            string t = "gnirts siht esrever";
            string reverseString = Udemy.StringReversal(s);
            Assert.AreEqual(reverseString, t);
            Assert.AreNotEqual(reverseString, s);
        }

        [TestMethod()]
        public void IsAPalindromeTest()
        {
            string[] strings = { "kayak", "saas", "bob", "abcdefgfedcba" };
            foreach (var s in strings)
            {
                Assert.IsTrue(Udemy.IsAPalindrome(s));
            }

            strings = new string[] { "banana", "palindrome", "daniel" };
            foreach (var s in strings)
            {
                Assert.IsFalse(Udemy.IsAPalindrome(s));
            }
        }

        [TestMethod()]
        public void IntegerReversalTest()
        {
            int x = -987654321, y = -123456789;
            Assert.AreEqual(Udemy.IntegerReversal(x), y);
            Assert.AreEqual(Udemy.IntegerReversal(y), x);
            x = 01;
            y = 1;
            Assert.AreEqual(Udemy.IntegerReversal(x), y);
        }

        [TestMethod()]
        public void MaxCharsTest()
        {
            string s = "abcdeffgabb";
            Assert.IsTrue(Udemy.MaxChars(s) == 'b');
        }

        [TestMethod()]
        public void MaxCharsNaiveSolutionTest()
        {
            string s = "abcdeffgabb";
            Assert.IsTrue(Udemy.MaxCharsNaiveSolution(s) == 'b');
        }

        [TestMethod()]
        public void FewestCharsTest()
        {
            string s = "abcdeffgabb";
            Assert.IsTrue(Udemy.FewestChars(s) == 'g');
        }

        [TestMethod()]
        public void ChunkArrayTest()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int n = 3;
            int[][] expected = new int[3][];
            expected[0] = new int[] { 1, 2, 3 };
            expected[1] = new int[] { 4, 5, 6 };
            expected[2] = new int[] { 7, 8 };
            var actual = Udemy.ChunkArray(arr, n);
            Assert.AreEqual(actual.Length, expected.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                int[] exp = expected[i];
                int[] act = actual[i];
                Assert.AreEqual(exp.Length, act.Length);
                for (int j = 0; j < exp.Length; j++)
                {
                    Assert.AreEqual(exp[j], act[j]);
                }
            }

        }

        [TestMethod()]
        public void AreAnagramsTest()
        {
            string s = "alec !!?? Guinnes s";
            string t = "genuine ClAss!?.,;:";
            s = "anagtam";
            t = "nbgbram";
            Assert.IsFalse(Udemy.AreAnagrams(s, t));
        }

        [TestMethod()]
        public void SentenceCapitalizationTest()
        {
            string s = "capitalize this sentence ! ? . ,    ";
            string t = "Capitalize This Sentence ! ? . , ";
            Assert.AreEqual(Udemy.SentenceCapitalization(s), t);
        }

        [TestMethod()]
        public void StepsTest()
        {
            Udemy.Steps(0);
        }

        [TestMethod()]
        public void StepsSimplerSolutionTest()
        {
            Udemy.Steps(0);
        }

        [TestMethod()]
        public void PyramidTest()
        {
            Udemy.Pyramid(4);
        }

        [TestMethod()]
        public void FibonacciRecursiveTest()
        {
            Assert.AreEqual(55, Udemy.FibonacciRecursive(10));
        }

        [TestMethod()]
        public void FibonacciIterativeTest()
        {
            Assert.AreEqual(55, Udemy.FibonacciIterative(10));
        }

        [TestMethod()]
        public void FindTheVowelsTest()
        {
            string s = "coUnt the Vowels in this strIng";
            Assert.AreEqual(Udemy.FindTheVowels(s), 8);
        }

        [TestMethod()]
        public void FindTheVowelsTest1()
        {
            string s = "coUnt the Vowels in this strIng";
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('o', 2);
            map.Add('u', 1);
            map.Add('e', 2);
            map.Add('i', 3);
            var maptest = Udemy.FindTheVowels(s, vowels);
            Assert.AreEqual(maptest.Count, map.Count);
            Assert.AreEqual(maptest.Keys.Count, map.Keys.Count);
        }

        [TestMethod()]
        public void SpiralMatrixTest()
        {
            int n = 4;
            int[,] spiralMatrix = Udemy.SpiralMatrix(n);
            for(int i = 0; i < spiralMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < spiralMatrix.GetLength(1); j++)
                {
                    Debug.Write(spiralMatrix[i,j] + " ");
                }
                Debug.WriteLine("\n");
            }
        }


    }
}