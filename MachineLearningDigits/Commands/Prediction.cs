using MachineLearningDigits.Models;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearningDigits.Commands
{
    public class Prediction
    {
        public static List<DistanceNumber> Predict(Record[] sampleRecordsList, Record[] validationRecordsList)
        {
            var resultsList = new List<DistanceNumber>();

            for (var i=0; i < validationRecordsList.Length; i++)
            {
                var closestMatch = sampleRecordsList.Select(r =>
                {
                    DistanceNumber distanceNumber = new DistanceNumber()
                    {
                        Number = r.Number,
                        DistanceToNumber = Distance.GetDistance(r.Pixels, validationRecordsList.Skip(i).FirstOrDefault().Pixels)
                    };
                    return distanceNumber;

                }).OrderBy(g => g.DistanceToNumber).ToArray().FirstOrDefault();

                resultsList.Add(closestMatch);
            }
            return resultsList;
        }
    }
}
