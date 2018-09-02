using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningDigits
{
    public class Program
    {
        static void Main(string[] args)
        {

            var trainingArray = File.ReadAllLines("ExcelFiles/trainingsample.csv");
            var noHeadersArray = trainingArray.Skip(1);

            var splittedRows = noHeadersArray.Select(e => e.Split(',').Select(x => int.Parse(x))).ToList();

            foreach (var row in splittedRows.Take(2))
            {
                foreach (var item in row)
                {
                    Console.Write($"{item}|");
                }
                Console.WriteLine(" --- ");
            }

    
            Console.ReadLine();
            Console.WriteLine("Hello world!");

        }
    }
}
