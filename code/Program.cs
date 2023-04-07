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

            // amount of combinations
            double amount = 0;
            for (int i = 0; i < noNums.Length; i++)
            {
                amount += Math.Pow(2, i);
            }
            string[] combinations = new string[(int)amount + 1];

            // create combinations of binary numbers (001, 010...) that will be used to determine upper/lower case letters
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

            // check combinations for all letters (upper = 1 / lower = 0)
            for (int i = 0; i < combinations.Length; i++)
            {
                Console.WriteLine($"combination[{i}] = " + combinations[i]);
            }

            // output
            Console.WriteLine("\nOutput:");
            string[] outputs = new string[combinations.Length];
            for (int i = 0; i < combinations.Length; i++)
            {
                int index = 0;
                for (int i2 = 0; i2 < s.Length; i2++)
                {
                    if (s[i2] == '0' || s[i2] == '1' || s[i2] == '2' || s[i2] == '3' || s[i2] == '4' || s[i2] == '5' || s[i2] == '6' || s[i2] == '7' || s[i2] == '8' || s[i2] == '9') // if number
                    {
                        outputs[i] += s[i2];
                    }
                    else // if letter
                    {
                        if (combinations[i][index] == '0')
                        {
                            outputs[i] += Convert.ToString(s[i2]).ToLower();
                            index++;
                        }
                        else if (combinations[i][index] == '1')
                        {
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
