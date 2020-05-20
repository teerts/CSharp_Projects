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
            var ec = new EnumerableCompositor<int> {list1, list2, set1, array1};


            // loop thru all items in enumerable compositor
            int numOdd = 0;

            foreach (var value in ec)
            {
                if (IsOdd(value))
                {
                    numOdd++;
                }
            }

            //int numOdd = ec.Count(x => IsOdd(x));

            // although the Take method has been called on this line
            // the firstThree does not contain anything cause of Enumerators
            // until the foreach loop runs that the body of the Take() method is executed
            // this is true for all methods that use the yield keyword
            // this is called Lazy Evaluation and the items in the collection are not retrieved until needed
            // yield provides data just in time (JIT)
            IEnumerable<int> firstThree = Utils.Take<int>(list1, 3);
            
            // loop thru first 3 in collection            
            foreach (var item in firstThree)
            {

            }
        }
    }
}
