using System;
using System.Collections.Generic;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(solution("rather", "harder"));
            Console.WriteLine(solution("apple", "pear"));
            Console.WriteLine(solution("lemon", "melon"));
            Console.WriteLine(solution("zpoıwaaa", "bqqbbz"));
            */

            Console.WriteLine(solution1("011100"));



            /*
            Console.WriteLine(solution3(3, new int[] { 0}));  
            Console.WriteLine(solution3(3, new int[] { 0,1,2,3 }));
            Console.WriteLine(solution3(3, new int[] { 0, 1, 2, 3,1 }));
            Console.WriteLine(solution3(3, new int[] { 0, 1, 2, 3,1,2 }));
            Console.WriteLine(solution3(3, new int[] { 0, 1, 2, 3, 1, 2, 1 }));
            Console.WriteLine(solution3(3, new int[] { 0, 1, 2, 3, 1, 2, 1,1, 2 }));
            Console.WriteLine(solution3(3, new int[] { 0, 1, 2, 3, 1, 2, 1, 2, 3 }));
            Console.WriteLine(solution3(3, new int[] { 0, 1, 2, 3, 1, 2, 1, 2, 3 ,0,0}));
            Console.WriteLine();

            Console.WriteLine(solution3(1, new int[] { 0 }));
            Console.WriteLine(solution3(1, new int[] { 0, 1,0,0,0,0,1,1,1,1,1,1 }));
            */



            /*

            var A = new int[] { 1, 0, 0, 1, 1 };

            solution2(A);

    */
            Console.ReadLine();
        }

        public static int[] solution2(int[] A)
        {
            var decimalValue = 0;
            for (int i = 0; i < A.Length; i++)
            {
                decimalValue += A[i] * (int)Math.Pow(-2, i);
            }
            decimalValue = (int)Math.Ceiling((double)decimalValue / 2);
            Console.WriteLine(decimalValue);


            string result = "";
            while (decimalValue > 1)
            {
                int remainder = decimalValue % 2;
                result = Convert.ToString(remainder) + result;
                decimalValue /= 2;
            }
            result = Convert.ToString(decimalValue) + result;
            Console.WriteLine("Binary: {0}", result);

            return new int[] { 0, 1 };
        }





        public static int solution3(int M, int[] A)
        {
            int N = A.Length;
            int[] count = new int[M + 1];

            for (int i = 0; i <= M; i++)
                count[i] = 1;

            int maxOccurence = 0;
            int index = -1;
            for (int i = 0; i < N; i++)
            {
                if (count[A[i]] > 0)
                {
                    int tmp = count[A[i]];
                    if (tmp > maxOccurence)
                    {
                        maxOccurence = tmp - 1;
                        index = i;
                    }
                    count[A[i]] = tmp + 1;
                }
                else
                {
                    count[A[i]] = 1;
                }
            }
            return A[index];
        }


        public static int solution1(string S)
        {
            var decimalValue = Convert.ToInt32(S, 2);
            Console.WriteLine(decimalValue);
            decimalValue = 9;
            return FindScore(decimalValue);
        }
        public static int FindScore(int value)
        {
            if (value == 0)
            {
                return 0;
            }
            if (value % 2 == 1)
            {
                return FindScore(value - 1) + 1;
            }
            else
            {
                return FindScore(value / 2) + 1;
            }
        }

        public static int solution(string A, string B)
        {

            var listOne = new Dictionary<char, int>();
            foreach (var chr in A)
            {
                if (listOne.ContainsKey(chr))
                {
                    listOne[chr]++;
                }
                else
                {
                    listOne.Add(chr, 1);
                }
            }
            var listTwo = new Dictionary<char, int>();
            foreach (var chr in B)
            {
                if (listTwo.ContainsKey(chr))
                {
                    listTwo[chr]++;
                }
                else
                {
                    listTwo.Add(chr, 1);
                }
            }

            var finalScore = 0;
            foreach (var letter in listOne)
            {
                if (listTwo.ContainsKey(letter.Key))
                {
                    finalScore += Math.Abs(listOne[letter.Key] - listTwo[letter.Key]);
                }
                else
                {
                    finalScore += listOne[letter.Key];
                }
            }
            foreach (var letter in listTwo)
            {
                if (!listOne.ContainsKey(letter.Key))
                {
                    finalScore += listTwo[letter.Key];
                }
            }
            return finalScore;
        }
    }
}
