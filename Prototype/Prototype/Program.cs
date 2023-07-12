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
            //Verification of input
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }

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
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        public static Matrix InsertOrCreateMenu()
        {
            Console.Write($@"1. Insert
2. Create
");
            //Verification of input
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                Console.Clear();
                InsertOrCreateMenu();
            }
            switch (choice)
            {
                case 1:
                    return InsertMatrix();
                case 2:
                    return CreateMatrix();
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    return InsertOrCreateMenu();
            }
        }

        public static Matrix InsertMatrix()
        {
            Console.Clear();
            Console.WriteLine("Please enter the matrix dimensions:");
            Console.Write("Rows: ");
            int rows;
            while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Rows: ");
            }
            Console.Write("Columns: ");
            int columns;
            while (!int.TryParse(Console.ReadLine(), out columns) || columns <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Columns: ");
            }

            int[,] values = new int[rows, columns];

            Console.WriteLine("Please enter the matrix elements:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Element[{i},{j}]: ");
                    while (!int.TryParse(Console.ReadLine(), out values[i, j]))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                        Console.Write($"Element[{i},{j}]: ");
                    }
                }
            }

            Console.WriteLine("Matrix:");
            DisplayMatrix(new Matrix { Rows = rows, Columns = columns, Values = values });

            Console.WriteLine("Is this the matrix you want? (Y/N)");
            char confirmation;
            while (!char.TryParse(Console.ReadLine(), out confirmation) || (confirmation != 'Y' && confirmation != 'N'))
            {
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
            }

            if (confirmation == 'N')
            {
                return InsertMatrix();
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
            int rows;
            while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Rows: ");
            }
            Console.Write("Columns: ");
            int columns;
            while (!int.TryParse(Console.ReadLine(), out columns) || columns <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Columns: ");
            }

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

            Console.WriteLine("Matrix:");
            DisplayMatrix(new Matrix { Rows = rows, Columns = columns, Values = values });

            Console.WriteLine("Is this the matrix you want? (Y/N)");
            char confirmation;
            while (!char.TryParse(Console.ReadLine(), out confirmation) || (confirmation != 'Y' && confirmation != 'N'))
            {
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
            }

            if (confirmation == 'N')
            {
                return CreateMatrix();
            }

            Console.WriteLine("Matrix created successfully.");
            Console.ReadKey();

            return new Matrix { Rows = rows, Columns = columns, Values = values };
        }

        public static void DisplayMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix.Values[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        public static void Addition()
        {
            Matrix matrixA = InsertOrCreateMenu();

            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);

            Matrix matrixB = InsertOrCreateMenu();

            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);


            //Check for dimensions
            if (matrixA.Columns != matrixB.Columns || matrixA.Rows != matrixB.Rows)
            {
                Console.WriteLine("Error: Incompatible matrix dimensions for addition.");
                Console.ReadKey();
                Console.Clear();
                Menu();
                return;
            }

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

            Matrix matrix = new Matrix { Rows = matrixA.Rows, Columns = matrixA.Columns, Values = values };


            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);
            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);
            Console.WriteLine("Final Matrix:");
            DisplayMatrix(matrix);

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void Subtraction()
        {
            Matrix matrixA = InsertOrCreateMenu();

            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);

            Matrix matrixB = InsertOrCreateMenu();

            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);


            //Check for dimensions
            if (matrixA.Columns != matrixB.Columns || matrixA.Rows != matrixB.Rows)
            {
                Console.WriteLine("Error: Incompatible matrix dimensions for subtraction.");
                Console.ReadKey();
                Console.Clear();
                Menu();
                return;
            }

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

            Matrix matrix = new Matrix { Rows = matrixA.Rows, Columns = matrixA.Columns, Values = values };

            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);
            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);
            Console.WriteLine("Final Matrix:");
            DisplayMatrix(matrix);

            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void Multiplication()
        {
            Matrix matrixA = InsertOrCreateMenu();

            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);

            Matrix matrixB = InsertOrCreateMenu();

            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);

            // Check if the number of columns in matrixA matches the number of rows in matrixB
            if (matrixA.Columns != matrixB.Rows)
            {
                Console.WriteLine("Error: Incompatible matrix dimensions for multiplication.");
                Console.ReadKey();
                Console.Clear();
                Menu();
                return;
            }

            int[,] values = new int[matrixA.Rows, matrixB.Columns];

            Console.WriteLine("Performing Multiplication...");
            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixB.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrixA.Columns; k++)
                    {
                        sum += matrixA.Values[i, k] * matrixB.Values[k, j];
                    }
                    values[i, j] = sum;
                }
            }
            Console.WriteLine("Multiplication complete.");

            Matrix matrix = new Matrix { Rows = matrixA.Rows, Columns = matrixB.Columns, Values = values };

            Console.WriteLine("Matrix A:");
            DisplayMatrix(matrixA);
            Console.WriteLine("Matrix B:");
            DisplayMatrix(matrixB);
            Console.WriteLine("Final Matrix:");
            DisplayMatrix(matrix);

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
