// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NumberGenerator
{
    using System;

    // [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "<reviewed>")]
    public class Program
    {
        private static void Main(string[] args)
        {
            int maxValue = 0;
            int minValue = 0;
            int numberOfElements = 0;
            try
            {
                Console.WriteLine("Enter the number of elements for the array: ");
                while (true)
                {
                    numberOfElements = Convert.ToInt32(Console.ReadLine());
                    if (numberOfElements < 2)
                    {
                        Console.WriteLine("Enter a number greater than one");
                        continue;
                    }

                    Console.WriteLine("Enter the Minimum value");
                    minValue = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Maximum value");
                    maxValue = Convert.ToInt32(Console.ReadLine());
                    if (maxValue <= minValue)
                    {
                        Console.WriteLine("Enter a value greater than Minimum value");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int[] array = GenerateValues(minValue, maxValue, numberOfElements);
            Console.WriteLine($"elements of the Arrry:");

            foreach (int element in array)
            {
                Console.WriteLine(element);
            }

            int result = (maxValue - minValue) / 2;
            int greaterValue = GetGreaterValue(array, maxValue, minValue);
            Console.WriteLine($"Number of elements that are greater than {result} are {greaterValue}\n");

            int[] greaterThanArray = GetArrayOfGreaterValue(array, maxValue, minValue);
            Console.WriteLine($"Elements in the array greater than {result}: ");
            foreach (var value in greaterThanArray)
            {
                Console.WriteLine(value);
            }

            int[] sort = SortArray(greaterThanArray, maxValue, minValue);
            Console.WriteLine($"Elements in an ascending order: ");
            foreach (var value in sort)
            {
                Console.WriteLine(value);
            }
        }

        // generate the array on int values
        private static int[] GenerateValues(int minValue, int maxValue, int numberOfElements)
        {
            Random random = new Random();
            int[] array = new int[numberOfElements];
            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }

            return array;
        }

        // generate the number of values in the array which fit array[i]>(max-min)/2
        private static int GetGreaterValue(int[] array, int maxValue, int minValue)
        {
            int count = 0;
            int result = (maxValue - minValue) / 2;
            foreach (int element in array)
            {
                if (element > result)
                {
                    count++;
                }
            }

            return count;
        }

        // generate  the array which fit array[i]>(max-min)/2
        private static int[] GetArrayOfGreaterValue(int[] array, int minValue, int maxValue)
        {
            int size = GetGreaterValue(array, maxValue, minValue);
            int[] getArray = new int[size];
            int result = (maxValue - minValue) / 2;
            int p = 0;
            for (int z = 0; z < 5; z++)
            {
                if (array[z] > result)
                {
                    getArray[p] = array[z];
                    p++;
                }
            }

            return getArray;
        }

        private static int[] SortArray(int[] numArray, int maxValue, int minValue)
        {
            int n = GetGreaterValue(numArray, maxValue, minValue);

            // int[] numArray = new int[n];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (numArray[j] > numArray[j + 1])
                    {
                        var tempVar = numArray[j];
                        numArray[j] = numArray[j + 1];
                        numArray[j + 1] = tempVar;
                    }
                }
            }

            return numArray;
        }
    }
}
