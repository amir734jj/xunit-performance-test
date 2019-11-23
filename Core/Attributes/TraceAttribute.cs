using System;
using System.Linq;
using System.Reflection;
using Core.Extensions;
using Xunit;
using Xunit.Sdk;
using static Core.Constants.Connection;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TraceAttribute : BeforeAfterTestAttribute
    {
        private readonly int _min;

        private readonly int _max;

        /// <summary>
        /// Takes only maximum seconds
        /// </summary>
        /// <param name="max"></param>
        public TraceAttribute(int max) : this(0, max) { }

        /// <summary>
        /// Takes minimum and maximum
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public TraceAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Do nothing ...
        /// </summary>
        /// <param name="methodUnderTest"></param>
        public override void Before(MethodInfo methodUnderTest)
        {
            // Ensure table exist
            Ensure();
        }

        /// <summary>
        /// After the test assert the benchmark
        /// </summary>
        /// <param name="methodUnderTest"></param>
        public override void After(MethodInfo methodUnderTest)
        {
            Assert.InRange(Table.First(x => x.Key.AreMethodsEqualForDeclaringType(methodUnderTest)).Value.Seconds, _min, _max);
            
            // Dispose the dictionary
            Dispose();
        }
    }
}