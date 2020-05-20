using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTutorial1
{
    public static class Utils
    {
        // take() will take the first n items from the source collection and return them as
        // a IEnumerable of T
        public static IEnumerable<T> Take<T>(IEnumerable<T> source, int n)
        {
            int i = 0; 

            
            foreach (var item in source)
            {
                // by using yield return telling CSharp to create an empty IEnumerable collection
                yield return item;

                if (++i == n)
                {
                    // signals MoveNext() to return false
                    yield break;
                }
            }
        }

        // constrain what T can be add a 'where' 
        // T must implement the IComparable interface
        // Generic Constraints on MSDN
        public static T Min<T>(T item1, T item2) where T : IComparable<T>
        {
            return (item1.CompareTo(item2) < 0) ? item1 : item2;
        }
    }
}
