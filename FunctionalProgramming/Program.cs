using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            //Starting with a LIST of grades
            //List<int> grades = new List<int>() { 90, 85, 75, 60, 99, 100, 77, 87, 92, 96, 83, 103 };

            //Console.WriteLine("Original List of Grades");
            //grades.ForEach((x) => { Console.WriteLine(x); });

            //Func<List<int>, double> CalculateGradeAverage;
            //CalculateGradeAverage = (List<int> x) => { x.Sort(); x.ForEach((y) => { Console.Write(y + ","); }); return x.Skip(3).Average(); };

            //Console.WriteLine("Average (minus lowest three grades): {0:00.00}", CalculateGradeAverage(grades));
            //Console.ReadLine();


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

            Dictionary<char,int> counts = name.ToLower().GroupBy(character => character).OrderBy(character => character.Key).ToDictionary(group => group.Key, group => group.Count());
            foreach (KeyValuePair<char,int> item in counts)
            {
                newString += item.Key.ToString() + item.Value;
            }
            return newString;
        }
    }
}
