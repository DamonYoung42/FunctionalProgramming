using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assignment #1
            //Write a function that takes in a string of grades(e.g., "90,100,82,89,55"), and returns an average of all but the lowest three grades(e.g., "90,100" => 95).

            string studentA = "90,85,75,60,99,100,77,87,92,96,83,103";
            string studentB = "80,93,79,56,91,88,75,87,83,93,88,70";

            Func<string, double> Average;
            Average = CalculateGradeAverage; 

            Console.WriteLine("Convert STRING of grades to average:");
            Console.WriteLine(studentA);
            Console.WriteLine("Student A's grade verage without three lowest scores: {0:00.00}\n", Average(studentA));


            Console.WriteLine(studentB);
            Console.WriteLine("Grade Average without three lowest scores: {0:00.00}\n", studentB.Split(',').Select(int.Parse).ToArray().OrderBy(c => c).Skip(3).Average());


            //Assignment #2
            //Write a function that takes in a string of letters(e.g., "Llewellyn") and returns an alphabetically ordered string corresponding to the letter frequency (e.g., "E2L4N1W1Y1")

            Console.WriteLine("\nConvert STRING into STRING of characters and counts");
            List<string> Names = new List<string>() { "Llewellyn", "Connecticut", "Wisconsin", "Indiana", "Tommy", "Adam", "Mississippi", "Brewers" };

            //Create Func
            Func<string, string> CharacterCount;

            CharacterCount = CountEachCharacter;
            foreach (string item in Names)
            {
                Console.WriteLine(item + ": " + CharacterCount(item));
            }
            Console.ReadLine();

            //Assignment #3 ... Write a LINQ operation that takes in a log file path, a start timestamp and end timestamp and parses a log file to only return dates within that date range.    
            string fileName = "Sample.txt";        
            ParseLogFile(fileName, "07/Mar/2004:17:39:39", "07/Mar/2004:17:50:44");
            Console.ReadLine();
        }

        public delegate string StringToDoubleFunction(string grades);
        public static double CalculateGradeAverage(string grades)
        {
            return grades.Split(',').Select(int.Parse).ToArray().OrderBy(value => value).Skip(3).Average();
        }


        public delegate string StringToStringFunction(string name);
        public static string CountEachCharacter(string name)
        {
            string newString = "";

            Dictionary<char,int> counts = name.ToUpper().GroupBy(character => character).OrderBy(character => character.Key).ToDictionary(group => group.Key, group => group.Count());
            foreach (KeyValuePair<char,int> item in counts)
            {
                newString += item.Key.ToString() + item.Value;
            }
            return newString;
        }


        public static void ParseLogFile(string fileName, string startTimestamp, string endTimestamp)
        {
            string startdate = startTimestamp;
            string enddate = endTimestamp;
            string[] lines = File.ReadAllLines(fileName);

            //var startingLineNumber = lines.Select(i => new { index = i }).Where((n,i) => n.Contains(startTimestamp));
            //var startingLine = lines.Select((index).Where(r => lines.Contains(startTimestamp));
            var  startingLineNumber = lines.Select((r, i) => new { line = r, index = i }).Where(r => r.line.Contains(startTimestamp)).Select(r => new { LineNo = r.index });
            var endingLineNumber = lines.Select((r, i) => new { line = r, index = i }).Where(r => r.line.Contains(endTimestamp)).Select(r => new { LineNo = r.index });

            for (int i = startingLineNumber.First().LineNo; i < endingLineNumber.First().LineNo + 1; i++)
            {
                Console.WriteLine(lines[i]);
            }      


            

            //for (int i = startingLineNumber; i < endingLineNumber + 1; i++)
            //{
            //    Console.WriteLine(lines[i]);
            //}


            //string content = File.ReadAllText("Sample.txt");
            //int start = content.IndexOf(startdate);
            //if (start >= 0)
            //{
            //    start += startdate.Length;
            //    int end = content.IndexOf(enddate, start);
            //    if (end >= 0)
            //    {
            //        string log = content.Substring(start, end - start);
            //        Console.WriteLine(log);
            //    }
            //}
        }
            //File.ReadLines(fileName).TakeWhile((x) => x.)

        //Assignment #1 
        //Starting with a LIST of grades
        //List<int> grades = new List<int>() { 90, 85, 75, 60, 99, 100, 77, 87, 92, 96, 83, 103 };

        //Console.WriteLine("Original List of Grades");
        //grades.ForEach((x) => { Console.WriteLine(x); });

        //Func<List<int>, double> CalculateGradeAverage;
        //CalculateGradeAverage = (List<int> x) => { x.Sort(); x.ForEach((y) => { Console.Write(y + ","); }); return x.Skip(3).Average(); };

        //Console.WriteLine("Average (minus lowest three grades): {0:00.00}", CalculateGradeAverage(grades));
        //Console.ReadLine();
    }
}
