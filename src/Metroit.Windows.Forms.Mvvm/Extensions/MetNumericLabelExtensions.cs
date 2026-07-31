using Metroit.Mvvm.WinForms.Extensions;
using System;
using System.Linq.Expressions;

namespace Metroit.Windows.Forms.Mvvm.Extensions
{
    /// <summary>
    /// 数値ラベルのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class MetNumericLabelExtensions
    {
        /// <summary>
        /// 値をバインドします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numericLabel">MetNumericLabelオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindValue<T>(this MetNumericLabel numericLabel, Expression<Func<T>> expression)
        {
            PropertyBindExtensions.Bind(() => numericLabel.Value, expression, true);
        }
    }
}
