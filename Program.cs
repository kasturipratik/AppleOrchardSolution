using System;

namespace MandT_bank_exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] A = { 6, 1, 4, 6, 3, 2, 7, 4 };
            int[] B = { 1, 2, 3, 4, 5 };
            int[] C = { 10, 19, 15 };
            int[] D = { 1, 10, 500, 6, 16, 18, 12, 10, 15, 10, 1, 15, 12 };
            Console.WriteLine("Expected total apples collected = 24" +" || Actutal collected applese = " +GetTotalApplesCollected(A, 3, 2));
            Console.WriteLine("Expected total apples collected = 15" + " || Actutal collected applese = " + GetTotalApplesCollected(B, 3, 2));
            Console.WriteLine("Expected total apples collected = -1 (not possible to collect)" + " || Actutal collected apple = " + GetTotalApplesCollected(C, 2, 2));
            Console.WriteLine("Expected total apples collected = 579 " + " || Actutal collected apple = " + GetTotalApplesCollected(D, 5, 2));
        }

        private static int GetTotalApplesCollected(int[] A, int K, int L)
        {
            return (K + L > A.Length) ? -1 : ComputeTotalAppleCollectionPosible(A, K, L);
            
        }

        private static int ComputeTotalAppleCollectionPosible(int[] A, int K, int L)
        {
            int[] sumOfApples = new int[1000];
            sumOfApples[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                sumOfApples[i] = sumOfApples[i - 1] + A[i];
            }
            int totalApplesCollected = -1;
            
            for (int a = 0; a + K - 1 < A.Length; a++)
            {
                int KCount = (a > 0) ? getCountIfTreeHasApples(sumOfApples, a, K) : getCountIfTreeHasNoApples(sumOfApples, a, K);

                for (int b = a + K; b + L - 1 < A.Length; b++)
                {
                    int LCount = (b > 0) ? getCountIfTreeHasApples(sumOfApples, b, L) : getCountIfTreeHasNoApples(sumOfApples, b, L);

                    totalApplesCollected = (KCount + LCount > totalApplesCollected) ? KCount + LCount : totalApplesCollected;

                }
            }
            return totalApplesCollected;
        }

        private static int getCountIfTreeHasApples(int[] treeLists, int individualTree, int individualCount)
        {
            return treeLists[individualTree + individualCount - 1] - treeLists[individualTree - 1];
        }

        private static int getCountIfTreeHasNoApples(int[] treeLists, int individualTree, int individualCount)
        {
            return treeLists[individualTree + individualCount - 1];
        }
    }
}

