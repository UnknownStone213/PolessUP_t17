using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string s = Console.ReadLine();

            bool[] checkNum = new bool[s.Length]; // positions of nums
            string noNums = ""; // string with no nums
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '0' && s[i] != '1' && s[i] != '2' && s[i] != '3' && s[i] != '4' && s[i] != '5' && s[i] != '6' && s[i] != '7' && s[i] != '8' && s[i] != '9')
                {
                    checkNum[i] = true;
                    noNums += s[i];
                }
            }

            double amount = 0;
            for (int i = 0; i < noNums.Length; i++)
            {
                amount += Math.Pow(2, i);
            }
            string[] combinations = new string[(int)amount + 1];

            // create combinations
            for (int i = 0; i < combinations.Length; i++)
            {
                string num = ""; // binary number 0101.... for combinations
                int index = 0;
                int currentNum = i;
                int[] a = new int[noNums.Length];
                for (int i2 = 0; currentNum > 0;  i2++) 
                {
                    a[i2] = currentNum % 2;
                    currentNum /= 2;
                    index = i2;
                }
                for (int i2 = index; i2 >= 0; i2--)
                {
                    num += a[i2];
                }
                while (num.Length < noNums.Length) 
                {
                    num = "0" + num;
                }
                combinations[i] = num;
            }

            // check combinations for all numbers (upper/lower case)
            Console.WriteLine();
            for (int i = 0; i < combinations.Length; i++)
            {
                Console.WriteLine($"combination[{i}] = " + combinations[i]);
            }
            Console.WriteLine();

            // output
            Console.WriteLine("\nOutput:");
            string[] outputs = new string[combinations.Length];
            for (int i = 0; i < combinations.Length; i++)
            {
                int index = 0;
                for (int i2 = 0; i2 < s.Length; i2++)
                {
                    if (checkNum[i2] == true) // check if number
                    {
                        outputs[i] += s[i2];
                    }
                    else
                    {
                        if (combinations[i][index] == '0')
                        {
                            Console.WriteLine("1)");
                            outputs[i] += Convert.ToString(s[i2]).ToLower();
                            index++;
                        }
                        else if (combinations[i][index] == '1')
                        {
                            Console.WriteLine("2)");
                            outputs[i] += Convert.ToString(s[i2]).ToUpper();
                            index++;
                        }
                    }
                }
                Console.WriteLine(outputs[i]);
            }


            Console.ReadLine();
        }
    }
}
