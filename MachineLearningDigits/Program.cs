using MachineLearningDigits.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineLearningDigits.Commands;

namespace MachineLearningDigits
{
    public class Program
    {
        static void Main(string[] args)
        {
            var trainingArray = File.ReadAllLines("ExcelFiles/trainingsample.csv");
            var noHeadersArray = trainingArray.Skip(1);
            var splittedRows = noHeadersArray.Select(e => e.Split(',').Select(x => int.Parse(x))).ToList();
            var recordsList = splittedRows.Select(r =>
            {
                Record newRecord = new Record()
                {
                    Number = r.First(),
                    Pixels = r.Skip(1).ToArray()
                };
                return newRecord;
            }).ToArray();

            var validationArray = File.ReadAllLines("ExcelFiles/validationsample.csv");
            var splittedValidationArray = validationArray.Skip(1).Select(e => e.Split(',').Select(x => int.Parse(x))).ToList();
            var validationrecordsList = splittedValidationArray.Select(r =>
            {
                Record newRecord = new Record()
                {
                    Number = r.First(),
                    Pixels = r.Skip(1).ToArray()
                };
                return newRecord;
            }).ToArray();

            var results = Prediction.Predict(recordsList, validationrecordsList);

            for (var i = 0; i< results.ToArray().Length;i++)
            {
                Console.WriteLine($" The closest match for{i}-th record is {results[i].Number} with a distance of {results[i].DistanceToNumber}");
            }
            Console.ReadLine();
        }
    }
}
