using Metroit.Mvvm.WinForms.Extensions;
using System;
using System.Linq.Expressions;

namespace Metroit.Windows.Forms.Mvvm.Extensions
{
    /// <summary>
    /// 日付ピッカーのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class MetDateTimePickerExtensions
    {
        /// <summary>
        /// 値をバインドします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dateTimePicker">MetDateTimePickerオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindValue<T>(this MetDateTimePicker dateTimePicker, Expression<Func<T>> expression)
        {
            PropertyBindExtensions.Bind(() => dateTimePicker.Value, expression, true);
        }
    }
}
