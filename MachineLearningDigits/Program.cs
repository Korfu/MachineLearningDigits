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

            var trainingArray = File.ReadAllLines("ExcelFiles/trainingsample.csv").Skip(1);


            foreach (var row in trainingArray.Take(5))
            {
                Console.WriteLine(row);
                Console.WriteLine(" --- ");
            }

    
            Console.ReadLine();

        }
    }
}
