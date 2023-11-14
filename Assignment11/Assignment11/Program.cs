// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
namespace Assignment11;
internal class Program
{
    static void Main(string[]args)
    {
        while (true)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Create File");
            Console.WriteLine("2. Read File");
            Console.WriteLine("3. Delete File");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter file name: ");
                        string createFileName = Console.ReadLine();
                        Console.Write("Enter content: ");
                        string content = Console.ReadLine();
                        CreateFile(createFileName, content);
                        break;
                    case 2:
                        Console.Write("Enter file name to read: ");
                        string readFileName = Console.ReadLine();
                        ReadFile(readFileName);
                        break;
                    case 3:
                        Console.Write("Enter file name to delete: ");
                        string deleteFileName = Console.ReadLine();
                        DeleteFile(deleteFileName);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void CreateFile(string fileName, string content)
    {
        try
        {
            File.WriteAllText(fileName, content);
            Console.WriteLine($"File '{fileName}' created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating file: {ex.Message}");
        }
    }

    static void ReadFile(string fileName)
    {
        try
        {
            string content = File.ReadAllText(fileName);
            Console.WriteLine($"Content of file '{fileName}':\n{content}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    static void DeleteFile(string fileName)
    {
        try
        {
            File.Delete(fileName);
            Console.WriteLine($"File '{fileName}' deleted successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }
    }
}

