using System;
using System.Threading;

namespace lab2
{
    internal class Program
    {
        static Thread t1 = new Thread(() => show(ConsoleColor.Red, "Thread1"));
        static Thread t2 = new Thread(() => show(ConsoleColor.Green, "Thread2"));
        static Thread t3 = new Thread(() => show(ConsoleColor.White, "Thread3"));
        static Thread t4 = new Thread(() => show(ConsoleColor.Blue, "Thread4"));
        static Thread t5 = new Thread(() => show(ConsoleColor.Magenta, "Thread5"));
        static object locker = new();
        static void Main(string[] args)
        {
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            t1.Priority = ThreadPriority.BelowNormal;
            t2.Priority = ThreadPriority.Lowest;
            t3.Priority = ThreadPriority.Highest;
            t4.Priority = ThreadPriority.Normal;
            t5.Priority = ThreadPriority.AboveNormal;
        }
        static void show(ConsoleColor c, string msg)
        {
            lock (locker) // lock синхронизирует потоки, заставляя "прислушаться" к ресурсам. Можно и не использовать
            {
                Console.ForegroundColor = c;
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(msg);
                }
            }
        }
    }
}
