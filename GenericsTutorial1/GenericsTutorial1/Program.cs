using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTutorial1
{
    class Program
    {
        public static bool IsOdd(int value)
        {
            return value % 2 != 0; 
        }

        static void Main(string[] args)
        {
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<int> { 2, 4, 6, 8, 10 };
            var set1 = new HashSet<int> { 3, 6, 9, 12, 15 };
            var array1 = new[] { 4, 8, 12, 16, 20 };

            //// specify the type of item in <>; and then list the collections 
            //var ec = new EnumerableCompositor<int> { list1, list2, set1, array1 };

            //// loop thru all items in enumerable compositor
            //int numOdd = 0;

            //foreach(var value in ec)
            //{
            //    if (IsOdd(value))
            //    {
            //        numOdd++;
            //    }
            //}

            //int numOdd = ec.Count(x => IsOdd(x));
        }
    }
}
