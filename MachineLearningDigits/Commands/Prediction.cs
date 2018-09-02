using MachineLearningDigits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningDigits.Commands
{
    public class Prediction
    {
        public static List<DistanceNumber> Predict(Record[] sampleRecordsList, Record[] validationRecordsList)
        {
            var resultsList = new List<DistanceNumber>();

            for (var i=0; i < validationRecordsList.Length; i++)
            {
                var listForPrediction = sampleRecordsList.Select(r =>
                {
                    DistanceNumber distanceNumber = new DistanceNumber()
                    {
                        Number = r.Number,
                        DistanceToNumber = Distance.GetDistance(r.Pixels, validationRecordsList.Skip(i).FirstOrDefault().Pixels)
                    };
                    return distanceNumber;

                }).OrderBy(g => g.DistanceToNumber).ToArray();

                resultsList.Add(listForPrediction.FirstOrDefault());
            }
            return resultsList;
        }
    }
}
