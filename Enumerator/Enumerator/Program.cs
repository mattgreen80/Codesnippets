using System;
using System.Collections;

// IEnumerable returns a IEnumerator, and that has the methods below. 
//
// IEnumerable
//      IEnumerator GetEnumerator()
// IEnumerator
//      bool MoveNext()
//      object Current;
//      void Reset()


namespace Enumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3, 4 };
            // in order for the foreach to work, the object in the foreach must implement IEnumerable 
            // this is because foreach will get an enumerator to perform the function of iterating over
            // the items in the object
            foreach (var item in array)
            {
                Console.WriteLine($"The number is {item}");
            }
            // this is actually what foreach does. The array implements IEnumerable so you can call GetEnumerator.
            IEnumerator enumertator = array.GetEnumerator();

            while (enumertator.MoveNext())
            {
                Console.WriteLine($"The number is {enumertator.Current}");
            }
        }
    }
}
