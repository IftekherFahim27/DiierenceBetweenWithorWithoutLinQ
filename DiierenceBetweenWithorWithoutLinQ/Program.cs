using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace LinqVsLoopBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Run  benchmark
            var summary = BenchmarkRunner.Run<BenchmarkTest>();
        }
    }

    [MemoryDiagnoser] // Shows memory allocation info
    public class BenchmarkTest
    {
        private List<int> numbers;

        [GlobalSetup]
        public void Setup()
        {
            // Generate 1 million random numbers
            var rand = new Random();
            numbers = Enumerable.Range(0, 1_000_000)
                                .Select(_ => rand.Next(1, 1000))
                                .ToList();
        }

        [Benchmark]
        public List<int> WithLinq()
        {
            // Using LINQ to filter even numbers > 500
            return numbers.Where(n => n % 2 == 0 && n > 500).ToList();
        }

        [Benchmark]
        public List<int> WithoutLinq()
        {
            // Using traditional foreach loop
            var result = new List<int>();
            foreach (var n in numbers)
            {
                if (n % 2 == 0 && n > 500)
                {
                    result.Add(n);
                }
            }
            return result;
        }
    }
}
