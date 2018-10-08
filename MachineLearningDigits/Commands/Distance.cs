using System;
using System.Runtime.CompilerServices;

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
            return tempResult;
        }
    }
}
