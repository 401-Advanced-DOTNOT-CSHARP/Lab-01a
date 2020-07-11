using System;

namespace Lab_01a
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Console is complete");
            }
        }
        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            Console.WriteLine("Please enter a number greater than zero");
            string number = Console.ReadLine();
            try
            {
                int convertedNumber = Convert.ToInt32(number);
                if (number == "0")
                {
                    Console.WriteLine("You entered 0, read the instructions again");
                }
                else
                {
                    int[] numbersArray = new int[convertedNumber];
                    int[] finalUserNumbersArray = Populate(numbersArray);
                    int sum = GetSum(finalUserNumbersArray);
                    int product = GetProduct(finalUserNumbersArray, sum);
                    decimal quotient = GetQuotient(product);
                    Console.WriteLine($"Your Array size is: {finalUserNumbersArray.Length}");
                    string numbersOutput = "";
                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        if (i != numbersArray.Length - 1)
                        {
                            numbersOutput += $"{numbersArray[i]},";

                        }
                        else
                        {
                            numbersOutput += $"{numbersArray[i]}";

                        }
                    }
                    Console.WriteLine($"Your Array size is: {numbersOutput}");
                    Console.WriteLine($"The sum of the array is {sum}");
                    int numberChosen = product / sum;
                    Console.WriteLine($"{sum} * {numberChosen} = {product}");
                    decimal finalNumber = product / quotient;
                    Console.WriteLine($"{product} / {finalNumber} = {quotient}");



                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        static int[] Populate(int[] userNumberArray)
        {
            for (int i = 1; i <= userNumberArray.Length; i++)
            {
                Console.WriteLine(i + "/" + userNumberArray.Length);
                string newNumber = Console.ReadLine();
                int convertedNewNumber = Convert.ToInt32(newNumber);
                userNumberArray[i - 1] = convertedNewNumber;

            }
            return userNumberArray;
        }
        static int GetSum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];

            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }
        static int GetProduct(int[] array, int sum)
        {
            try
            {
                Console.WriteLine("Please pick a number between 1 and {0}", array.Length);
                string userRandomIndex = Console.ReadLine();
                int convertedUserRandomIndex = Convert.ToInt32(userRandomIndex) - 1;
                int product = array[convertedUserRandomIndex] * sum;

                return product;

            }
            catch (IndexOutOfRangeException e)
            {

                throw e;
            }
        }
        static decimal GetQuotient(int product)
        {
            Console.WriteLine("Enter a number to divide {0} by", product);
            string userDivision = Console.ReadLine();
            int convertedUserDivision = Convert.ToInt32(userDivision);
            int productDivision = convertedUserDivision / product;
            decimal quotient = decimal.Divide(product, convertedUserDivision);
            if (convertedUserDivision == 0)
            {
                throw new Exception($"You cannot divide {product} by 0, please try again");
            }
            return quotient;
        }
    }
}
