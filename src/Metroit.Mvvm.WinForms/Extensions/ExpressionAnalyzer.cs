using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Metroit.Mvvm.WinForms.Extensions
{
    /// <summary>
    /// 式木を分析する操作を提供します。
    /// </summary>
    internal class ExpressionAnalyzer
    {
        /// <summary>
        /// バインドする値の式木から、プロパティと値を求めます。
        /// </summary>
        /// <typeparam name="T">値の型。</typeparam>
        /// <param name="expression">バインドする式木。</param>
        /// <returns>プロパティと値。</returns>
        /// <exception cref="ArgumentException">式木に問題があるか、式木からメンバーが取得できません。</exception>
        public static (PropertyInfo Info, object Value) GetExpressionInfo<T>(Expression<Func<T>> expression)
        {
            var lambda = expression as LambdaExpression;
            if (lambda == null)
            {
                throw new ArgumentException("There is an error in your lambda expression.");
            }
            var property = lambda.Body as MemberExpression;
            if (property == null)
            {
                throw new ArgumentException("It was not possible to obtain a member from a lambda expression.");
            }
            var parent = property.Expression;
            var expressionObjectInfo = (Object: Expression.Lambda(parent).Compile().DynamicInvoke(), property.Member.Name);

            var expressionObject = expressionObjectInfo.Object;
            var expressionProperty = expressionObject.GetType().GetProperty(expressionObjectInfo.Name);

            return (expressionProperty, expressionObject);
        }
    }
}
