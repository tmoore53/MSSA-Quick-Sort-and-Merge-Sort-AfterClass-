using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_QuickSort_and_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            //read the file into an array of integers
            //int[] nums1 = Array.ConvertAll( File.ReadAllLines("random.txt"), line => Convert.ToInt32(line));
            //int[] nums2 = Array.ConvertAll(File.ReadAllLines("random.txt"), line => Convert.ToInt32(line));
            string[] nums1 = File.ReadAllLines("randomStr.txt");
            string[] nums2 = File.ReadAllLines("randomStr.txt");

            //Console.WriteLine("starting mergesort");
            //MergeSort(nums1);
            //Console.WriteLine("starting quicksort");
            //QuickSort(nums2);

            Console.WriteLine("starting quicksort");
            QuickSort(nums1);
            Console.WriteLine("starting mergesort");
            MergeSort(nums2);
            

            //for(int i=0;i<50;i++)
            //    Console.WriteLine(nums2[i]);

            Console.WriteLine("count = {0}", nums2.Length);
        }

        //Generic methods. 
        //Use the where keyword to inheret the compare interface
        public static void MergeSort<T>(T[] arr) where T: IComparable
        {
            T[] tmp = new T[arr.Length];
            MergeSortHelper(arr, 0, arr.Length - 1, tmp);
        }

        public static void MergeSortHelper<T>(T[] arr, int startPosition, int endPosition, T[] tmp) where T : IComparable
        {
            if(endPosition-startPosition>=1) //if we have at least two elements
            {
                int middlePosition = (startPosition + endPosition) / 2;
                MergeSortHelper(arr, startPosition, middlePosition, tmp);
                MergeSortHelper(arr, middlePosition + 1, endPosition, tmp);
                Merge(arr, startPosition, middlePosition, endPosition,tmp);
            }
        }

        public static void Merge<T>(T[] arr, int startPosition, int middlePosition, int endPosition, T[] tmp) where T : IComparable
        {
            int i = startPosition;
            int j = middlePosition + 1;
            int k = i;

            

            while(i<=middlePosition && j<=endPosition)//as long as we have two elements to compare
            {
                if(arr[i].CompareTo(arr[j])<0)
                {
                    tmp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    tmp[k] = arr[j];
                    j++;
                    k++;
                }
            }


            while (i <= middlePosition)//left overs from the first part of the array
            {

                tmp[k] = arr[i];
                i++;
                k++;

            }


            while (j <= endPosition)//left overs from the second part of the array
            {

                tmp[k] = arr[j];
                j++;
                k++;

            }

            //push values back into arr
            for (k = startPosition; k <= endPosition; k++)
                arr[k] = tmp[k];
        }


        public static void QuickSort<T>(T[] arr) where T : IComparable
        {
            QuickSortHelper(arr, 0, arr.Length-1);
        }

        public static void QuickSortHelper<T>(T[] arr, int startPos, int endPos) where T : IComparable
        {
            if(endPos-startPos>=1) //only do the sort if you have at least two elements 
            {
                
                int newPivotPos = Partition(arr,startPos, endPos );
                QuickSortHelper(arr, startPos, newPivotPos-1);
                QuickSortHelper(arr, newPivotPos + 1, endPos);
            }
        }

        public static int Partition<T>(T[] arr, int startPos, int endPos) where T : IComparable
        {
            T pivot = arr[endPos];//last elements
            int j = startPos - 1; //j holds the position of the last value found that is less than pivot
            for(int i=startPos; i<=endPos-1;i++)//i takes me through all the elements
            {
                if(arr[i].CompareTo(pivot)<=0)
                {
                    j++;
                    //swap at i and j
                    T tmp2 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp2;
                }
            }

            //move the pivot in its final position
            T tmp = arr[j+1];
            arr[j + 1] = arr[endPos];
            arr[endPos] = tmp;

            return j + 1;
        }
    }

}
