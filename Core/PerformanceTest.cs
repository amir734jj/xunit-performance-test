using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using XunitPerformanceTest.Interfaces;
using XunitPerformanceTest.Utilities;
using static XunitPerformanceTest.Constants.Connection;

namespace XunitPerformanceTest
{
    public abstract class PerformanceTest<TClass> : IPerformanceTest<TClass> where TClass : class
    {
        /// <summary>
        /// Benchmark(Test__Benchmark, ...);
        /// </summary>
        /// <param name="method"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public TimeSpan Benchmark(Action method, Action action)
        {
            return ResolveBenchmark(action.Method, action);
        }
        
        /// <summary>
        /// Benchmark(x => x.Test__Benchmark(), ...);
        /// </summary>
        /// <param name="method"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public TimeSpan Benchmark(Expression<Action<TClass>> method, Action action)
        {
            return ResolveBenchmark(new MethodInfoHelper(method).MethodInfo, action);
        }

        /// <summary>
        /// Benchmark(x => x.Test__Benchmark, ...);
        /// </summary>
        /// <param name="method"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public TimeSpan Benchmark(Expression<Func<TClass, Action>> method, Action action)
        {
            return ResolveBenchmark(new MethodInfoHelper(method).MethodInfo, action);
        }

        /// <summary>
        /// Sync benchmark
        /// </summary>
        /// <param name="method"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private static TimeSpan ResolveBenchmark(MethodInfo method, Action action)
        {
            // Instantiate the StopWatch
            var sw = new Stopwatch();
            
            // Start the StopWatch
            sw.Start();

            // Run the action
            action();
            
            // Stop the StopWatch
            sw.Stop();

            // Store the result
            Table[method] = sw.Elapsed;

            // Return the elapsed time
            return sw.Elapsed;
        }
    }
}