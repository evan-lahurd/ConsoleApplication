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

            // start the print Threads
            Thread[] threads = spawnPrintThreads();
            // wait for all of the print Threads to complete
            foreach (Thread thread in threads) {
                thread.Join();
            }
            Console.WriteLine("All complex operations have been completed in Threads!\n");

            // start the print Tasks
            Task[] tasks = spawnPrintTasks();
            // wait for all of the print Tasks to complete
            Task.WaitAll(tasks);
            Console.WriteLine("All complex operations have been completed in Tasks!");

        }

        private static Thread[] spawnPrintThreads() {
            int numThreads = 5;
            Random rand = new Random();
            Thread[] threads = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++) {
                // define copy of i inside loop to prevent WriteLine() from printing final value of i for each Thread
                int threadNum = i;
                Thread thread = new Thread(() => {
                    int operationTime = rand.Next(1000, 5000);
                    Console.WriteLine("Complex operation {0} starting...operation should take {1} seconds", threadNum, operationTime/1000.0);
                    Thread.Sleep(operationTime);
                    Console.WriteLine("Complex operation {0} complete!", threadNum);
                });
                threads[i] = thread;
                thread.Start();
            }
            return threads;
        }

        private static Task[] spawnPrintTasks() {
            int numTasks = 5;
            Random rand = new Random();
            Task[] tasks = new Task[numTasks];
            for (int i = 0; i < numTasks; i++) {
                // define copy of i inside loop to prevent WriteLine() from printing final value of i for each Task
                int taskNum = i;
                Task task = new Task(() => {
                    int operationTime = rand.Next(1000, 5000);
                    Console.WriteLine("Complex operation {0} starting...operation should take {1} seconds", taskNum, operationTime/1000.0);
                    Thread.Sleep(operationTime);
                    Console.WriteLine("Complex operation {0} complete!", taskNum);
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
            Console.WriteLine(builder.ToString());
        }
    }
}
