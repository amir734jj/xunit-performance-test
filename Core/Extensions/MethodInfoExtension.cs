using System.Linq;
using System.Reflection;

namespace XunitPerformanceTest.Extensions
{
    internal static class MethodInfoExtension
    {
        public static bool AreMethodsEqualForDeclaringType(this MethodInfo first, MethodInfo second)
        {
            var (rt1, rt2) = (first.ReturnType, second.ReturnType);
            var (args1, arg2) = (first.GetParameters(), second.GetParameters());

            var c1 = rt1 == rt2;
            var c2 = args1.Zip(arg2, (a, b) => (a, b))
                .Aggregate(true,
                    (accu, tuple) => accu && tuple.Item1.ParameterType == tuple.Item2.ParameterType);

            var (n1, n2) = (first.Name, second.Name);
            var c3 = n1.Contains(n2) || n2.Contains(n1);

            return c1 && c2 && c3;
        }
    }
}