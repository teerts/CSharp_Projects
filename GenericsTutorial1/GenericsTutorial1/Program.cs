using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GenericsTutorial1.EnumerableCompositor;

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

            // params keyword in Create() allows us to pass in any number of 
            // "Lists" in this case of the same type instead of creating a new type of the <int> list
            // Caveat: only the last parameter of the method can have the params keyword
            // This static create method can create an instance of enumeratorcompositor without having to specify type or
            // using the "new" keyword 
            var ec = ECCreate(list1, list2, set1, array1);

            // loop thru all items in enumerable compositor
            // can be used for any common collections
            int numOdd = ec.Count(x => IsOdd(x));
        }
    }
}
