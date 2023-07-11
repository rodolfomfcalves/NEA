using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Prototype
{
    internal class Program
    {

        internal struct Matrix
        {
            public int Rows;
            public int Columns;
            public int[,] Values;
        }

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"
    ███╗   ███╗ █████╗ ████████╗██████╗ ██╗██╗  ██╗     ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗ 
    ████╗ ████║██╔══██╗╚══██╔══╝██╔══██╗██║╚██╗██╔╝    ██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
    ██╔████╔██║███████║   ██║   ██████╔╝██║ ╚███╔╝     ██║     ███████║██║     ██║     ██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝
    ██║╚██╔╝██║██╔══██║   ██║   ██╔══██╗██║ ██╔██╗     ██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗
    ██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║██║██╔╝ ██╗    ╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║
    ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝     ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
                                                                                                                                     
");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($@"1. Addition
2. Subtraction
3. Multiplication
4. Quit
");
            //Add verification of input
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Addition();
                    break;
                case 2:
                    Subtraction();
                    break;
                case 3:
                    Multiplication();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    Menu();
                    break;
            }
        }

        public static Matrix InsertOrCreateMenu()
        {
            Console.Write($@"1. Insert
2. Create
");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    return InsertMatrix();
                case 2:
                    return CreateMatrix();
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    InsertOrCreateMenu();
                    break;
            }
            //Only Troubleshooting (need to fix recursion issue otherwise it will keep running and return null at the end)
            return new Matrix();
        }

        public static Matrix InsertMatrix()
        {
            Console.Clear();
            Console.WriteLine("Please enter the matrix dimensions:");
            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int columns = int.Parse(Console.ReadLine());

            int[,] values = new int[rows, columns];

            Console.WriteLine("Please enter the matrix elements:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Element[{i},{j}]: ");
                    values[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Matrix inserted successfully.");
            Console.ReadKey();

            return new Matrix { Rows = rows, Columns = columns, Values = values };
        }

        public static Matrix CreateMatrix()
        {
            Console.Clear();
            Console.WriteLine("Please enter the matrix dimensions:");
            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int columns = int.Parse(Console.ReadLine());

            Random random = new Random();
            int[,] values = new int[rows, columns];

            Console.WriteLine("Creating matrix...");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    values[i, j] = random.Next(10);
                }
            }

            Console.WriteLine("Matrix created successfully.");
            Console.ReadKey();

            return new Matrix { Rows = rows, Columns = columns, Values = values };
        }

        public static void Addition()
        {
            Matrix matrixA = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixA.Values)
            {
                Console.Write(i + " ");
            }
            Matrix matrixB = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixB.Values)
            {
                Console.Write(i + " ");
            }


            //Add Check for dimensions


            int[,] values = new int[matrixA.Rows, matrixA.Columns];

            Console.WriteLine("Performing Addition...");
            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Columns; j++)
                {
                    values[i, j] = matrixA.Values[i, j] + matrixB.Values[i, j];
                }
            }
            Console.WriteLine("Addition complete.");
            //Console Writing for checking
            foreach (int i in values)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void Subtraction()
        {
            Matrix matrixA = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixA.Values)
            {
                Console.Write(i + " ");
            }
            Matrix matrixB = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixB.Values)
            {
                Console.Write(i + " ");
            }


            //Add Check for dimensions


            int[,] values = new int[matrixA.Rows, matrixA.Columns];

            Console.WriteLine("Performing Subtraction...");
            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Columns; j++)
                {
                    values[i, j] = matrixA.Values[i, j] - matrixB.Values[i, j];
                }
            }
            Console.WriteLine("Subtraction complete.");
            //Console Writing for checking
            foreach (int i in values)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void Multiplication()
        {
            Matrix matrixA = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixA.Values)
            {
                Console.Write(i + " ");
            }
            Matrix matrixB = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixB.Values)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("Performing Multiplication...");
            // Add multiplication logic here
            Console.WriteLine("Multiplication complete.");

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        static void Main(string[] args)
        {
            //Makes the window wide enough for the title to be correctly shown
            Console.WindowWidth = 160;
            //Menu subroutine will handle all the connections which results in Menu simply being the system itself
            Menu();


            //Leave untouched
            Console.ReadKey();
        }
    }
}
