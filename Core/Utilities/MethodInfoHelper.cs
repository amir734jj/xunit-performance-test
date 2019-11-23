using System.Linq.Expressions;
using System.Reflection;
using Xunit.Sdk;

namespace XunitPerformanceTest.Utilities
{
    internal sealed class MethodInfoHelper : ExpressionVisitor
    {
        private readonly Expression _expression;

        private MethodInfo _methodInfo;

        /// <summary>
        ///     Returns the MethodInfo
        /// </summary>
        public MethodInfo MethodInfo =>  _methodInfo == null  ? throw new NullException($"Failed to find the MethodInfo in: {_expression}")  : _methodInfo;

        /// <summary>
        /// Constructor that takes expression to visit
        /// </summary>
        /// <param name="expression"></param>
        public MethodInfoHelper(Expression expression)
        {
            _expression = expression;

            // Start the visit
            Visit(expression);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            _methodInfo = node.Method;

            return base.VisitMethodCall(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value is MethodInfo methodInfo)
            {
                _methodInfo = methodInfo;
            }
            
            return base.VisitConstant(node);
        }
    }
}