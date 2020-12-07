using System;
using System.Collections.Generic;

namespace Search_and_Sort
{
    class SearchAndSort
    {
        protected static int LineSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key) return i;
            }
            return -1;
        }
        protected static int BinarySearch(int[] arr, int key)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == key) return mid;
                else if (arr[mid] < key) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }
        protected static int LeftBinarySearch(int[] arr, int key)
        {
            int left = -1;
            int right = arr.Length - 1;
            while (left + 1 < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < key) left = mid;
                else right = mid;
            }
            if (arr[right] == key) return right;
            return -1;
        }
        protected static int RightBinarySearch(int[] arr, int key)
        {
            int left = 0;
            int right = arr.Length;
            while (left + 1 < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] <= key) left = mid;
                else right = mid;
            }
            if (arr[left] == key) return left;
            return -1;
        }
        protected static int JumpSearch(int[] arr, int key)
        {
            int B = (int)Math.Sqrt(arr.Length);
            int start = 0;
            int end = B - 1;
            while (arr[end] < key)
            {
                start += B;
                end += B;
            }
            for (int i = end; i >= start; i--)
            {
                if (arr[i] == key) return i;
            }
            return -1;
        }
        protected static int LeftJumpSearch(int[] arr, int key)
        {
            int B = (int)Math.Sqrt(arr.Length);
            int start = 0;
            int end = B - 1;
            while (arr[end] < key)
            {
                start += B;
                end += B;
            }
            for (int i = start; i <= end; i++)
            {
                if (arr[i] == key) return i;
            }
            return -1;
        }
        protected static int RightJumpSearch(int[] arr, int key)
        {
            int B = (int)Math.Sqrt(arr.Length);
            int start = 0;
            int end = B - 1;
            while (arr[end] <= key && end < arr.Length - 1 && arr[end + 1] <= key)
            {
                start += B;
                end += B;
            }
            for (int i = end; i >= start; i--)
            {
                if (arr[i] == key) return i;
            }
            return -1;
        }
        protected static void BubbleSort(int[] arr, char sumb)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                bool flag = false;
                for (int j = 1; j <= i; j++)
                {
                    if (sumb == '+')
                    {
                        if (arr[j - 1] > arr[j])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j - 1];
                            arr[j - 1] = temp;
                            flag = true;
                        }
                    }
                    else if (sumb == '-')
                    {
                        if (arr[j - 1] < arr[j])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j - 1];
                            arr[j - 1] = temp;
                            flag = true;
                        }
                    }
                }
                if (flag == false) break;
            }
        }
        protected static void ChoiseSort(int[] arr, char sumb)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int index = i;
            for (int j = 0; j < i; j++)
            {
                if (sumb == '+')
                {
                    if (arr[j] > arr[index])
                    {
                        index = j;
                    }
                }
                else if (sumb == '-')
                {
                    if (arr[j] < arr[index])
                    {
                        index = j;
                    }
                }

            }
            if (index != i)
            {
                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
        }
    }
        protected static void InsertSort(int[] arr, char sumb)
        {
            int buffer;
            for (int i = 1; i < arr.Length; i++)
            {
                buffer = arr[i];
                int j = i;
                if (sumb == '+')
                {
                    while (j > 0 && arr[j - 1] > buffer)
                    {
                        arr[j] = arr[j - 1];
                        j--;
                    }
                }
                else if (sumb == '-')
                {
                    while (j > 0 && arr[j - 1] < buffer)
                    {
                        arr[j] = arr[j - 1];
                        j--;
                    }
                }
                arr[j] = buffer;
            }
        }
        protected static void CountSort(int[] arr, char sumb)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            int[] count = new int[max+1];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = max; j >= 0; j--)
                {
                    if (arr[i] == j) count[j]++;
                }
            }
            int z = 0;
            if (sumb == '+')
            {
                for (int i = 0; i < max + 1; i++)
                {
                    for (int j = 0; j < count[i]; j++)
                    {
                        arr[z] = i;
                        z++;
                    }
                }
            }
            else if (sumb == '-')
            {
                for (int i = max; i >= 0; i--)
                {
                    for (int j = 0; j < count[i]; j++)
                    {
                        arr[z] = i;
                        z++;
                    }
                }
            }

        }
        protected static void RadixSort(int[] array, char sumb)
        {
            int digitCounts = 10; // количество различных цифр 
            int maxLengthOfNumber = 9; // максимальная длина числа
            int p = 1; // степень 10. Нужна для получения очередного разряда 

            List<int>[] pocket = new List<int>[digitCounts]; // массив для распределения элементов по "корзинам"
            for (int i = 0; i < pocket.Length; i++)
                pocket[i] = new List<int>();

            for (int i = 0; i < maxLengthOfNumber; i++) // проходимся по разрядам
            {
                for (int j = 0; j < array.Length; j++) // проходимся по числам
                {
                    int index = array[j] / p % 10; // находим индекс корзины
                    pocket[index].Add(array[j]); // добавляем
                }

                int count = 0; // на каком месте вставляем в первоначальном массиве
                if (sumb == '+')
                {
                    for (int j = 0; j < digitCounts; j++) // проходимся по корзине
                    {
                        for (int k = 0; k < pocket[j].Count; k++) // проходимся по элементам очередной корзины
                        {
                            array[count] = pocket[j][k]; // перебрасываем обратно в первоначальный массив
                            count++; // увеличиваем место вставки элемента в первоначальном массиве
                        }
                        pocket[j].Clear(); // очищаем корзину
                    }
                }
                else if (sumb == '-')
                {
                    for (int j = digitCounts - 1; j >= 0; j--) // проходимся по корзине
                    {
                        for (int k = 0; k < pocket[j].Count; k++) // проходимся по элементам очередной корзины
                        {
                            array[count] = pocket[j][k]; // перебрасываем обратно в первоначальный массив
                            count++; // увеличиваем место вставки элемента в первоначальном массиве
                        }
                        pocket[j].Clear(); // очищаем корзину
                    }
                }
                p *= 10; // получаем следующую степень
            }
        }
    }
}
