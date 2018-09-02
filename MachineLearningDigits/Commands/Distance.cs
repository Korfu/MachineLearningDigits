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
            //1. punkty w tym samym miejscu
            //var x1 = a.First();
            //var y1 = b.First();
            //var x2 = a.Skip(1).First();
            //var y2 = b.Skip(1).First();

            //var result = (int)Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2);
            //return result;

            var tempResult = 0;
            for (var i = 0; i< a.Length; i++)
            {
                tempResult += (a[i] - b[i]) * (a[i] - b[i]);
            }
            var result = (int)Math.Sqrt(tempResult);
            //var x1 = 0;
            //var y1 = 0;
            //var z1 = 0;

            //var x2 = 0;
            //var y2 = 4;
            //var z2 = 3;

            //var result = (int)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1)* (y2 - y1) + (z2 - z1) * (z2 - z1));
            return result;


        }
    }
}
