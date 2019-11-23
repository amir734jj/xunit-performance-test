using System;
using System.Linq.Expressions;

namespace XunitPerformanceTest.Interfaces
{
    public interface IPerformanceTest<TClass> where TClass : class
    {
        TimeSpan Benchmark(Action method, Action action);

        TimeSpan Benchmark(Expression<Action<TClass>> method, Action action);

        TimeSpan Benchmark(Expression<Func<TClass, Action>> method, Action action);
    }
}