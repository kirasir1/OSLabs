using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3
{
    class Program
    {
        public static List<int> shelf = new List<int>() { };
        protected static int origRow = Console.CursorTop;
        protected static int origCol = Console.CursorLeft;
        static void Main(string[] args)
        {
            /*while (true)
            {
                Producer();
                for (int i = 0; i < shelf.Count; i++)
                {
                    Console.WriteLine(shelf[i]);
                }
            }*/
            Thread newproducer = new Thread(new ThreadStart(Producer));
            Thread newcustomer = new Thread(new ThreadStart(Customer));
            newproducer.Start();
            newcustomer.Start();
        }
        private static void Producer()
        {
            while (true)
            {
                Random newitem = new Random();
                int a = newitem.Next(10, 100);
                shelf.Add(a);
                Console.WriteLine("Added "+a);
                Console.SetCursorPosition(origCol, origRow);
                Thread.Sleep(newitem.Next(300, 1500));
            }
        }
        private static void Customer()
        {
            while (true)
            {
                Random pickitem = new Random();
                int b = pickitem.Next(0, shelf.Count);
                if (shelf.Count > 0)
                {
                    shelf.RemoveAt(b); 
                    Console.WriteLine("Removed "+b);
                    Console.SetCursorPosition(origCol, origRow+1);
                }
                Thread.Sleep(pickitem.Next(200, 2000));
            }
        }
    }
}