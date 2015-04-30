using System;

namespace ConsoleApplication.DataStructures
{
    class InBuiltStructures
    {
        private System.Collections.Queue ticketQueue;
        private System.Collections.Stack functionStack;
        private int[] intArray;
        private System.Collections.ArrayList myArrayList; // Stores object of any type
        private System.Collections.Hashtable myHashTable;
        //Difference between Hashtable
        private System.Collections.Generic.Dictionary<int,InBuiltStructures> myDictionary;
        private System.Collections.Generic.IList<int> myArrayOfStronglyTypedObjects;
        private System.Collections.Generic.LinkedList<int> myLinkedList;
    }

    class ExplaingCollections
    {
        //Exposes an enumerator, which supports a simple iteration over a non-generic
        System.Collections.IEnumerable enumerable; //IEnumerator GetEnumerator();

        //     Supports a simple iteration over a non-generic collection. Current(), MoveNext() Reset()
        System.Collections.IEnumerator enumerator; // Doesn't implement any other interface

        //Defines size, enumerators, and synchronization methods for all nongeneric
        System.Collections.ICollection collection; // Implements IEnumerable

        //Provides functionality to evaluate queries against a specific data source
        //wherein the type of the data is not specified.
        System.Linq.IQueryable queryable; // Implements IEnumerable

        // Summary:
        //     Represents a non-generic collection of objects that can be individually accessed
        //     by index.
        System.Collections.IList iList;

        // Summary:
        //     Represents a strongly typed list of objects that can be accessed by index.
        //     Provides methods to search, sort, and manipulate lists.
        //
        //System.Collections.Generic.List<T> myList;
    }
}
