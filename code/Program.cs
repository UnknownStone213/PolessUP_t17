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

            // create
            int position = 0;
            for (int i = 0; i < combinations.Length; i++)
            {

            }


            Console.ReadLine();
        }
    }
}
