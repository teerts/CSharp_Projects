using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsTutorial1
{
    // composed of many collections but loop thru items contained as one collection
    // collections like these are said to be "enumerable"

    // all collection types in dotnet implement IEnumerable interface 
    // Foreach loops can only be used for classes that implement the IEnumerable interface in CSharp    
    class EnumerableCompositor<T> : IEnumerable<T>
    {
        // generic implementation
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // non-generic explicitly implemented: no access modifier and accesses IEnumerable
        // return type is different therefore its explicitly cast 
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
