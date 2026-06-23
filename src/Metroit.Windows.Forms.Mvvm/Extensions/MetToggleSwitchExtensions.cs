using System;
using System.Linq.Expressions;
using Metroit.Mvvm.WinForms.Extensions;

namespace Metroit.Windows.Forms.Mvvm.Extensions
{
    /// <summary>
    /// MetToggleSwitchのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class MetToggleSwitchExtensions
    {
        /// <summary>
        /// チェック状態をバインドします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toggleSwitch">トグルスイッチオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindChecked<T>(this MetToggleSwitch toggleSwitch, Expression<Func<T>> expression)
        {
            PropertyBindExtensions.Bind(() => toggleSwitch.Checked, expression);
        }
    }
}
