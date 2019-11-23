# xUnit-performance-test

Performance test the unit tests to make sure they run in certain time period. I wrote this package because I was tired of writing duplicate `StopWatch` code.

### Use
- In your unit test class `TClass`, extend the abstract class `PerformanceTest<TClass>`
- Add `Trace` attribute to pass minimum and maximum seconds that invocation should take
- Use a `Benchmark` method to pass method as:
    - `Action`
    - `Expression<Action<TClass>>`
    - `Expression<Func<TClass, Action>>`

### Example

```csharp
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
```
