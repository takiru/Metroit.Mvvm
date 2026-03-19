using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Extensions
{
    /// <summary>
    /// ツールストリップボタンのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class ToolStripButtonExtensions
    {
        /// <summary>
        /// チェック状態をバインドします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toolStripButton">ツールストリップボタンオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindChecked(this ToolStripButton toolStripButton, Expression<Func<bool>> expression)
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

            toolStripButton.CheckedChanged += (sender, e) => expressionProperty.SetValue(expressionObject, toolStripButton.Checked);
        }
    }
}
