using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name = "Evan";
            Console.WriteLine("You entered {0} command-line arguments, {1}", args.Length, name);
            Console.WriteLine("Hello World!");
            Console.Write("Your arguments are ");
            foreach (string s in args)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}
