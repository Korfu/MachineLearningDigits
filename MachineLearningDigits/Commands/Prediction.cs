using MachineLearningDigits.Models;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearningDigits.Commands
{
    public class Prediction
    {
        public static List<DistanceNumber> Predict(List<Record> sampleRecordsList, List<Record> validationRecordsList)
        {
            var resultsList = new List<DistanceNumber>();

            for (var i=0; i < validationRecordsList.Count; i++)
            {
                var closestMatch = sampleRecordsList.AsParallel().Select(r =>
                {
                    DistanceNumber distanceNumber = new DistanceNumber()
                    {
                        Number = r.Number,
                        DistanceToNumber = Distance.GetDistance(r.Pixels, validationRecordsList.Skip(i).FirstOrDefault().Pixels)
                    };
                    return distanceNumber;

                }).OrderBy(g => g.DistanceToNumber).ToList().FirstOrDefault();

                resultsList.Add(closestMatch);
            }
            return resultsList;
        }
    }
}
