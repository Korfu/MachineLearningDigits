using MachineLearningDigits.Models;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearningDigits.Helpers
{
    public class CSVFormatter
    {
        public List<Record> FormatToRecordList(string[] csv)
        {
            var noHeadersArray = csv.Skip(1);
            var splittedRows = noHeadersArray.Select(e => e.Split(',').Select(x => int.Parse(x))).ToList();
            var recordsList = splittedRows.Select(r =>
            {
                Record newRecord = new Record()
                {
                    Number = r.First(),
                    Pixels = r.Skip(1).ToArray()
                };
                return newRecord;
            }).ToList();

            return recordsList;
        }
    }
}
