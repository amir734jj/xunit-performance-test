using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace XunitPerformanceTest.Constants
{
    internal static class Connection
    {
        public static ConcurrentDictionary<MethodInfo, TimeSpan> Table;

        /// <summary>
        /// Ensure that table exisit
        /// </summary>
        public static void Ensure()
        {
            Table = new ConcurrentDictionary<MethodInfo, TimeSpan>();
        }

        /// <summary>
        /// Dispose the table
        /// </summary>
        public static void Dispose()
        {
            Table = null;
        }
    }
}