using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestForLog4Net.TestClasses.ArrySort
{
    /*
     * .net framework 中的排序是由 quick sort 和 heap sort 混用排序。
     * 先进行 quick sort 对 quick sort 设置层深。超过层深还没完成排序的部分用 heap sort 继续排序。
     * quick sort: 长于对数据十分分散，重复值不多的数列进行排序。
     * heap sort: 与 quick sort 的长处相反，擅于处理重复值多的数列。
     */
    public class ArrySortClass
    {
        private Random RandomSeed;

        private int quickDepth;

        public void SortAsc(List<int> list)
        {
            QuickSort(list, 0, list.Count - 1);
        }

        public void SortAsc(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] list, int low, int high)
        {
            int tmp;
            if (low < high)
            {
                int pivotIndex = low;
                int pivot = list[low];
                int moveIndex = low + 1;

                while (moveIndex < high + 1)
                {
                    if (list[moveIndex] < pivot)
                    {
                        pivotIndex++;
                        tmp = list[moveIndex];
                        list[moveIndex] = list[pivotIndex];
                        list[pivotIndex] = tmp;

                        list[pivotIndex - 1] = list[pivotIndex];
                        list[pivotIndex] = pivot;
                    }
                    moveIndex++;
                }
                QuickSort(list, low, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, high);
            }
        }

        private void QuickSort(List<int> list, int low, int high)
        {
            int tmp;
            if (low < high)
            {
                int pivotIndex = low;
                int pivot = list[low];
                int moveIndex = low + 1;

                while (moveIndex < high + 1)
                {
                    if (list[moveIndex] < pivot)
                    {
                        pivotIndex++;
                        tmp = list[moveIndex];
                        list[moveIndex] = list[pivotIndex];
                        list[pivotIndex] = tmp;

                        list[pivotIndex - 1] = list[pivotIndex];
                        list[pivotIndex] = pivot;
                    }
                    moveIndex++;
                }
                QuickSort(list, low, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, high);
            }
        }

        public void HeapSort(int[] array)
        {
            #region
            //int LastNotLeafNode;
            //int MaxLength = array.Length;

            //LastNotLeafNode = MaxLength / 2 - 1;
            //while (LastNotLeafNode >= 0)
            //{
            //    AdjustNode(array, LastNotLeafNode, MaxLength, 0);
            //    LastNotLeafNode--;
            //}

            //while (MaxLength > 0)
            //{
            //    Swap(array, 0, MaxLength - 1);
            //    MaxLength--;
            //    AdjustNode(array, 0, MaxLength, 0);
            //}
            #endregion

            HeapSort(array, 0, array.Length - 1);
        }

        public void MixQuickHeapSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1, quickDepth);
        }

        private void QuickSort(int[] list, int low, int high, int depth)
        {
            int tmp;
            if (low < high)
            {
                if (depth < 1)
                {
                    HeapSort(list, low, high);
                    return;
                }

                int pivotIndex = low;
                int pivot = list[low];
                int moveIndex = low + 1;

                while (moveIndex < high + 1)
                {
                    if (list[moveIndex] < pivot)
                    {
                        pivotIndex++;
                        tmp = list[moveIndex];
                        list[moveIndex] = list[pivotIndex];
                        list[pivotIndex] = tmp;

                        list[pivotIndex - 1] = list[pivotIndex];
                        list[pivotIndex] = pivot;
                    }
                    moveIndex++;
                }
                QuickSort(list, low, pivotIndex - 1, depth - 1);
                QuickSort(list, pivotIndex + 1, high, depth - 1);
            }
        }

        private void HeapSort(int[] list, int low, int high)
        {
            int LastNotLeafNode;
            int MaxLength = high - low + 1;

            LastNotLeafNode = MaxLength / 2 - 1;
            while (LastNotLeafNode >= 0)
            {
                AdjustNode(list, LastNotLeafNode, MaxLength, low);
                LastNotLeafNode--;
            }

            while (MaxLength > 0)
            {
                Swap(list, 0 + low, MaxLength - 1 + low);
                MaxLength--;
                AdjustNode(list, 0, MaxLength, low);
            }
        }

        private void AdjustNode(int[] array, int pNodeIndex, int MaxLength, int beginNode)
        {
            int curPIndex = pNodeIndex;
            int lChild = curPIndex * 2 + 1;

            while (lChild < MaxLength)
            {
                if ((lChild + 1) < (MaxLength) && array[lChild + beginNode] < array[lChild + 1 + beginNode])
                {
                    lChild++;

                }
                if (array[curPIndex + beginNode] < array[lChild + beginNode])
                {
                    Swap(array, curPIndex + beginNode, lChild + beginNode);
                    curPIndex = lChild;
                }
                else
                {
                    break;
                }
                lChild = curPIndex * 2 + 1;
            }
        }

        private void Swap(int[] array, int indexA, int indexB)
        {
            int tmp;
            tmp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = tmp;
        }

        public List<int> SortAscJunior(List<int> list)
        {
            int pivot;
            List<int> result, smallers, greaters;

            if (list.Count < 2)
            {
                result = list;
            }
            else
            {
                smallers = new List<int>();
                greaters = new List<int>();
                result = new List<int>();

                pivot = list[0];

                foreach (int itm in list.Skip(1))
                {
                    if (itm <= pivot)
                        smallers.Add(itm);
                    else
                        greaters.Add(itm);
                }

                result.AddRange(SortAscJunior(smallers));
                result.Add(pivot);
                result.AddRange(SortAscJunior(greaters));
            }
            return result;
        }
        public ArrySortClass()
        {
            RandomSeed = new Random((int)DateTime.Now.Ticks);
            quickDepth = 64;
        }

        public int GetRandomeInt(int min, int max)
        {
            return
                RandomSeed.Next(min, max);
        }

        public void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public bool IsSorted(int[] array)
        {
            bool Result = true;
            for (int i = 1; i < array.Length; i++)
            {
                Result = Result && (array[i] >= array[i - 1]);
            }
            return Result;
        }
    }
}
