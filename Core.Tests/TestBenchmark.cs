using System;
using System.Threading.Tasks;
using Core.Attributes;
using Xunit;

namespace Core.Tests
{
    public class TestBenchmark : PerformanceTest<TestBenchmark>
    {
        [Fact]
        [Trace(0, 2)]
        public void Test__Benchmark1()
        {
            Benchmark(Test__Benchmark1, () => Task.Delay(TimeSpan.Zero).Wait());
        }

        [Fact]
        [Trace(0, 2)]
        public void Test__Benchmark2()
        {
            Benchmark(x => x.Test__Benchmark2, () => Task.Delay(TimeSpan.Zero).Wait());
        }

        [Fact]
        [Trace(0, 2)]
        public void Test__Benchmark3()
        {
            Benchmark(x => Test__Benchmark3(), () => Task.Delay(TimeSpan.Zero).Wait());
        }
    }
}