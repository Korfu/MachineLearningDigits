using System;
using System.IO;
using MachineLearningDigits.Commands;
using MachineLearningDigits.Helpers;

namespace MachineLearningDigits
{
    public class Program
    {
        static void Main(string[] args)
        {
            var csvHelper = new CSVFormatter();

            var trainingArray = File.ReadAllLines("ExcelFiles/trainingsample.csv");
            var recordsList = csvHelper.FormatToRecordList(trainingArray);

            var validationArray = File.ReadAllLines("ExcelFiles/validationsample.csv");
            var validationrecordsList = csvHelper.FormatToRecordList(validationArray);

            var results = Prediction.Predict(recordsList.ToArray(), validationrecordsList.ToArray());

            for (var i = 0; i< results.ToArray().Length;i++)
            {
                Console.WriteLine($" The closest match for{i}-th record is {results[i].Number} with a distance of {results[i].DistanceToNumber}");
            }
            Console.ReadLine();
        }
    }
}
