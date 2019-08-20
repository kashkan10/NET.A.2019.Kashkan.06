using System;
using System.Linq;

namespace JaggedBubbleSort
{
    public static class BubbleSort
    {
        /// <summary>
        /// Call for method of sorting sum of elements ascending
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        public static void SumOfSortAsc(this int[][] arr)
        {
            ExceptionCheck(arr);
            SortAscending(arr, SumOfSort);
        }

        /// <summary>
        /// Call for method of sorting sum of elements descending
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        public static void SumOfSortDesc(this int[][] arr)
        {
            ExceptionCheck(arr);
            SortDescending(arr, SumOfSort);
        }

        /// <summary>
        /// Call for method of sorting max elements ascending
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        public static void MaxOfSortAsc(this int[][] arr)
        {
            ExceptionCheck(arr);
            SortAscending(arr, MaxOfSort);
        }

        /// <summary>
        /// Call for method of sorting max elements descending
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        public static void MaxOfSortDesc(this int[][] arr)
        {
            ExceptionCheck(arr);
            SortDescending(arr, MaxOfSort);
        }

        /// <summary>
        /// Call for method of sorting min elements ascending
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        public static void MinOfSortAsc(this int[][] arr)
        {
            ExceptionCheck(arr);
            SortAscending(arr, MinOfSort);
        }

        /// <summary>
        /// Call for method of sorting min elements descending
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        public static void MinOfSortDesc(this int[][] arr)
        {
            ExceptionCheck(arr);
            SortDescending(arr, MinOfSort);
        }

        #region logic
        /// <summary>
        /// Bubble sort of jagged array in ascending order with given criterion
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        /// <param name="deleg">Sorting criterion</param>
        private static void SortAscending(int[][] arr, Func<int[], int> deleg)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (deleg(arr[i]) > deleg(arr[j]))
                    {
                        int[] swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
        }

        /// <summary>
        /// Bubble sort of jagged array in descending order with given criterion
        /// </summary>
        /// <param name="arr">Source jagged array</param>
        /// <param name="deleg">Sorting criterion</param>
        private static void SortDescending(int[][] arr, Func<int[], int> deleg)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (deleg(arr[i]) < deleg(arr[j]))
                    {
                        int[] swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
        }

        /// <summary>
        /// Sum of the elements in array
        /// </summary>
        /// <param name="arr">Source sz-array</param>
        /// <returns>Sum</returns>
        private static int SumOfSort(int[] arr)
        {
            return arr.Sum();
        }

        /// <summary>
        /// Max element of array
        /// </summary>
        /// <param name="arr">Source sz-array</param>
        /// <returns>Max element</returns>
        private static int MaxOfSort(int[] arr)
        {
            return arr.Max();
        }

        /// <summary>
        /// Min element of array
        /// </summary>
        /// <param name="arr">Source sz-array</param>
        /// <returns>Min element</returns>
        private static int MinOfSort(int[] arr)
        {
            return arr.Min();
        }

        /// <summary>
        /// Check array for exceptions
        /// </summary>
        /// <param name="arr">Jagged array</param>
        private static void ExceptionCheck(int[][] arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException();
            }
            if(arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }
        }
        #endregion
    }
}
