using Metroit.Mvvm.WinForms.Extensions;
using System;
using System.Linq.Expressions;

namespace Metroit.Windows.Forms.Mvvm.Extensions
{
    /// <summary>
    /// 数値入力テキストボックスのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class MetNumericTextBoxExtensions
    {
        /// <summary>
        /// 値をバインドします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numericTextBox">MetNumericTextBoxオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindValue<T>(this MetNumericTextBox numericTextBox, Expression<Func<T>> expression)
        {
            PropertyBindExtensions.Bind(() => numericTextBox.Value, expression, true);
        }
    }
}
