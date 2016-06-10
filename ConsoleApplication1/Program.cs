using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1 {

    public class Program {

        public static void Main(String[] args) {

            writeCommandLineArgs(args);

            writeNumbers();

            writeNumberString();

            Console.WriteLine(MyMath.AddNumbers(5, 8));

            Task[] tasks = spawnPrintTasks();

            Task.WaitAll(tasks);

            Console.WriteLine("All complex operations have been completed!");

        }

        private static Task[] spawnPrintTasks() {
            int numTasks = 5;
            Random rand = new Random();
            Task[] tasks = new Task[numTasks];
            for (int i = 0; i < numTasks; i++) {
                // define copy of i inside loop to prevent WriteLine() from printing final value of i for each Task
                int threadNum = i;
                Task task = new Task(() => {
                    Console.WriteLine("Complex operation {0} starting...", threadNum);
                    Thread.Sleep(rand.Next(1000, 5000));
                    Console.WriteLine("Complex operation {0} complete!", threadNum);
                });
                tasks[i] = task;
                task.Start();
            }
            return tasks;
        }

        private static void writeCommandLineArgs(String[] args) {
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

        private static void writeNumbers() {
            for (int i = 0; i < 10; i++) {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        private static void writeNumberString() {
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
