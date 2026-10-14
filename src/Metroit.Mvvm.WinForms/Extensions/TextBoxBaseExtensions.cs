using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Extensions
{
    /// <summary>
    /// テキストボックスのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class TextBoxBaseExtensions
    {
        /// <summary>
        /// 読み取り専用をバインドします。
        /// </summary>
        /// <param name="textBox">テキストボックスオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        /// <param name="format">コントロールのプロパティがデータ値にバインドされたときに発生します。</param>
        public static void BindReadOnly<T>(this TextBoxBase textBox, Expression<Func<T>> expression,
            ConvertEventHandler format = null)
        {
            if (format == null)
            {
                PropertyBindExtensions.Bind(() => textBox.ReadOnly, expression);
            }
            else
            {
                PropertyBindExtensions.Bind(() => textBox.ReadOnly, expression, true, format);
            }

        }
    }
}
