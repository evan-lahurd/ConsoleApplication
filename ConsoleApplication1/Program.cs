using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {

    public class Program {

        public static void Main(String[] args) {
            writeCommandLineArgs(args);

            writeNumbers();

            writeNumberString();
        }

        public static void writeCommandLineArgs(String[] args) {
            String name = "Evan";
            Console.WriteLine("You entered {0} command-line arguments, {1}.", args.Length, name);
            Console.WriteLine("Hello World!");
            if (args.Length == 1) {
                Console.Write("Your argument is {0}", args[0]);
            } else {
                Console.Write("Your arguments are ");
                if (args.Length == 0) {
                    Console.Write("empty");
                } else {
                    foreach (string s in args) {
                        Console.Write(s + " ");
                    }
                }
            }   
            Console.WriteLine();
        }

        public static void writeNumbers() {
            for (int i = 0; i < 10; i++) {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        public static void writeNumberString() {
            StringBuilder builder = new StringBuilder();
            int appendLength = 10;
            for (int i = 0; i < appendLength; i++) {
                builder.Append(i);
                if (i < (appendLength - 1)) {
                    builder.Append(",");
                }
            }
            Console.WriteLine(builder.ToString() + "\n");
        }
    }
}
