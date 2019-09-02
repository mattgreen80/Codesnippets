using System;

namespace Closures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action is a delegate for a method that has no parameters and returns no value. If you had a single param it would be Action<T>.
            Action a = GiveMeAction();
            a();
            a();

        }
        // A closure takes the form of an in-line delegate/anonymous method. A closure is attached to its parent method meaning that variables 
        // defined in parent's method body can be referenced from within the anonymous method.
        static Action GiveMeAction()
        {
            Action ret = null;
            int i = 0;
            // A lambda that takes no value() and returns the string and the incremented i variable. Notice that this is a closure because 
            // i is incremented by methods that technically should not see i because it is referenced in the parent method. 
            ret += () =>
            {
                Console.WriteLine("First Method " + i++);
            };
            ret += () =>
            {
                Console.WriteLine("Second Method " + i++);
            };
            // Even though you are technically returning something here when you used Action, it is a chain of methods that return nothing (i.e. a chain of delegates)
            return ret;
        }
    }
}
