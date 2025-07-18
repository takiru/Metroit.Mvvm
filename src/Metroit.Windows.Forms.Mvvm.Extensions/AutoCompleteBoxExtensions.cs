using System;
using System.Linq.Expressions;

namespace Metroit.Windows.Forms.Mvvm.Extensions
{
    /// <summary>
    /// オートコンプリートボックスのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class AutoCompleteBoxExtensions
    {
        /// <summary>
        /// データソースをバインドします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="autoCompleteBox">オートコンプリートボックスオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindDataSource<T>(this AutoCompleteBox autoCompleteBox, Expression<Func<T>> expression)
        {
            PropertyBindExtensions.Bind(() => autoCompleteBox.DataSource, expression);
        }
    }
}
