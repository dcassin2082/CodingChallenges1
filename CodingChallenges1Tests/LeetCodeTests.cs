using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenges1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CodingChallenges1.Tests
{
    [TestClass()]
    public class LeetCodeTests
    {
        [TestMethod()]
        public void TwoSumTest()
        {
            int[] nums = { 3, 3 };
            int n = 6;
            LeetCode.TwoSum(nums, n);
        }

        [TestMethod()]
        public void FirstNonRepeatingCharInStringTest()
        {
            string s = "abacbadeff";
            Assert.AreEqual('c', LeetCode.FirstNonRepeatingCharInString(s));
        }

        [TestMethod()]
        public void MaxAreaTest()
        {
            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Assert.AreEqual(LeetCode.MaxArea(height), 49);
            height = new int[2] { 1, 1 };
            Assert.AreEqual(LeetCode.MaxArea(height), 1);
        }

        [TestMethod()]
        public void MinWindowSubstringTest()
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";
            string expected = "BANC";
            Assert.AreEqual(LeetCode.MinWindowSubstring(s, t), expected);
            s = "min window substring";
            t = "down";
            expected = "ndow";
            Assert.AreEqual(LeetCode.MinWindowSubstring(s, t), expected);
        }

        [TestMethod()]
        public void BinarySearchTest()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int n = 7;
            Assert.IsTrue(LeetCode.BinarySearch(arr, n) == true);
            n = 11;
            Assert.IsTrue(LeetCode.BinarySearch(arr, n) == false);
            n = 0;
            Assert.IsTrue(LeetCode.BinarySearch(arr, n) == false);
        }

        [TestMethod()]
        public void ClimbStairsTest()
        {
            int[] fibs = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            for (int i = 1; i < 10; i++)
            {
                Assert.AreEqual(LeetCode.ClimbStairs(i), fibs[i + 1]);
            }

        }

        [TestMethod()]
        public void ShuffleTest()
        {
            //[2,5,1,3,4,7], n = 3  ===>  output should be [2,3,5,4,1,7] 
            int n = 3;
            int[] nums = { 2, 5, 1, 3, 4, 7 };
            int[] expected = { 2, 3, 5, 4, 1, 7 };
            CollectionAssert.AreEqual(LeetCode.Shuffle(nums, n), expected);
            n = 4;
            nums = new int[] { 1, 2, 3, 4, 4, 3, 2, 1 };
            expected = new int[] { 1, 4, 2, 3, 3, 2, 4, 1 };
            CollectionAssert.AreEqual(LeetCode.Shuffle(nums, n), expected);
            n = 2;
            nums = new int[] { 1, 1, 2, 2 };
            expected = new int[] { 1, 2, 1, 2 };
            CollectionAssert.AreEqual(LeetCode.Shuffle(nums, n), expected);
        }

        [TestMethod()]
        public void IsPalindromeTest()
        {
            int x = 121;
            Assert.IsTrue(LeetCode.IsPalindrome(x));
            x = -121;
            Assert.IsFalse(LeetCode.IsPalindrome(x));
            x = 10;
            Assert.IsFalse(LeetCode.IsPalindrome(x));
        }

        [TestMethod()]
        public void ReverseTest()
        {
            int n = 123;
            int exp = 321;
            //  -321 120 / 21
            Assert.AreEqual(LeetCode.Reverse(n), exp);
            n *= -1;
            exp *= -1;
            Assert.AreEqual(LeetCode.Reverse(n), exp);
            n = 120000000;
            exp = 21;
            Assert.AreEqual(LeetCode.Reverse(n), exp);
            n = int.MinValue + 1;
            Assert.AreEqual(LeetCode.Reverse(n), 0);
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            string s = "III";
            int exp = 3;
            Assert.AreEqual(LeetCode.RomanToInt(s), exp);
            s = "LVIII";
            exp = 58;
            Assert.AreEqual(LeetCode.RomanToInt(s), exp);
            s = "MCMXCIV";
            exp = 1994;
            Assert.AreEqual(LeetCode.RomanToInt(s), exp);
        }

        [TestMethod()]
        public void LongestCommonPrefixTest()
        {
            string[] strarr = { "flower", "fkow" };
            Assert.AreEqual(LeetCode.LongestCommonPrefix(strarr), "f");
        }

        [TestMethod()]
        public void IsValidTest()
        {
            /*  Input: s = "()"
                Output: true
            Input: s = "()[]{}"
            Output: true
            Input: s = "(]"
            Output: false */
            string s = "()";
            Assert.IsTrue(LeetCode.IsValid(s));
            s = "()";
            Assert.IsTrue(LeetCode.IsValid(s));
            s = "(]";
            Assert.IsFalse(LeetCode.IsValid(s));


        }

        [TestMethod()]
        public void StackThisTest()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] exp = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            CollectionAssert.AreEqual(LeetCode.StackThis(arr), exp);
        }

        [TestMethod()]
        public void ReverseStringUsingStackTest()
        {
            string s = "reverse this string using a stack";
            string exp = "kcats a gnisu gnirts siht esrever";
            Assert.AreEqual(LeetCode.ReverseStringUsingStack(s), exp);
        }

        [TestMethod()]
        public void ReverseBitsTest()
        {
            //11110101101 1965
            // 10110101111 1455
            int[] arr = new int[] { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1 };
            int[] exp = new int[] { 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1 };
            CollectionAssert.AreEqual(LeetCode.ReverseBits(arr), exp);
        }

        [TestMethod()]
        public void ReverseBitsToDecimalTest()
        {
            // Given the following integer array: int[] arr = { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1 },
            // write a method that reverses the order of the bits in the array and computes the sum of the bits
            // for the new array as decimal:
            //  Example: if arr =  { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1 }
            //              then ReverseBitsToDecimal(arr) = 1455
            //  constraints: 1 <= arr.Length < 31

            int[] arr = new int[] { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1 };
            Assert.AreEqual(LeetCode.ReverseBitsToDecimal(arr), 1455);
            arr = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(LeetCode.ReverseBitsToDecimal(arr), int.MaxValue);
        }

        [TestMethod()]
        public void MyStringValidTest()
        {
            string s = "53fb";
            Assert.IsTrue(LeetCode.MyStringValid(s));
            s = "533ffb";
            Assert.IsTrue(LeetCode.MyStringValid(s));
            s = "553fbb";
            Assert.IsTrue(LeetCode.MyStringValid(s));
        }

        [TestMethod()]
        public void TowerOfHanoiTest()
        {
            LeetCode.TowerOfHanoi(2, 1, 3, 2);
        }

        [TestMethod()]
        public void RemoveDuplicatesFromSortedArrayTest()
        {
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int[] expectedNums = new int[] { };
            int k = 5;
            Assert.AreEqual(LeetCode.RemoveDuplicatesFromSortedArray(nums), expectedNums.Length);
            for (int i = 0; i < k; i++)
            {
                Assert.AreEqual(nums[i], expectedNums[i]);
            }
        }

        [TestMethod()]
        public void RemoveElementTest()
        {
            int[] nums = { 3, 2, 2, 3 };
            Assert.AreEqual(LeetCode.RemoveElement(nums, 3), 2);
        }

        [TestMethod()]
        public void RemoveElementUsingStackMethodTest()
        {
            int[] nums = { 3, 2, 2, 3 };
            Assert.AreEqual(LeetCode.RemoveElement(nums, 3), 2);
        }

        [TestMethod()]
        public void StrStrTest()
        {
            string haystack = "mississippi";
            string needle = "issippi";
            Assert.AreEqual(LeetCode.StrStr(haystack, needle), 4);

        }

        [TestMethod()]
        public void DivideTest()
        {
            int dividend = 10, divisor = 3;
            int exp = 3;
            Assert.AreEqual(LeetCode.Divide(dividend, divisor), exp);
            dividend = 7;
            divisor = -3;
            exp = -2;
            Assert.AreEqual(LeetCode.Divide(dividend, divisor), exp);
            dividend = int.MinValue;
            divisor = -1;
            exp = int.MaxValue;
            Assert.AreEqual(LeetCode.Divide(dividend, divisor), exp);
        }

        [TestMethod()]
        public void LengthOfLastWordTest()
        {
            string s = "   fly me   to   the moon  ";
            Assert.AreEqual(LeetCode.LengthOfLastWord(s), 4);
            string t = "antidisestablishmentarianism";
            int len = t.Length;
            s = "luffy is still antidisestablishmentarianism";
            Assert.AreEqual(LeetCode.LengthOfLastWord(s), t.Length);
        }

        [TestMethod()]
        public void PlusOneTest()
        {
            int[] digits = { 9, 9 };
            int[] exp = { 1, 0, 0 };
            CollectionAssert.AreEqual(LeetCode.PlusOne(digits), exp);
        }

        [TestMethod()]
        public void PlusOneBigIntegerTest()
        {
            int[] digits = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            int[] exp = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(LeetCode.PlusOneBigInteger(digits), exp);
        }

        [TestMethod()]
        public void MySqrtTest()
        {
            int x = 100;
            int sqrt = (int)Math.Pow(100, 0.5);
            //Assert.AreEqual(LeetCode.MySqrt(x), sqrt);
            x = int.MaxValue;
            sqrt = (int)Math.Pow(x, 0.5);
            //Assert.AreEqual(LeetCode.MySqrt(x), sqrt);
            x = 8;
            sqrt = (int)Math.Pow(x, 0.5);
            Assert.AreEqual(LeetCode.MySqrt(x), sqrt);
        }

        [TestMethod()]
        public void MergeTest()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            int m = 3;
            int n = 3;
            int[] exp = { 1, 2, 2, 3, 5, 6 };
            CollectionAssert.AreEqual(LeetCode.Merge(nums1, m, nums2, n), exp);

            nums1 = new int[] { 1 };
            nums2 = new int[] { };
            m = 1;
            n = 0;
            exp = new int[] { 1 };
            CollectionAssert.AreEqual(LeetCode.Merge(nums1, m, nums2, n), exp);

            nums1 = new int[] { 0 };
            nums2 = new int[] { 1 };
            m = 0;
            n = 1;
            exp = new int[] { 1 };
            CollectionAssert.AreEqual(LeetCode.Merge(nums1, m, nums2, n), exp);
        }

        [TestMethod()]
        public void TwoSumIITest()
        {
            int[] numbers = { 2, 7, 11, 15 };
            int target = 9;
            int[] exp = { 1, 2 };
            CollectionAssert.AreEqual(LeetCode.TwoSum2(numbers, target), exp);

            numbers = new int[] { 2, 3, 4 };
            target = 6;
            exp = new int[] { 1, 3 };
            CollectionAssert.AreEqual(LeetCode.TwoSum2(numbers, target), exp);

            numbers = new int[] { -1, 0 };
            target = -1;
            exp = new int[] { 1, 2 };
            CollectionAssert.AreEqual(LeetCode.TwoSum2(numbers, target), exp);
        }

        [TestMethod()]
        public void IsHappyTest()
        {
            int n = 19;
            Assert.IsTrue(LeetCode.IsHappy(n));

            n = 2;
            Assert.IsFalse(LeetCode.IsHappy(n));
        }

        [TestMethod()]
        public void CountPrimesTest()
        {
            int n = 37;
            int exp = 4;
            Assert.AreEqual(LeetCode.CountPrimes(n), exp);

            n = 0;
            exp = 0;
            Assert.AreEqual(LeetCode.CountPrimes(n), exp);
        }

        [TestMethod()]
        public void IsUglyTest()
        {
            int n = int.MaxValue;
            Assert.IsFalse(LeetCode.IsUgly(n));

            n = 1;
            Assert.IsTrue(LeetCode.IsUgly(n));

            n = 14;
            Assert.IsFalse(LeetCode.IsUgly(n));
        }

        [TestMethod()]
        public void MissingNumberTest()
        {
            int[] nums = { 3, 0, 1 };
            int exp = 2;
            Assert.AreEqual(LeetCode.MissingNumber(nums), exp);

            nums = new int[] { 0, 1 };
            exp = 2;
            Assert.AreEqual(LeetCode.MissingNumber(nums), exp);

            nums = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            exp = 8;
            Assert.AreEqual(LeetCode.MissingNumber(nums), exp);
        }

        [TestMethod()]
        public void IsPowerOfThreeTest()
        {
            int n = 27;
            Assert.IsTrue(LeetCode.IsPowerOfThree(n));

            n = 0;
            Assert.IsFalse(LeetCode.IsPowerOfThree(n));

            n = -1;
            Assert.IsFalse(LeetCode.IsPowerOfThree(n));
        }

        [TestMethod()]
        public void LastStoneWeightTest()
        {
            int[] stones = { 2, 7, 4, 1, 8, 1 };
            int exp = 1;
            Assert.AreEqual(LeetCode.LastStoneWeight(stones), exp);

            stones = new int[] { 1 };
            exp = 1;
            Assert.AreEqual(LeetCode.LastStoneWeight(stones), exp);
        }

        [TestMethod()]
        public void MergeTwoListsRecursiveTest()
        {
            ListNode list1 = new ListNode(1);
            list1.next = new ListNode(2);
            list1.next.next = new ListNode(4);
            ListNode list2 = new ListNode(1);
            list2.next = new ListNode(3);
            list2.next.next = new ListNode(4);

            var result = LeetCode.MergeTwoListsRecursive(list1, list2);
        }

        [TestMethod()]
        public void MergeTwoListsIterativeTest()
        {
            ListNode list1 = new ListNode(1);
            list1.next = new ListNode(2);
            list1.next.next = new ListNode(4);
            ListNode list2 = new ListNode(1);
            list2.next = new ListNode(3);
            list2.next.next = new ListNode(4);

            var result = LeetCode.MergeTwoListsIterative(list1, list2);
        }

        [TestMethod()]
        public void CreateLinkedListTest()
        {
            LinkedList<int> list = LeetCode.CreateLinkedList();
        }

        [TestMethod()]
        public void MaxProfitTest()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            int exp = 5;
            Assert.AreEqual(LeetCode.MaxProfit(prices), exp);
        }

        [TestMethod()]
        public void MaxProfitTest1()
        {
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            int exp = 5;
            Assert.AreEqual(LeetCode.MaxProfit(prices), exp);

            prices = new int[] { 7, 6, 4, 3, 1 };
            exp = 0;
            Assert.AreEqual(LeetCode.MaxProfit(prices), exp);
        }

        [TestMethod()]
        public void SingleNumberTest()
        {
            int[] nums = { 4, 1, 2, 1, 2 };
            int exp = 4;
            Assert.AreEqual(LeetCode.SingleNumber(nums), exp);

            nums = new int[] { 2, 2, 1 };
            exp = 1;
            Assert.AreEqual(LeetCode.SingleNumber(nums), exp);

            nums = new int[] { 1 };
            exp = 1;
            Assert.AreEqual(LeetCode.SingleNumber(nums), exp);
        }

        [TestMethod()]
        public void MajorityElementTest()
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2 };
            int exp = 2;
            Assert.AreEqual(LeetCode.MajorityElement(nums), exp);

            nums = new int[] { 3, 2, 3 };
            exp = 3;
            Assert.AreEqual(LeetCode.MajorityElement(nums), exp);

            nums = new int[] { 987654321 };
            exp = 987654321;
            Assert.AreEqual(LeetCode.MajorityElement(nums), exp);
        }

        [TestMethod()]
        public void IsIsomorphicTest()
        {
            string s = "egg", t = "add";
            //Assert.IsTrue(LeetCode.IsIsomorphic(s, t));

            s = "foo";
            t = "bar";
            //Assert.IsFalse(LeetCode.IsIsomorphic(s, t));

            s = "paper";
            t = "title";
            Assert.IsTrue(LeetCode.IsIsomorphic(s, t));

            s = "bbbaaaba";
            t = "aaabbbba";
            Assert.IsFalse(LeetCode.IsIsomorphic(s, t));
        }

        [TestMethod()]
        public void ContainsDuplicateTest()
        {
            int[] nums = { 1, 3, 3, 4, 3, 2, 4, 2 };
            Assert.IsTrue(LeetCode.ContainsDuplicate(nums));

            nums = new int[] { 1, 2, 3, 1 };
            Assert.IsTrue(LeetCode.ContainsDuplicate(nums));

            nums = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            Assert.IsTrue(LeetCode.ContainsDuplicate(nums));

            nums = new int[] { 4, 3, 2, 1 };
            Assert.IsFalse(LeetCode.ContainsDuplicate(nums));
        }

        [TestMethod()]
        public void ArraySignTest()
        {
            int[] nums = { -1, -2, -3, -4, 3, 2, 1 };
            int exp = 1;
            //Assert.AreEqual(LeetCode.ArraySign(nums), exp);

            //nums = new int[] { 1, 5, 0, 2, -3 };
            //exp = 0;
            //Assert.AreEqual(LeetCode.ArraySign(nums), exp);

            //nums = new int[] { -1, 1, -1, 1, -1 };
            //exp = -1;
            //Assert.AreEqual(LeetCode.ArraySign(nums), exp);

            nums = new int[] { 41, 65, 14, 80, 20, 10, 55, 58, 24, 56, 28, 86, 96, 10, 3, 84, 4, 41, 13, 32, 42, 43, 83, 78, 82, 70, 15, -41 };
            exp = -1;
            Assert.AreEqual(LeetCode.ArraySign(nums), exp);
        }

        [TestMethod()]
        public void AverageTest()
        {
            int[] salary = { 48000, 59000, 99000, 13000, 78000, 45000, 31000, 17000, 39000, 37000, 93000, 77000, 33000, 28000, 4000, 54000, 67000, 6000, 1000, 11000 };
            double exp = 41111.11111;
            Assert.AreEqual(LeetCode.Average(salary), exp);
        }

        [TestMethod()]
        public void SpiralOrderTest()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[3] { 1, 2, 3 };
            matrix[1] = new int[3] { 4, 5, 6 };
            matrix[2] = new int[3] { 7, 8, 9 };
            IList<int> list = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            CollectionAssert.AreEqual((ICollection)LeetCode.SpiralOrder(matrix), list.ToList());
        }

        [TestMethod()]
        public void AddDigitsTest()
        {
            int num = 38;
            int exp = 2;
            Assert.AreEqual(LeetCode.AddDigits(num), exp);
        }

        [TestMethod()]
        public void DiagonalSumTest()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[3] { 1, 2, 3 };
            matrix[1] = new int[3] { 4, 5, 6 };
            matrix[2] = new int[3] { 7, 8, 9 };
            int exp = 25;
            Assert.AreEqual(LeetCode.DiagonalSum(matrix), exp);

            matrix = new int[4][];
            matrix[0] = new int[4] { 1, 1, 1, 1 };
            matrix[1] = new int[4] { 1, 1, 1, 1 };
            matrix[2] = new int[4] { 1, 1, 1, 1 };
            matrix[3] = new int[4] { 1, 1, 1, 1 };
            exp = 8;
            Assert.AreEqual(LeetCode.DiagonalSum(matrix), exp);

            matrix = new int[1][];
            matrix[0] = new int[] { 5 };
            exp = 5;
            Assert.AreEqual(LeetCode.DiagonalSum(matrix), exp);

        }

        [TestMethod()]
        public void SearchTest()
        {
            int[] nums = { 5 };
            int target = 5;
            int exp = 0;
            Assert.AreEqual(LeetCode.Search(nums, target), exp);
        }

        [TestMethod()]
        public void SearchInsertTest()
        {
            int[] nums = { 1 };
            int target = 0;
            int exp = 0;
            Assert.AreEqual(LeetCode.SearchInsert(nums, target), exp);
        }

        [TestMethod()]
        public void RunningSumTest()
        {
            int[] nums = { 1, 2, 3, 4 };
            int[] exp = { 1, 3, 6, 10 };
            //CollectionAssert.AreEqual(LeetCode.RunningSum(nums), exp);

            //nums = new int[] { 1, 1, 1, 1, 1 };
            //exp = new int[] { 1, 2, 3, 4, 5 };
            //CollectionAssert.AreEqual(LeetCode.RunningSum(nums), exp);

            //nums = new int[] { 3, 1, 2, 10, 1 };
            //exp = new int[] { 3, 4, 6, 16, 17 };
            //CollectionAssert.AreEqual(LeetCode.RunningSum(nums), exp);

            //nums = new int[] { -1, 1, -1, 1, -1 };
            //exp = new int[] { -1, 0, -1, 0, -1 };
            //CollectionAssert.AreEqual(LeetCode.RunningSum(nums), exp);

            nums = new int[] { -1 };
            exp = new int[] { -1 };
            CollectionAssert.AreEqual(LeetCode.RunningSum(nums), exp);
        }

        [TestMethod()]
        public void ReverseBitsTest1()
        {
            string s = "00000010100101000001111010011100";
            uint n = 0;
            int count = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != '0')
                {
                    n += (uint)count;
                }
                count *= 2;
            }
            uint exp = 964176192;
            Assert.AreEqual(LeetCode.ReverseBits(n), exp);
        }

        [TestMethod()]
        public void ConstructRectangleTest()
        {
            int area = 4;
            int[] exp = new int[] { 427, 286 };
            //CollectionAssert.AreEqual(LeetCode.ConstructRectangle(area), exp);

            area = 4;
            exp = new int[] { 2, 2 };
            CollectionAssert.AreEqual(LeetCode.ConstructRectangle(area), exp);
        }

        [TestMethod()]
        public void GenerateMatrixTest()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3 };
            matrix[1] = new int[] { 4, 5, 6 };
            matrix[2] = new int[] { 7, 8, 9 };
            int n = 3;
        }
    }
}