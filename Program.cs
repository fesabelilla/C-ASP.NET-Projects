using System;
using System.IO;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            //var filePath = @"C:\Users\Student\source\repos\Demo.txt";

            //var text = File.ReadAllText(filePath);

            //string[] lineText = File.ReadAllLines(filePath);

            //string[] items;

            //foreach(var line in lineText)
            //{
            //    items = line.Split(';');
            //    Console.WriteLine("Name:" + items[0]);
            //    Console.WriteLine("Number:" + items[1]);

            //}

            var filePath = @"C:\Users\Student\source\repos\in.txt";
            string[] lineText = File.ReadAllLines(filePath);
            string[] items;

            foreach (var line in lineText)
            {
                items = line.Split(',');
                // Console.WriteLine("Name:" + items[0]);
                //Console.WriteLine("Number:" + items[3]);

                if (items[1].Equals("C") && Convert.ToDouble(items[3]) > 3.6)
                {
                    Console.WriteLine("Name: " + items[0]);
                    Console.WriteLine("GPA: " + items[3]);

                }

                if (items[1].Equals("Math") && !items[1].Equals("Python"))
                {
                    Console.WriteLine("Name: " + items[0]);
                    Console.WriteLine("ID: " + items[2]);

                }

               // Console.WriteLine("Name: " + items[1]);


            }
            
            Console.ReadLine();

        }
    }
}
