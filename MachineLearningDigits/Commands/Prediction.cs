using MachineLearningDigits.Models;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearningDigits.Commands
{
    public class Prediction
    {
        public static DistanceNumber[] Predict(Record[] sampleRecordsList, Record[] validationRecordsList)
        {
            var resultsList = new DistanceNumber[validationRecordsList.Length];

            for (var i=0; i < validationRecordsList.Length; i++)
            {
                var closestMatch = sampleRecordsList.AsParallel().Select(r =>
                {
                    DistanceNumber distanceNumber = new DistanceNumber()
                    {
                        Number = r.Number,
                        DistanceToNumber = Distance.GetDistance(r.Pixels, validationRecordsList[i].Pixels)
                    };
                    return distanceNumber;

                }).OrderBy(g => g.DistanceToNumber).ToList().FirstOrDefault();

                resultsList[i] =closestMatch;
            }
            return resultsList;
        }
    }
}
