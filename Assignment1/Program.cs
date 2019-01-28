/*
    Project  : Assignment 1 – Programming Introduction
    Coded by : Alhasan
    Summary  : This C# Console application code is an individual assignment
    that focuses tightly on introductory programming structures. It includes
    different methods to do simple operations:
        1. Print Prime Numbers
        2. Get Series Result
        3. Decimal To Binary
        4. Binary To Decimal
        5. Print Triangle
        6. Compute Frequency
*/
using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Print Prime Numbers
            int startNumber = 5, endNumber = 15;
            printPrimeNumbers(startNumber, endNumber);
            // 2. Get Series Result
            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series of is: " + r1, n1);
            // 3. Decimal To Binary
            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);
            // 4. Binary To Decimal
            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);
            // 5. Print Triangle
            int n4 = 5;
            printTriangle(n4);
            // 6. Compute Frequency
            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);
            /*
                My self-reflection:
                1) Methods names and naming rule violation (The current assignment is an example of such violation)
                Methods names should start with Capital letters!
                2) The pagination and the maximum output to print each run to prevent  
                3) Using {0}, {1}, etc instead of + for concatenating varible in string
            */
            Console.ReadKey(true);
        }
        public static void printPrimeNumbers(int startNumber, int endNumber)
        {
            /*
                Summary : This method prints all the prime numbers
                between startNumber and endNumber and return nothing. 
                It takes:
                startNumber – starting range, integer (int)
                endNumber – ending range, integer (int)
                and prints:
                primeNumbers –  A string that saves the prime numbers, string (string)
                For example (5, 25) will print all the prime numbers
                between 5 and 25 i.e. 5, 7, 11, 13, 17, 19, 23
            */
            try
            {
                string primeDefinition = "A prime number is a natural number (1, 2, 3, etc.) greater than 1 and cannot\n" +
                        "be written as a product of two natural numbers that are both smaller than it.\n";
                // Display the starting and ending range
                Console.WriteLine("The starting range:\t{0}\n" +
                    "The ending range:\t{1}", startNumber, endNumber);
                // Check for negative ending range
                if (endNumber <= 1)
                {
                    Console.WriteLine("There is NO prime numbers less than or equal to {0}\n\n" +
                        "The ending range should be greater than 1 because:\n" +
                        primeDefinition, endNumber);
                }
                // Check for invalid ending range if it is less than the starting range
                else if (endNumber < startNumber)
                {
                    Console.WriteLine("Please review the ending range {1} !\n" +
                        "It should be greater than or equal to the starting range {0}\n", startNumber, endNumber);
                }
                // Check for negative starting range
                else if (startNumber < 0)
                {
                    Console.WriteLine("There is NO prime numbers less than or equal to {0}\n\n" +
                        "The starting range should be greater than 1 because:\n" +
                        primeDefinition +
                        "\nThe new starting range is 2", startNumber);
                    startNumber = 2;
                    printPrimeNumbers(startNumber, endNumber);
                }
                // Check for same number range
                else if (startNumber == endNumber)
                {
                    if (IsPrime(startNumber))
                    {
                        Console.WriteLine("\n{0} is a prime number.\n", startNumber);
                    }
                    else
                    {
                        Console.WriteLine("\n{0} is NOT a prime number.\n", startNumber);
                    }
                }
                // Else, if the range is between two different positive numbers for example 5 and 25
                else
                {
                    int count = 0; // An integer that count the prime numbers initially 0
                    string primeNumbers = "\n"; // A string that saves the prime numbers for printing \n for a new line
                    int printCount = 100; // The number of prime numbers to be printed initially 100
                    // A for loop to save the prime numbers in primeNumbers as string value for printing
                    for (int number = startNumber; number <= endNumber; number++)
                    {
                        // Using IsPrime() method to compute if a number is prime or not
                        if (IsPrime(number))
                        {
                            // Add 1 to count this prime number
                            count++;
                            if (count == 1)
                            {
                                // Print the range of the prime numbers
                                Console.WriteLine("The prime numbers between {0} and {1}:", startNumber, endNumber);
                                /* 
                                    Open { before the first prime number
                                    and add the prime number to primeNumbers as string value
                                    The first two opening braces "{{" are escaped and yield one opening brace
                                */
                                primeNumbers += (" {{" + number);
                            }
                            else
                            {
                                // Add the prime number to primeNumbers as string value
                                primeNumbers += (", " + number);
                            }
                            if (count == printCount)
                            {
                                /*
                                    Ask if the user want to print 100 prime numbers or more
                                    This prevents the program from printing too many prime numbers!
                                */
                                Console.WriteLine("There are too many prime numbers, I counted {0} primes!\n" +
                                    "Do you want to stop counting and print them?" +
                                    " Press <Enter> to stop or any key to continue", count);
                                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                {
                                    // Exit the loop and print the counted prime numbers
                                    break;
                                }
                                else
                                {
                                    // Add more 100 to the number of prime numbers to be printed
                                    printCount += 100;
                                }
                            }
                        }
                    }
                    /*
                        Close } after the last prime number and add a new line
                        The first two closing braces "}}" are escaped and yield one closing brace
                    */
                    primeNumbers += "}}\n";
                    // If there is no prime numbers, print the following
                    if (count == 0)
                    {
                        Console.WriteLine("There is NO prime numbers between {0} and {1}.\n", startNumber, endNumber);
                    }
                    // If there is only one prime number, print the following
                    else if (count == 1)
                    {
                        Console.WriteLine(primeNumbers + "Total = {0} prime number.\n", count);
                    }
                    // Print all prime numbers with the total
                    else
                    {
                        Console.WriteLine(primeNumbers + "Total = {0} prime numbers.\n", count);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()\n");
            }
        }
        public static double getSeriesResult(int terms)
        {
            /*
                Summary : This method computes the sum of series of terms and return the result
                Odd terms are all positive whereas even terms are all negative
                For example if terms = 4:
                The series is 1/2 – 2!/3 + 3!/4 – 4!/5
                Result = -3.467
                ! means factorial, i.e., 4! = 4*3*2*1 = 24.
                It takes:
                terms – number of terms of the series, integer (int)
                and returns:
                result – sum of the series, double (double)
                The result is rounded to three decimal places using AwayFromZero
                (When a number is halfway between two others, it is rounded toward the nearest
                number that is away from zero)
            */
            double result = 0; // A double number that saves the result initially 0
            try
            {
                // Check for non-positive number of terms
                if (terms <= 0)
                {
                    Console.WriteLine("The number of terms of the series must be a positive number greater than 0");
                }
                // Else, if the number of terms is positive
                else
                {
                    int maxTerms = 100; // The number of terms to be calculated initially 100
                    /*
                        A for loop that calcualtes the sum of the series
                        term – number of the current term
                    */
                    for (int term = 1; term <= terms; term++)
                    {
                        double denominator = term + 1; // denominator of the current term
                        // Cheack if the term is Even 
                        if (term % 2 == 0)
                        {
                            /*
                                Using Factorial() method to compute factorial of the current term
                                Devide the factorial by denominator
                                Subtract the value from result (Even terms are all negative)
                            */
                            result -= (Factorial(term) / denominator);
                        }
                        // Else if the term is Odd
                        else
                        {
                            /*
                                Using Factorial() method to compute factorial of term
                                Devide the factorial by denominator
                                Add the value to result (Odd terms are all positive)
                            */
                            result += (Factorial(term) / denominator);

                        }
                        if (term == maxTerms)
                        {
                            /*
                                Ask if the user want to stop and calculate 100 terms or more
                                This prevents the program from calculating too many terms!
                            */
                            Console.WriteLine("I calculated {0} terms and there are {1} terms left!\n" +
                                "Do you want to stop calculating?" +
                                " Press <Enter> to stop or any key to continue", term, (terms - term));
                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                            {
                                // If stopped, exit the loop and print the following
                                Console.WriteLine("\nOnly {0} terms have been calculated!", term);
                                break;
                            }
                            else
                            {
                                // Add more 100 to the number of terms to be calculated
                                maxTerms += 100;
                            }
                        }
                    }
                    /*
                        The result is rounded to three decimal places using AwayFromZero
                        (When a number is halfway between two others, it is rounded toward the nearest
                        number that is away from zero)
                    */
                    result = Math.Round(result, 3, MidpointRounding.AwayFromZero);
                }
                // Return the result
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }
            return result;
        }
        public static long decimalToBinary(long decimalNumber)
        {
            /*
                Summary : This method converts a number from decimal (base 10) to binary (base 2).
                It takes:
                decimalNumber – non-negative number (base 10) to be converted, integer (long)
                and returns:
                binaryNumber – binary (base 2), integer (long)
                A number can be converted from decimal to binary in the following steps:
                1) Divide it by 2.
                2) Get the integer quotient for next iteration.
                3) Get the remainder for binary digit.
                4) Repeat the steps until the quotient is equal to 0.
                For example, binary conversion for 13 is 1101
            */
            long binaryNumber = 0; // the binary value initially 0
            try
            {
                // Check for negative decimalNumber
                if (decimalNumber < 0)
                {
                    Console.WriteLine("This method converts only a NON-negative number from decimal (base 10) " +
                        "to binary (base 2).");
                }
                else
                {
                    /* 
                        Using Remainders() method to return all remainders for binary digits 
                        for example Remainders(13) returns "1011" and need to be reversed
                        1) Save the remainders as a string in binaryString
                    */
                    string binaryString = Remainders(decimalNumber);
                    /*
                        2) Convert binaryString to CharArray to reverse the order of reminders
                        easily using Array.Reverse()
                    */
                    char[] binaryArray = binaryString.ToCharArray();
                    Array.Reverse(binaryArray);
                    //  3) Save the reversed remainders as a string again in binaryString e.g. "1101"
                    binaryString = new string(binaryArray);
                    /* 
                        4) Try to convert binaryString to long and save it in binaryNumber for return

                        Important note: my method is able to convert the maximum positive
                        (long) number 9223372036854775807
                        to 111111111111111111111111111111111111111111111111111111111111111
                        but we were asked to return (long) value and the value of binaryNumber
                        is beyond the valid Range of (long)
                    */
                    try
                    {
                        binaryNumber = long.Parse(binaryString);
                    }
                    catch
                    {
                        // If long is not enough print the following
                        Console.WriteLine("Return 0, because the value of binaryNumber is beyond the valid Range of (long)");
                        Console.WriteLine("Binary conversion of the decimal number {0} is: {1}\n", decimalNumber, binaryString);
                    }
                }
                // Return the binary
                return binaryNumber;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }
            return binaryNumber;
        }
        public static long binaryToDecimal(long binaryNumber)
        {
            /*
                Summary : This method converts a number from binary (base 2) to decimal (base 10).
                It takes:
                binaryNumber – binary (base 2), integer (long)
                and returns:
                decimalNumber – non-negative number (base 10) to be converted, integer (long)
                A number can be converted from binary to decimal in the following steps:
                1) Start from the rightmost bit to the left.
                2) Multiply each bit by 2^i where i starts from 0 and increases by 1 on iteration.
                3) Add all the computations for the result.
                For example, binary conversion for 1101 is 13
            */
            long decimalNumber = 0; // the decimal value initially 0
            try
            {
                // Check for negative binaryNumber
                if (binaryNumber < 0)
                {
                    Console.WriteLine("This method converts only a NON-negative number from binary (base 2) " +
                        "to decimal (base 10)");
                }
                else
                {
                    /*
                        2) Convert binaryNumber to binaryString and then to CharArray
                        to reverse the order of binary digits easily using Array.Reverse()
                    */
                    string binaryString = binaryNumber.ToString();
                    char[] binaryArray = binaryString.ToCharArray();
                    Array.Reverse(binaryArray);
                    /*
                        A for loop that:
                        1) Since reversed the binary digits we start from the leftmost bit to the right.
                        2) Multiply each digits by 2^i where i starts from 0 and increases by 1 on iteration
                        until the last digits which is less than binaryArray.Length
                        3) Add all the computations for the result.
                    */
                    for (long digitNumber = 0; digitNumber < binaryArray.Length; digitNumber++)
                    {
                        int digit = (int)Char.GetNumericValue(binaryArray[digitNumber]);
                        long digitTimesPowerOfI = digit * (long)Math.Pow(2, digitNumber);
                        decimalNumber += digitTimesPowerOfI;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }
            // Return the decimal
            return decimalNumber;
        }
        public static void printTriangle(int lines, int maxLines = 50)
        {
            /*
                Summary : This method prints a triangle using asterisk (*) and return nothing
                It takes:
                lines – number of lines for the pattern, integer (int)
                maxLines – number of maximum lines for the pattern, integer (int), default = 50
                and prints:
                For example lines = 5 will display the output as: 
                    *
                   ***
                  *****
                 *******
                *********
            */
            try
            {
                // Check if number of lines less than 2, a triangle using asterisk needs at least 2 lines
                if (lines < 2)
                {
                    Console.WriteLine("A triangle using asterisk needs at least 2 lines\n" +
                        "The number of lines for the pattern must be a positive number greater than 1");
                }
                // Check if number of lines greater than maxLines to prevent bad layout or style
                else if (lines > maxLines)
                {
                    Console.WriteLine("This would be a big triangle with {0} lines\n" +
                        "Do you want to print a smaller one with {1} lines to maintain the style?\n" +
                        "Press <Enter> print the smaller one or " +
                        "any key to increase the number of lines by 1 at your own risk!", lines, maxLines);
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        // To print the smaller triangle with the current agreed number of lines
                        printTriangle(maxLines, maxLines);
                    }
                    else
                    {
                        // To increase the maxLines by 1
                        printTriangle(lines, maxLines += 1);
                    }
                }
                else
                {
                    /*
                        A for loop that print for every line
                        1) spaces = (Lines+1) - current line
                        For example if lines = 2
                        space+space
                        space
                        2) asterisks = (2 * current line) - 1
                        For example if lines = 2
                        asterisk
                        asterisk+asterisk+asterisk
                        3) Print a new line
                    */
                    for (int line = 1; line <= lines; line++)
                    {
                        // 1) spaces = (Lines + 1) - current line
                        for (int spaces = line; spaces <= lines; spaces++)
                        {
                            Console.Write(" ");
                        }
                        // 2) asterisks = (2 * current line) - 1
                        for (int asterisks = 1; asterisks <= ((2 * line) - 1); asterisks++)
                        {
                            Console.Write("*");
                        }
                        // 3) Print a new line
                        Console.WriteLine();
                        
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }
        public static void computeFrequency(int[] array)
        {
            /*
                Summary : This method computes the frequency of each element in the array
                and return nothing. 
                It takes:
                array – array of elements, integer (int)
                and prints:
                Number – An element in the array
                Frequency  – the number of occurrences of that Number
                For example a = {1,2,3,2,2,1,3,2} will display the output as:
                Number	    Frequency
                1           2
                2           4
                3           2
            */
            try
            {
                // Check if the array is empty
                if (array.Length == 0)
                {
                    Console.WriteLine("This is an empty array!");
                }
                // Else, if not empty, print the frequency of each element in the array
                else
                {
                    // Print the header with 2 taps to maintain the style with big integers such as 2147483647
                    Console.WriteLine("Number\t\tFrequency");
                    // Sort the array to easily compute the frequency  
                    Array.Sort(array);
                    /*
                        A for loop that prints the frequency of each element in the array
                    */
                    for (int element = 0; element < array.Length; element++)
                    {
                        int number = array[element]; // An integer to save the element value
                        int frequency = 0; // An integer to save the frequency value
                        /*
                            A for loop that:
                            1) Starts from the current position of element i to count
                            2) Continues to count as long as the next element is equivalent
                            3) Save the position i of the last equivalent element to start from the next one
                            4) Stop if it reaches the last element
                        */
                        for (int i = element; i < array.Length && array[i] == array[element]; i++)
                        {
                            frequency++;
                            element = i;
                        }
                        // Print the number with more than 7 digits with one taps to maintain the style
                        if (number > 9999999)
                        {
                            Console.WriteLine(number + "\t" + frequency);
                        }
                        // Else, print the number with two taps to maintain the style
                        else
                        {
                            Console.WriteLine(number + "\t\t" + frequency);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
        private static bool IsPrime(int number)
        {
            /*
                Summary : This method checks the primality of a given number
                and return true if prime or false if not
                A prime number is a natural number (1, 2, 3, etc.) greater
                than 1 and cannot be written as a product of two natural numbers
                that are both smaller than it.
                A simple method of checking the primality of a given number is
                called trial division, tests whether the number is a multiple of any integer
                between 2 and the square root of the number
            */
            bool primality = true; // A boolean that save the test resutl the number is prime
            // By definition, any number less than or equal 1 is not prime
            if (number <= 1)
            {
                return primality = false;
            }
            // Applying the trial division method of checking the primality
            else
            {
                /*
                    Tests whether the number is a multiple of any integer (divisor)
                    between 2 and the square root of the number
                */
                for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
                {
                    // If the number is a multiple of divisor, then it is not is not prime
                    if (number % divisor == 0)
                    {
                        return primality = false;
                    }
                }
            }
            /* 
                Return true, if the number is not a multiple of any integer
                between 2 and the square root of the number
            */
            return primality;
        }
        private static int Factorial(int number)
        {
            /*
                Summary : This method computes the factorial of a number
                and return the factorial
                The factorial of number, denoted by number!,
                is the product of all positive integers less than or equal to that number
                for example 4! = 4*3*2*1 = 24
            */
            int factorial = 1; // An integer that saves the result, initially 1 the minimum positive integers
            // A for loop that sums the product of all positive integers less than or equal to that number
            for (int integer = number; integer >= 1; integer--)
            {
                // Multiply the value by integer and add it to the sum
                factorial *= integer;
            }
            // Return the factorial
            return factorial;
        }
        private static string Remainders(long number)
        {
            /*
                Summary : This method returns all remainders for binary digits
                It is a recursion method that stops if the if the quotient is equal to 0
            */
            string remainders = ""; // A string that saves all remainders for binary digits
            long quotient = number / 2; // The Quotient result of dividing the number by 2
            long remainder = number % 2; // Get the remainder for the binary digit.
            // Stop if the quotient is equal to 0.
            if (quotient < 1)
            {
                // ToString() converts the numeric value to string
                return remainders = remainder.ToString();
            }
            // Use the quotient for the next iteration until the quotient is equal to 0.
            return remainders = remainder.ToString() + Remainders(quotient);
        }
    }
}
