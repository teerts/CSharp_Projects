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

            // list collections
            // these collections will be copied into the list for EnumerableCompositor instance not the items within them
            // EnumerableCompositor simply stores references to these collections
            // IF a item gets added to list1 then it will automatically get added to list1 in the Enumerable Compositor instance
            // composed of a bunch of enumerables; implements IEnumerable so we can use foreach loops to enumerate thru them
            // enumerators are sometimes called iterators
            var ec = new EnumerableCompositor<int>(new IEnumerable<int>[]
            {
                list1, list2, set1, array1
            });
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
