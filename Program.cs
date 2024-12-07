using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Day05
{
    internal class Program
    {
        // problem 2
        public static void TestDefensiveCode()
        {
            int X, Y, Z;
            do
            {
                Console.WriteLine("enter a positive integer for X: ");
            } while (!int.TryParse(Console.ReadLine(), out X) || X <= 0);

            do
            {
                Console.WriteLine("enter a positive integer for Y is greater than 1: ");
            } while (!int.TryParse(Console.ReadLine(), out Y) || Y <= 0);

            try
            {
                Z = X / Y;
                Console.WriteLine($"the result of dividing {X} by {Y} is {Z}");

                int[] arr = { 1, 2, 3, 4 };
                if (arr?.Length > 108)
                {
                    arr[108] = 78;
                    Console.WriteLine("Value assigned to array at index 108");
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("ERROR : cannot divide by zero");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Array index out of range.");
            }
            finally 
            {
                Console.WriteLine("program Complete");
            }
        }

        // problem 9
        public static void SumAndMultiply(int x, int y, out int sum, out int product)
        {
            sum = x + y;
            product = x * y;
        }

        // problem 10
        public static void PrintRepeated(string text, int times = 5)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(text);
            }
        }

        // problem 13
        public static int SumArray(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }



        static void Main(string[] args)
        {
            #region problem1
            try
            {
                Console.WriteLine("please enter the number");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("please enter the number");
                int num2 = int.Parse(Console.ReadLine());

                int result = num1 / num2;

                Console.WriteLine($"the result is {result}");

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine(" ERROR  : cannot divided by zero  ");
            }
            finally 
            {
                Console.WriteLine("program complete");
            }


            // source >> W3 schools
            // The finally statement lets you execute code, after try...catch, regardless of the result
            #endregion

            #region problem2
            TestDefensiveCode();
            #endregion

            #region problem3

            int? number1 = null;

            int number2 = number1 ?? 0;

            if (number1.HasValue)
            {
                number2 = number1.Value;
            }
            else 
            {
                Console.WriteLine("Nullabe int is Null");
            }

            // Question: What exception occurs when trying to access Value on a null Nullable<T>?
            // InvalidOperationException is occur
            #endregion

            #region problem4

            int[] arr = { 1, 2, 3, 4, 5 };

            try
            {
                Console.WriteLine(arr[10]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("ERROR : index out of range");
            }

            // Question: Why is it necessary to check array bounds before accessing elements?
            //To prevent IndexOutOfRangeException exceptions, which may cause the program to crash.

            #endregion

            #region problem5
            int[,] arr2 = new int[3 , 3];

            for (int i = 0; i < arr2.Length; i++)
            { 
            
                for (int j = 0; j < arr2.Length; j++)
                {
                    Console.WriteLine($"enter the elements of Array : [{i} , {j}] ");
                    arr2[i , j] = int.Parse (Console.ReadLine());

                }
            
            }

            for (int i = 0; i < arr2.Length; i++) 
            { 
                int RowSum = 0; 
                int ColSum = 0;

                for (int j = 0; j < arr2.Length; j++) 
                {
                    
                    RowSum += arr2[i , j];
                    ColSum += arr2[i , j];
                
                }
                Console.WriteLine($"RowSum is : {RowSum} ");
                Console.WriteLine($"ColumnSum is : {ColSum} ");

            }

            // Question: How is the GetLength(dimension) method used in multi-dimensional arrays?
            // Used to specify the size of a particular dimension in the matrix. For example, GetLength(0) gives the number of rows.
            #endregion

            #region problem6
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[2];

            for (int i = 0; i < jaggedArray.Length;i++)
            {
                Console.WriteLine($"enter the value of Row {i + 1} ");
                for (int j = 0; j < jaggedArray.Length; j++)
                {
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("All elements of Array");
            for (int i = 0;i < jaggedArray.Length;i++)
            {
                Console.Write($"Row {i + 1}: ");
                for(int j = 0;  j < jaggedArray.Length;j++)
                {
                    Console.WriteLine(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            #endregion

            #region problem7
            string? nullableString = null;

            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            nullableString = string.IsNullOrEmpty(input) ? null : input;

            Console.WriteLine(nullableString!);


            // What is the purpose of nullable reference types in C#?
            // to Improved security against errors caused by null values.

            #endregion

            #region problem8
            int value = 42; // Value type
            object boxedValue = value; // Boxing
            Console.WriteLine($"Boxed value: {boxedValue}");

            try
            {
                int unboxedValue = (int)boxedValue; // Unboxing
                Console.WriteLine($"Unboxed value: {unboxedValue}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //Question: What is the performance impact of boxing and unboxing in C#?
            // Boxing: Transfers the value to the heap, which increases memory consumption.
            // Unboxing: It takes extra time to check the type before returning the value.

            #endregion

            #region problem9
            SumAndMultiply(5, 3, out int sum, out int product);
            Console.WriteLine($"Sum: {sum}, Product: {product}");

            // Question: Why must out parameters be initialized inside the method?
            // Because variables sent using out do not have a default value and must be assigned a value before they can be used.

            #endregion

            #region problem10
            PrintRepeated("Khalid", 3); 
            PrintRepeated("Abowarda");

            // Why must optional parameters always appear at the end of a method's parameter list ?
            // To prevent confusion when calling the function, where optional parameters depend on a clear order in the call

            #endregion

            #region problem11

            int?[] nullableArray = null;

            Console.WriteLine($"Array length: {nullableArray?.Length ?? 0}");

            //Question: How does the null propagation operator prevent NullReferenceException?
            // ?. It first checks that the object is not null before trying to access a property or function.



            #endregion

            #region problem12

            Console.Write("Enter a day of the week: "); string day = Console.ReadLine(); int dayNumber = day switch
            {
                "Monday" => 1,
                "Tuesday" => 2,
                "Wednesday" => 3,
                "Thursday" => 4,
                "Friday" => 5,
                "Saturday" => 6,
                "Sunday" => 7,
                _ => 0
            };

            if (dayNumber == 0)
            { 
                Console.WriteLine("Invalid day of the week.");

            } 
            else 
            {
                Console.WriteLine($"The number for {day} is {dayNumber}.");
            }


            // Question: When is a switch expression preferred over a traditional if statement ?
            //-->> When there is a direct map between input and output, because it is simpler and less error-free than using if.




            #endregion

            #region problem 13
            int sum1 = SumArray(1, 2, 3);
            int sum2 = SumArray(new int[] { 4, 5, 6 });

            Console.WriteLine($"Sum1: {sum1}, Sum2: {sum2}");

            // Question: What are the limitations of the params keyword in method definitions?
            // -->> A function can only take one parameter.
            // -->> It must be the last parameter in the list.

            #endregion

            // Part 02

            #region Part02
            // >> 1 Program to Print Numbers in a Range

            Console.Write("Enter a positive number: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + (i < n ? ", " : ""));
            }


            // >> 2 Program to Display Multiplication Table

            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
            }



            // >> 3 Program to List Even Numbers

            Console.Write("Enter a number: ");
            int EvenNum = int.Parse(Console.ReadLine());

            for (int i = 2; i <= EvenNum; i += 2)
            {
                Console.Write(i + (i < EvenNum ? ", " : ""));
            }


            // >> 4 Program to Compute Exponentiation

            Console.Write("Enter the base: ");
            int baseNum = int.Parse(Console.ReadLine());
            Console.Write("Enter the exponent: ");
            int exp = int.Parse(Console.ReadLine());

            Console.WriteLine($"{baseNum}^{exp} = {Math.Pow(baseNum, exp)}");


            // >> 5 Program to Reverse a Text String

            Console.Write("Enter a String: ");
            string Str = Console.ReadLine();

            char[] reversed = Str.ToCharArray();
            Array.Reverse(reversed);

            Console.WriteLine(new string(reversed));




            // >> 6 Program to Reverse an Integer Value

            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int RevercedNum = 0;
            while (number > 0)
            {
                RevercedNum = RevercedNum * 10 + number % 10;
                number /= 10;
            }

            Console.WriteLine($"Reversed: {RevercedNum}");


            // >> 7 Program to Find Longest Distance Between Matching Elements

            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            string[] words = sentence.Split(' ');
            Array.Reverse(words);

            Console.WriteLine(string.Join(" ", words));


            // >> 8 cant solve this problem 

            #endregion
















        }
    }
}
