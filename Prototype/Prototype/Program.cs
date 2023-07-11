using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Prototype
{
    internal class Program
    {

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

        public static int[,] InsertOrCreateMenu()
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
            return null;
        }

        public static int[,] InsertMatrix()
        {
            Console.Clear();
            Console.WriteLine("Please enter the matrix dimensions:");
            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int columns = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, columns];

            Console.WriteLine("Please enter the matrix elements:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Element[{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Matrix inserted successfully.");
            //Write matrix
            Console.ReadKey();
            return matrix;
        }

        public static int[,] CreateMatrix()
        {
            Console.Clear();
            Console.WriteLine("Please enter the matrix dimensions:");
            Console.Write("Rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int columns = int.Parse(Console.ReadLine());

            Random random = new Random();
            int[,] matrix = new int[rows, columns];

            Console.WriteLine("Creating matrix...");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(10);
                }
            }

            Console.WriteLine("Matrix created successfully.");
            //Write Matrix
            Console.ReadKey();
            return matrix;
        }

        public static void Addition()
        {
            int[,] matrixA = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixA)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("Performing Addition...");
            // Add addition logic here
            Console.WriteLine("Addition complete.");

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void Subtraction()
        {
            int[,] matrixA = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixA)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("Performing Subtraction...");
            // Add subtraction logic here
            Console.WriteLine("Subtraction complete.");

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void Multiplication()
        {
            int[,] matrixA = InsertOrCreateMenu();
            //Console Writing for checking
            foreach (int i in matrixA)
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
