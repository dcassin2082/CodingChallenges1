using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingChallenges1
{
    public class LeetCode
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            // Leet Code: 1 | Easy
            // Returns the indices of the 2 array elements that add up to target: [1,2,3,4,5,6,7,8,9,21], 30 ==> {8,9}

            Dictionary<int, int> map = new Dictionary<int, int>();
            int j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
                j++;
                if (map.ContainsKey(target - nums[j]))
                {
                    int[] result = new int[] { map[target - nums[j]], j };
                    return result;
                }
            }
            return Array.Empty<int>();
        }

        public static char FirstNonRepeatingCharInString(string s)
        {
            /*  Return the first character that only appears once in the string  */
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c]++;
            }
            return map.FirstOrDefault(x => x.Value.Equals(1)).Key;
        }

        public static int MaxArea(int[] height)
        {
            /* Leet Code: 11 - Medium | Container with the most water
             *      Given an array of heights, find the max area that can contain water  */
            int left = 0, right = height.Length - 1;
            int maxArea = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    maxArea = Math.Max(maxArea, height[left] * (right - left));
                    left++;
                }
                else
                {
                    maxArea = Math.Max(maxArea, height[right] * (right - left));
                    right--;
                }
            }
            return maxArea;
        }

        public static string MinWindowSubstring(string s, string t)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            string result = string.Empty;

            foreach (char c in t)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c]++;
            }
            int left = 0, right = 0, counter = map.Count, minLength = s.Length + 1;

            while (right < s.Length)
            {
                char rightChar = s[right++];
                if (map.ContainsKey(rightChar))
                {
                    map[rightChar]--;
                    if (map[rightChar] == 0)
                        counter--;
                }

                while (counter == 0)
                {
                    if (right - left < minLength)
                    {
                        minLength = right - left;
                        result = s.Substring(left, minLength);
                    }

                    char leftChar = s[left++];

                    if (map.ContainsKey(leftChar))
                    {
                        map[leftChar]++;
                        if (map[leftChar] > 0)
                        {
                            counter++;
                        }
                    }
                }
            }
            return result;
        }

        public static bool BinarySearch(int[] arr, int n)
        {
            // 1,2,3,4,5,6,7,8,9,10,  7
            int midpoint = arr.Length / 2;

            if (n == arr[midpoint])
                return true;

            while (arr.Length > 0)
            {
                if (n < arr[midpoint])
                {
                    arr = arr.Take(midpoint).ToArray();
                    // 1,2,3,4,5
                }
                else
                {
                    arr = arr.Skip(midpoint).Take(arr.Length - 1).ToArray();
                    //6,7,8,9,10
                }
                midpoint = arr.Length / 2; // 2

                if (arr.Length == 1)
                {
                    if (arr[0] == n)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }


        public static int ClimbStairs(int n)
        {

            return Helpers.Fibonacci(n + 1);
        }

        public static int[] Shuffle(int[] nums, int n)
        {
            /*  Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn]. Return the array in the form [x1,y1,x2,y2,...,xn,yn]. 
                    example: [2,5,1,3,4,7], n = 3  ===>  output should be [2,3,5,4,1,7]     */

            int[] arr = new int[nums.Length];
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                arr[counter] = nums[i];
                arr[counter + 1] = nums[n + i];
                counter += 2;
            }
            return arr;
        }

        public static bool IsPalindrome(int x)
        {
            /* Given an integer x, return true if x is a palindrome, and false otherwise. Note that -121 and 121- are not palindromes */
            string s = string.Empty;
            if (x < 0 || x > int.MaxValue)
                return false;
            while (x > 0)
            {
                s += x % 10;
                x /= 10;
            }
            string reverse = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                reverse = s[i] + reverse;
            }
            return reverse.Equals(s);
        }

        public static int Reverse(int n)
        {
            /*Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 
             * 32-bit integer range [-231, 231 - 1], then return 0. Assume the environment does not allow you to store 64-bit integers (signed or unsigned). 
                examples: x = 123/321, -123/-321 120/21, etc   */
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

        public static int RomanToInt(string s)
        {
            int result = 0;
            Dictionary<char, int> dictionary = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int value = dictionary[c];
                if (i + 1 < s.Length && dictionary[s[i + 1]] > value)
                    result -= value;
                else
                    result += value;
            }
            return result;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            int minLength = strs.Min(x => x.Length);
            string? shortestString = strs.FirstOrDefault(x => x.Length == minLength);
            string result = string.Empty;

            foreach (string s in strs)
            {
                result = string.Empty;

                for (int i = 0; i < minLength; i++)
                {
                    if (s[i] == shortestString?[i])
                    {
                        result += shortestString[i];
                    }
                    else
                    {
                        if (result == string.Empty)
                            return result;
                        minLength = result.Length;
                    }
                }
            }
            return result;
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                switch (c)
                {
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                            return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                            return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                            return false;
                        break;
                    default:
                        stack.Push(c);
                        break;
                }
            }
            return stack.Count == 0 ? true : false;
        }

        public static int[] StackThis(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }
            return stack.ToArray();
        }

        public static string? ReverseStringUsingStack(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                stack.Push(s[i]);
            }
            // kcats a gnisu gnirts siht esrever
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                result += stack.Pop();
            }
            return result;
        }

        public static int[] ReverseBits(int[] arr)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int i in arr)
            {
                stack.Push(i);
            }
            return stack.ToArray();
        }
        public static int ReverseBitsToDecimal(int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int i in arr)
            {
                stack.Push(i);
            }
            int length = arr.Length - 1;
            int result = 0;

            while (stack.Count > 0)
            {
                if (stack.Pop() == 1)
                {
                    result += (int)Math.Pow(2, length);
                }
                length--;
            }
            // 10110101111 = 1+2+4+8+0+32+0+128+256+0+1024
            return result;
        }

        public static bool MyStringValid(string s)
        {
            // rules: every 5 must close with 'b', every 3 must close with 'f'
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                switch (c)
                {
                    case 'b':
                        if (stack.Count == 0 || stack.Pop() != '5')
                            return false;
                        break;
                    case 'f':
                        if (stack.Count == 0 || stack.Pop() != '3')
                            return false;
                        break;
                    default:
                        stack.Push(c);
                        break;
                }
            }
            return stack.Count == 0 ? true : false;
        }

        public static void TowerOfHanoi(int n, int s, int f, int t)
        {
            if (n > 0)
            {
                TowerOfHanoi(n - 1, s, t, f);
                Debug.WriteLine($"move disk {n} from peg {s} to peg {f}");
                TowerOfHanoi(n - 1, t, f, s);
            }
        }

        public static int[] RemoveDuplicatesFromSortedArray(int[] nums)
        {
            // Leet Code # 29 -  their version returns integer which is the length of the array but their test requires an integer array
            //                  to assert against so I changed the return type to int[] array
            // remove duplicates in place and return the length of the k elements that you sorted (not the entire array)
            // example:  nums = [0,0,1,1,1,2,2,3,3,4] ==> [0,1,2,3,4,....], length = 5

            HashSet<int> set = new HashSet<int>(nums);
            for (int i = 0; i < set.Count; i++)
            {
                nums[i] = set.ElementAt(i);
            }
            return nums;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    list.Add(nums[i]);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                nums[i] = list[i];
            }
            return list.Count;
        }

        public static int RemoveElementUsingStackMethod(int[] nums, int val)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int num in nums)
            {
                if (!(num == val))
                    stack.Push(num);
            }
            nums = new int[stack.Count];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = stack.Pop();
            }
            return stack.Count;
        }

        public static int StrStr(string haystack, string needle)
        {
            /* Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack. */
            if (needle.Length > haystack.Length)
                return -1;
            if (needle == haystack)
                return 0;
            /* we can probably do this without the hash map
                just use needle[0] instead of map.First().Key .....
            */
            Dictionary<char, int> map = new Dictionary<char, int>();
            string substring = string.Empty;

            foreach (char c in needle)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c]++;
            }

            for (int i = 0; i < haystack.Length; i++)
            {
                if (map.First().Key == haystack[i] && i <= haystack.Length - needle.Length)
                {
                    substring += haystack.Substring(i, needle.Length);
                    if (substring == needle)
                    {
                        return i;
                    }
                    else
                    {
                        substring = string.Empty;
                    }
                }
            }

            return -1;
        }

        public static int Divide(int dividend, int divisor)
        {

            long num = (long)dividend;
            long denom = (long)divisor;
            if (num == int.MinValue)
                num++;
            long quotient = num / denom;

            return Convert.ToInt32(quotient);
        }

        public static int LengthOfLastWord(string s)
        {
            /* Given a string s consisting of words and spaces, return the length of the last word in the string. A word is a maximal substring
                consisting of non-space characters only. */

            string[] arr = s.Split(" ");
            foreach (string item in arr)
            {
                item.Replace(" ", "");
            }
            return arr.Where(i => i.Length > 0).Last().Length;
        }

        public static int[] PlusOne(int[] digits)
        {
            /*You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. 
             * The digits are ordered from most significant to least significant in left-to-right order. 
             * The large integer does not contain any leading 0's.
             * Increment the large integer by one and return the resulting array of digits. */

            /*   [9,9,9] = [1,0,0,0] 
                if(s[i] + 1 > 9
             */

            int[] result = new int[digits.Length + 1];
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i] = digits[i] + 1;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                }
            }
            result[0] = 1;
            for (int i = 0; i < digits.Length; i++)
            {
                result[i + 1] = digits[i];
            }
            return result;
        }

        public static int[] PlusOneBigInteger(int[] digits)
        {
            string s = string.Empty;
            for (int i = 0; i < digits.Length; i++)
            {
                s += digits[i];
            }
            bool digitsPlusOne = BigInteger.TryParse(s, out BigInteger result);
            //int digitsPlusOne = int.Parse(s) + 1;
            if (digitsPlusOne)
            {
                result++;
                s = result.ToString();
                int[] newArray = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    newArray[i] = int.Parse(s[i].ToString());
                }
                return newArray;
            }
            return Array.Empty<int>();
        }

        public static int MySqrt(int x)
        {
            /*Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
               remember that this could go as high as int.MaxValue      */
            if (x < 2)
                return x;

            double y = x;
            double z = (y + (x / y)) / 2;

            while (y - z > 0)
            {
                y = z;
                z = (double)(y + (x / y)) / 2;
            }

            return (int)z;
        }

        public static int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // Leet code is a void method, changed to return int[] for testing
            if (n == 0)
                return nums1;
            if (m == 0 && nums1.Length == 0)
            {
                nums1 = nums2;
                return nums1;
            }
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
            return nums1;
        }

        public static int[] TwoSum2(int[] numbers, int target)
        {
            /* Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 < numbers.length.
            Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.
            The tests are generated such that there is exactly one solution. You may not use the same element twice.
            Your solution must use only constant extra space. */

            Dictionary<int, int> map = new Dictionary<int, int>();
            int counter = 0;
            while (counter < numbers.Length)
            {
                if (!map.ContainsKey(numbers[counter]))
                {
                    map.Add(numbers[counter], counter);
                }
                counter++;

                if (map.ContainsKey(target - numbers[counter]))
                {
                    var arr = new int[] { map[target - numbers[counter]], counter };
                    return new int[] { map[target - numbers[counter]] + 1, counter + 1 };
                }
            }
            return Array.Empty<int>();
        }

        /// <summary>
        /// Write an algorithm to determine if a number n is happy. A happy number is a number defined by the following process:
        //   Starting with any positive integer, replace the number by the sum of the squares of its digits.
        //   Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        //   Those numbers for which this process ends in 1 are happy.
        //   Return true if n is a happy number, and false if not.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsHappy(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += (int)Math.Pow(n % 10, 2);
                n /= 10;


                if (n == 0)
                {
                    if (sum == 1)
                        return true;

                    if (sum == 4)
                        return false;
                    n = sum;
                    sum = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Given an integer n, return the number of prime numbers that are strictly less than n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountPrimes(int n)
        {
            if (n <= 1)
                return 0;

            BitArray primes = new BitArray(n, true);
            for (int i = 0; i < 2; i++)
                primes[i] = false;

            int index = 1;
            int counter;
            while ((index < (n - 1)))
            {
                index++;
                if ((primes[index] == true))
                {
                    for (counter = index * 2; counter <= n - 1; counter += index)

                        primes[counter] = false;
                }
            }
            int result = primes.Cast<bool>().Where(p => p.Equals(true)).ToArray().Length;
            return result;
        }

        public static bool IsUgly(int n)
        {
            int[] primes = { 2, 3, 5 };
            if (n == 1 || primes.Contains(n))
                return true;
            if (n == -1 || n == 0 || Helpers.IsPrime(n))
                return false;
            int sign = Math.Sign(n);

            var primeFactors = Helpers.GetPrimeFactors(Math.Abs((long)n), sign);
            foreach (var item in primeFactors)
            {
                //Console.Write($"{item} ");
                if (!primes.Contains(item))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums)
        {
            // HashSet<int> map = new HashSet<int>(nums);
            for (int i = 0; i < nums.Length + 1; i++)
            {
                if (!nums.Contains(i))
                    return i;
            }
            return default;
        }

        /// <summary>
        /// Given an integer n, return true if it is a power of three. Otherwise, return false. An integer n is a power of three, if there exists an integer x such that n == 3x.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfThree(int n)
        {
            if (n == 0)
                return false;

            var log = Math.Ceiling(Math.Log(n, 3));
            if (Math.Pow(3, (int)log) == n)
                return true;

            return false;
        }

        public static int LastStoneWeight(int[] stones)
        {
            if (stones.Length < 2)
                return stones[0];

            while (stones.Length > 1)
            {
                Array.Sort(stones);

                int heaviest = stones[stones.Length - 1];
                int nextHeaviest = stones[stones.Length - 2];
                if (heaviest == nextHeaviest)
                {
                    stones = stones.Take(stones.Length - 2).ToArray();
                }
                else
                {
                    stones[stones.Length - 1] = stones[stones.Length - 1] - stones[stones.Length - 2];
                    stones[stones.Length - 2] = 0;
                }
                stones = stones.Where(s => !s.Equals(0)).ToArray();
                if (stones.Length == 1)
                    return stones[0];
            }
            return 0;
        }

        public static ListNode MergeTwoListsRecursive(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            if (list2 == null)
            {
                return list1;
            }
            if (list1.val < list2.val)
            {
                return new ListNode(list1.val, MergeTwoListsRecursive(list1.next, list2));
            }
            else
            {
                return new ListNode(list2.val, MergeTwoListsRecursive(list2.next, list1));
            }
        }

        public static ListNode MergeTwoListsIterative(ListNode list1, ListNode list2)
        {
            ListNode result = new ListNode();
            ListNode? head = result;
            ListNode? anotherhead = head;
            while (list1 != null || list2 != null)
            {
                if (list1 == null)
                {
                    head.next = list2;
                    list2 = list2.next;
                }
                else if (list2 == null)
                {
                    head.next = list1;
                    list1 = list1.next;
                }
                else if (list1.val < list2.val)
                {
                    head.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    head.next = list2;
                    list2 = list2.next;
                }

                head = head.next;
            }

            return result.next;
        }

        public static LinkedList<int> CreateLinkedList()
        {
            LinkedList<int> list1 = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list1.AddFirst(i + 1);
            }
            return list1;
        }

        public static int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int min = (int)Math.Pow(10, 4);
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i] < prices[i + 1])
                {
                    min = Math.Min(min, prices[i]);
                    maxProfit = Math.Max(maxProfit, (prices[i + 1] - min));
                }
            }
            return maxProfit;
        }

        public static int SingleNumber(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int n in nums)
            {
                if (!map.ContainsKey(n))
                    map.Add(n, 1);
                else
                    map[n]++;
            }
            return map.Where(x => x.Value == 1).FirstOrDefault().Key;

        }

        public static int MajorityElement(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int n in nums)
            {
                if (!map.ContainsKey(n))
                    map.Add(n, 1);
                else
                    map[n]++;
            }
            return map.Where(x => x.Value > nums.Length / 2).FirstOrDefault().Key;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var map = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    if (map.ContainsValue(t[i]))
                        return false;
                    map.Add(s[i], t[i]);
                }
                else
                {
                    if (map[s[i]] != t[i])
                        return false;
                }
            }

            return true;
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                    map.Add(num, 1);
                else
                    map[num]++;
            }
            return map.Any(kvp => kvp.Value > 1);

        }

        public static int ArraySign(int[] nums)
        {
            if (nums.Contains(0))
                return 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                    count++;
            }
            return count % 2 == 0 ? 1 : -1;
        }

        public static double Average(int[] salary)
        {
            Array.Sort(salary);
            salary = salary.Skip(1).Take(salary.Length - 2).ToArray();
            double result = Convert.ToDouble((double)salary.Sum() / salary.Length);
            return Math.Round(result, 5);
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();

            int row = 0, endRow = matrix[0].Length - 1, startCol = 0, endCol = matrix[0].Length - 1, counter = 0;
            while (counter < matrix.Length)
            {
                for (int i = startCol; i <= endCol; i++)
                {
                    int[] arr = matrix[counter++];
                    result.AddRange(arr);
                }
            }
            return result;
        }

        public static int AddDigits(int num)
        {
            //if (num == 0)
            //    return 0;
            //if (num % 9 == 0)
            //    return 0;
            //else
            //    return num % 9;

            /* explanation:  any integer modulus 9 will return a value from 0 thru 9
             * 
             * */
            return num == 0 ? 0 : (num % 9 == 0) ? 9 : num % 9;
        }

        public static int DiagonalSum(int[][] mat)
        {
            if (mat.Length == 1)
                return mat[0][0];

            // primary diagonal
            int p = 0;
            int sum = 0;
            int midpoint = mat.Length / 2;

            for (int i = 0; i < mat.Length; i++)
            {
                sum += mat[i][p++];
            }
            p--;
            // secondary diagonal
            for (int i = 0; i < mat.Length; i++)
            {
                if (mat.Length % 2 != 0)
                {
                    if (i != midpoint)
                        sum += mat[i][p];
                    p--;
                }
                else
                {
                    sum += mat[i][p];
                    p--;
                }
            }

            return sum;
        }

        public static int Search(int[] nums, int target)
        {

            int midpoint = nums.Length / 2;

            if (target == nums[midpoint])
                return Array.IndexOf(nums, target);

            int[] arr = nums;

            while (arr.Length > 0)
            {
                if (target < arr[midpoint])
                {
                    arr = arr.Take(midpoint).ToArray();
                }
                else
                {
                    arr = arr.Skip(midpoint).Take(arr.Length - 1).ToArray();
                }
                midpoint = arr.Length / 2;

                if (arr.Length == 1)
                {
                    if (arr[0] == target)
                        return Array.IndexOf(nums, target);
                    else
                        return -1;
                }
            }
            return -1;
        }

        public static int SearchInsert(int[] nums, int target)
        {
            // 35. Search Insert Position
            int midpoint = nums.Length / 2;

            if (nums.Length == 1)
            {
                if (nums[0] >= target)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            if (nums[midpoint] == target)
                return midpoint;

            int[] arr = nums;

            while (arr.Length > 0)
            {
                if (target < arr[midpoint])
                {
                    arr = arr.Take(midpoint).ToArray();
                }
                else
                {
                    arr = arr.Skip(midpoint).Take(arr.Length - 1).ToArray();
                }
                midpoint = arr.Length / 2; // 2
                                           //[1,3,5,6], target = 2
                if (arr.Length == 1)
                {
                    if (arr[0] == target)
                        return Array.IndexOf(nums, target);
                    else if (arr[0] < target)
                        return Array.IndexOf(nums, arr[0]) + 1;
                    else
                    {
                        if (Array.IndexOf(nums, arr[0]) == 0)
                            return 0;
                        else
                            return Array.IndexOf(nums, arr[0]) - 1;
                    }
                }
            }
            return default;
        }

        public static int[] RunningSum(int[] nums)
        {
            // 1480. Running Sum of 1d Array
            int[] arr = new int[nums.Length];
            arr[0] = nums[0];

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = nums[i] + arr[i - 1];
            }
            return arr;
        }

        public static uint ReverseBits(uint n)
        {
            // 190. Reverse Bits
            // 0011-1001-0111-1000-0010-1001-0100-0000 | 964176192
            // 00000010100101000001111010011100 
            string binary = Convert.ToString(n, 2);
            if(binary.Length < 32)
            {
                binary = binary.PadLeft(32, '0');
            }
            string reverse = string.Empty;
            uint result = 0;
            for(int i = 0; i < binary.Length; i++)
            {
                reverse = binary[i] + reverse;
            }
            int count = 1;
            for (int i = reverse.Length - 1; i >= 0; i--)
            {
                if (reverse[i] != '0')
                {
                    result += (uint)count;
                }
                count *= 2;
            }
            return result;
        }

        public static int[] ConstructRectangle(int area)
        {
            /*  find all factors of area

            */

            //if (Helpers.IsPrime(area))
            //{
            //    return new int[] { area, 1 };
            //}
            int[] result;

            if (area == 1)
            {
                return new int[] { 1, 1 };
            }

            List<int> list = new List<int>();

            for (int i = 1; i <= area; i++)
            {
                if (area % i == 0)
                    list.Add(i);
            }
            if(list.Count % 2 != 0)
            {
                result = new int[] { list[list.Count / 2], list[list.Count / 2] };
            }
            else
            {
                result = new int[] { list[list.Count / 2], list[list.Count / 2 - 1] };
            } 
            return new int[] { list[list.Count / 2], list[list.Count / 2 - 1] };

        }
        /*      122 = 1*122,2*61,
         *          
         * 
         * */

        public static int[][] GenerateMatrix(int n)
        {
            // 59. Spiral Matrix II
            int[][] result = new int[n][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[n];
            }
            int counter = 1;
            int startRow = 0, endRow = n - 1, startCol = 0, endCol = n - 1;

            while (startRow <= endRow && startCol <= endCol)
            {
                for (int i = startCol; i <= endCol; i++)
                {
                    result[startRow][i] = counter++;
                }
                startRow++;
                for (int i = startRow; i <= endRow; i++)
                {
                    result[i][endCol] = counter++;
                }
                endCol--;
                for (int i = endCol; i >= startCol; i--)
                {
                    result[endRow][i] = counter++;
                }
                endRow--;
                for (int i = endRow; i >= startRow; i--)
                {
                    result[i][startCol] = counter++;
                }
                startCol++;
            }
            return result;
        }
    }
}
