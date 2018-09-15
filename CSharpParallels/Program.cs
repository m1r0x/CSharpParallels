using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpParallels
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Synchrone Berechnung ist gestartet");
            var watch = Stopwatch.StartNew();
            SerialTest();
            watch.Stop();
            var elapsedSerial = watch.ElapsedMilliseconds;
            Console.WriteLine("Synchrone Berechnung ist beendet");
            Console.WriteLine("Dauer der Ausführung: " + elapsedSerial);
            watch.Reset();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Parallele Berechnung ist gestartet");
            watch.Start();
            ParallelTest();
            watch.Stop();
            var elapsedParallel = watch.ElapsedMilliseconds;
            Console.WriteLine("Parallele Berechnung ist beendet");
            Console.WriteLine("Dauer der Ausführung: " + elapsedParallel);
            watch.Reset();
            Console.ReadKey();
        }

        static void SerialTest()
        {
            double[] arr = new double[50000000];
            for (int i = 0; i < 50000000; i++)
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
        }

        static void ParallelTest()
        {
            double[] arr = new double[50000000];
            Parallel.For(0, 50000000, i =>
            {
                arr[i] = Math.Pow(i, 0.333) * Math.Sqrt(Math.Sin(i));
            });
        }
    }
}
