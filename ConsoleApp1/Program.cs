using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool correctInput = false; //True or False for if the user has entered a valid operator
            string operatorChoice = null;
            while (correctInput != true) //While loop to keep running until user selects a valid operator
            {
                
                Console.WriteLine("""$$$$$$\          $$\                  $$\          $$\ """);
                Console.WriteLine("""//    $$  __$$\   $$ |                 $$ |         $$ |""");
                Console.WriteLine("""$$ /  \__|$$$$$$\ $$ |$$$$$$$\$$\   $$\$$ |$$$$$$\$$$$$$\   $$$$$$\  $$$$$$\""");
                Console.WriteLine("""$$ |      \____$$\$$ $$  _____$$ |  $$ $$ |\____$$\_$$  _| $$  __$$\$$  __$$\""");
                Console.WriteLine("""$$ |      $$$$$$$ $$ $$ /     $$ |  $$ $$ |$$$$$$$ |$$ |   $$ /  $$ $$ |  \__|""");
                Console.WriteLine("""$$ |  $$\$$  __$$ $$ $$ |     $$ |  $$ $$ $$  __$$ |$$ |$$\$$ |  $$ $$ |""");
                Console.WriteLine("""\$$$$$$  \$$$$$$$ $$ \$$$$$$$\\$$$$$$  $$ \$$$$$$$ |\$$$$  \$$$$$$  $$ |""");
                Console.WriteLine("""\______/ \_______\__|\_______|\______/\__|\_______| \____/ \______/\__|""");
                
                Console.WriteLine("\nWhat operator would you like to use (* / + -) : "); //Prints out question
                operatorChoice = Console.ReadLine(); //Reads user input

                if (ContainsAny(operatorChoice, "*","/","-","+") && operatorChoice.Length == 1) //Checks if string contains a valid option and if the string is 1 character long
                {
                    Console.Clear();
                    correctInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This is an invalid option, try again.\n");
                }
            }

            correctInput = false;
            
            string? strFirstNum = null;
            while (correctInput != true)
            {
                Console.WriteLine("First Number: ");
                strFirstNum = Console.ReadLine();
                long longFirstNum;
                bool isNumerical = long.TryParse(strFirstNum, out longFirstNum);
                
                if (isNumerical == true && 0 <= strFirstNum.Length )
                {
                    Console.Clear();
                    correctInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter a valid digit\n");
                }
                
            }

            if (string.IsNullOrWhiteSpace(operatorChoice) || string.IsNullOrWhiteSpace(strFirstNum))
            {
                throw new Exception("Missing user input");
            }

            correctInput = false;
            string strSecondNum = null;

            while (correctInput != true)
            {
                Console.WriteLine($"Equation: {strFirstNum} {operatorChoice}");
                Console.WriteLine("Second Number: ");
                strSecondNum = Console.ReadLine();

                bool isNumerical = long.TryParse(strSecondNum, out _);
                
                if (isNumerical == true && 0 <= strSecondNum.Length )
                {
                    Console.Clear();
                    correctInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter a valid digit\n");
                }
                
            }

            long calculation = 0;
            
            long Num1 = long.Parse(strFirstNum);
            long Num2 = long.Parse(strSecondNum);

            if (operatorChoice == "*")
            {
                calculation = Num1 * Num2;
            }
            else if (operatorChoice == "/")
            {
                calculation = Num1 / Num2;
            }
            else if (operatorChoice == "+")
            {
                calculation = Num1 + Num2;
            }
            else if (operatorChoice == "-")
            {
                calculation = Num1 - Num2;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Equation: {strFirstNum} {operatorChoice} {strSecondNum} = {calculation.ToString("N0")}");

            Console.ReadKey();
        }
        
        
        public static bool ContainsAny(string haystack, params string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }

            return false;
        }
    }
}    