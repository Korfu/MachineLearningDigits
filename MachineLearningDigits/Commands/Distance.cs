using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningDigits.Commands
{
    public static class Distance
    {
        public static int GetDistance(int[] a,int[] b)
        {
            var tempResult = 0;
            for (var i = 0; i< a.Length; i++)
            {
                tempResult += (a[i] - b[i]) * (a[i] - b[i]);
            }
            var result = (int)Math.Sqrt(tempResult);

            return result;
        }
    }
}
