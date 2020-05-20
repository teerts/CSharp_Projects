using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericsTutorial1
{
    // composed of many collections but loop thru items contained as one collection
    // collections like these are said to be "enumerable"

    // all collection types in dotnet implement IEnumerable interface 
    // Foreach loops can only be used for classes that implement the IEnumerable interface in CSharp    
    class EnumerableCompositor<T> : IEnumerable<T>
    {
        // change list to IEnumerable of T
        // need to add to this List but we are just storing references to the collections themselves
        private List<IEnumerable<T>> _collections;

        // collection initialize list
        public EnumerableCompositor()
        {
            _collections = new List<IEnumerable<T>>();
        }
        // passing in a bunch of collections into the constructor 
        // accept anything that implements the IEnumerable interface
        // generic types can be nested as seen in the constructor below
        // copy references to each collection that is passed in, instead of copying each item         
        public EnumerableCompositor(IEnumerable<IEnumerable<T>> collections)
        {
            // using LINQ functions
            _collections = collections.ToList();
        }

        public void Add(IEnumerable<T> collection)
        {
            _collections.Add(collection);
        }
        // generic implementation of the interface
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
