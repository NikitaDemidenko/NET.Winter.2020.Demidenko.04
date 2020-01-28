using System;
using System.Linq;

namespace Day04
{
    public static class RandomArrays
    {
        public static int[] GetOrderedArray(int startValue, int count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(count)} cannot be less than 1.");
            }

            return Enumerable.Range(startValue, count).ToArray();
        }

        public static int[] NumbersWithDigit(byte digit, int count)
        {
            int[] array = new int[count];
            int numberWithDigit = digit;
            for (int i = 0; i < count; i++)
            {
                array[i] = numberWithDigit;
                numberWithDigit += 10;
            }

            return array;
        }

        public static void StrongShuffle(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var random = new Random();
            for (int i = array.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                Swap(ref array[i], ref array[j]);
            }
        }

        public static void FastShuffle(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var random = new Random(DateTime.Now.Millisecond);
            int periodicity = random.Next(1, 15);
            for (int i = 0, j = array.Length - 1; i < array.Length && j >= 0; i++, j -= periodicity)
            {
                Swap(ref array[i], ref array[j]);
            }
        }

        public static void Reverse(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0, j = array.Length; i < j / 2; i++)
            {
                Swap(ref array[i], ref array[j - i - 1]);
            }
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int tmp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tmp;
        }
    }
}
