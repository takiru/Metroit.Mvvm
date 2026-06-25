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
        public static void BindReadOnly<T>(this TextBoxBase textBox, Expression<Func<T>> expression)
        {
            PropertyBindExtensions.Bind(() => textBox.ReadOnly, expression);
        }
    }
}
