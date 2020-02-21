using System;
using System.IO;
using System.Net.Sockets;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            // A stream is a sequence of bytes that you can use to read from and write to a backing store, 
            // which can be one of several storage mediums(for example, disks or memory). There are different
            // types of streams classes that enable you to use a stream with a specific backing store e.g. Filestream
            // will read and write to disk. 

            // The System.IO.Stream class is an abstract class that all other stream classes inherit from. 

            // Why use a stream? so a large file can be read/written to without waiting for the underlying storage to do its thing
            // It is split into chunks by the application first and then written to disk/network/memory 

            string aFile = @"C:\temp\test.txt";
            WriteAFile(aFile);

            void WriteAFile(string filename)
            {
                // Because streams work only with bytes, the helper classes like StreamWriter help convert text to and from bytes.
                // it is better to put it inside a using statement rather than calling sw.Close()
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    // see the underlying stream it is using
                    Console.WriteLine(sw.BaseStream.GetType());
                    // write to stream
                    sw.Write("Hello World");
                    // empty buffer and write to disk
                    sw.Flush();
                }

                // you can pass it an existing stream too rather than opening a new one by passing a file name
                FileStream fs = new FileStream(aFile, FileMode.Open);
                // if you look at the FileStream methods, they can only read and write bytes, hence the need for StreamWriter below.
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    // see the underlying stream it is using
                    Console.WriteLine(sw.BaseStream.GetType());
                    sw.Write("Hello World");
                    // empty buffer and write to disk
                    sw.Flush();
                }

                // you can use the File class to get a streamreader for a particular file
                StreamReader reader = new StreamReader(File.OpenRead(filename));
                Console.WriteLine( reader.ReadToEnd());

            }



            Console.ReadLine();
        }
    }
}
