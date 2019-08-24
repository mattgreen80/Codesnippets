using System;

namespace Delegates
{
    // the purpose of a delegate is to be able to pass methods around like variables. 
    class Program
    {
        // a custom delegate. a delegate defines the signature of the method that it will relate to. 
        public delegate int MyDelegate(int i);

        //Note: var is used because it will interpret the type from what is passed to it. 

        static void Main(string[] args)
        {
            // regular method call
            var b = NormalMethod(5);
            // a delegate variable holding the NormalMethod created below (an instance of the delegate). 
            // Note the delegate definition above matches the method signature. 
            var normalMethodDelegate = new MyDelegate(NormalMethod);
            // call the method in the delegate variable and store the result in another variable
            var normalMethodResult = normalMethodDelegate(3);
            // pass the delegate instance to another method, then store the result in a variable
            var anotherMethodResult = RunAnotherMethod(normalMethodDelegate, 4);

            // Anonymous method - a way to shorten the process
            // instead of having to do line 19 (make method and then new it up)
            // you just define the method in line like this. 
            MyDelegate anonymousMethodDelegate = delegate (int i) { return i * 2; };
            var anonymousMethodResult = anonymousMethodDelegate(3);

            // Lambda expression
            // they will return a delegate
            // an even shorter way to do the above. pass in i => return the result of this expression.
            MyDelegate lambdaDelegate = i => i * 2;
        }


        // Just a basic method
        public static int NormalMethod(int i)
        {
            return i * 2;
        }

        // in C# you cant pass another method as a variable like this, you need to make a delegate

        //public static int RunAnotherMethod (NormalMethod normal)
        //{
        //   return whatever;
        //}

        // now you can pass another method to the function like a variable by using a parameter of type MyDelegate
        public static int RunAnotherMethod (MyDelegate aDelegateInstance, int i)
        {
            // return the result of the delegate function passed in, with the integer passed in.
            return aDelegateInstance(i);
        }
    }
}
