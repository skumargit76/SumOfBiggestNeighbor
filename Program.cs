using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfBiggestNeighbor
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            int[] arr = new int[] { 1, 6, 1, 2, 6, 1, 6, 6 };
            int SumOfNeighbor = obj.Challenge(arr);
            Console.WriteLine("the biggest combination of neighbor element that can be found is {0}", SumOfNeighbor);
            Console.ReadLine();

        }
        //static  int GetSumBiggestNeighbor(int[] arr)
        public int Challenge(int[] input)
        {
            //***********************************************
            //to get max value of count
            //and to get filtered list of element by m-1
            //***********************************************

            int result = 0;
            //convert to list
            List<int> lstArr = input.ToList();
            //get M 
            var M = lstArr.GroupBy(x => x).Max(y => y.Count());
            // Main logic : filter list by >= m-1 
            var R = ((from x in lstArr.GroupBy(x => x)
                      where x.Count() >= M - 1
                      select (x.Key)).ToList());
            // filter list by another list
            var filteredLst = lstArr.Where(x => R.Any(y => x == y)).ToArray();
            //sort list in descending order 
            Array.Sort(filteredLst);
            Array.Reverse(filteredLst);
            //
            for (int i = 0; i < 2; i++)
            {
                result += filteredLst[i];
            }
            return result;
        }
    }
}
