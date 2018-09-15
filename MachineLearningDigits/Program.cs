using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MachineLearningDigits.Commands;
using MachineLearningDigits.Helpers;

namespace MachineLearningDigits
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var csvHelper = new CSVFormatter();

            var trainingArray = File.ReadAllLines("ExcelFiles/trainingsample.csv");
            var recordsList = csvHelper.FormatToRecordList(trainingArray);

            var validationArray = File.ReadAllLines("ExcelFiles/validationsample.csv");
            var validationrecordsList = csvHelper.FormatToRecordList(validationArray);

            var results = Prediction.Predict(recordsList, validationrecordsList);
            int accuracy = 0;
            for (var i = 0; i< results.ToArray().Length;i++)
            {
                if (results[i].Number.Equals(validationrecordsList[i].Number)) { accuracy++; }
                Console.WriteLine($" The closest match for{i}-th record is {results[i].Number} || {validationrecordsList[i].Number} distance of {results[i].DistanceToNumber}");
            }
            Console.WriteLine($"Accuracy is {accuracy} out of {validationArray.Length}");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }
    }
}
