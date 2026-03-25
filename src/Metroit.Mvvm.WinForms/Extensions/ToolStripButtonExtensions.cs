using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
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
        /// <typeparam name="T">バインドする型。</typeparam>
        /// <param name="toolStripButton">ツールストリップボタンオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindChecked<T>(this ToolStripButton toolStripButton, Expression<Func<T>> expression)
        {
            var expressionInfo = ExpressionAnalyzer.GetExpressionInfo(expression);

            // UI -> VM
            toolStripButton.CheckedChanged += (sender, e) => expressionInfo.Info.SetValue(expressionInfo.Value, toolStripButton.Checked);

            // VM -> UI
            if (expressionInfo.Value is INotifyPropertyChanged notifyObject)
            {
                notifyObject.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName != expressionInfo.Info.Name)
                    {
                        return;
                    }

                    var newValue = (bool)expressionInfo.Info.GetValue(expressionInfo.Value);
                    if (toolStripButton.Checked != newValue)
                    {
                        toolStripButton.Checked = newValue;
                    }
                };
            }

            // 初期値をVMから反映
            toolStripButton.Checked = (bool)expressionInfo.Info.GetValue(expressionInfo.Value);
        }
    }
}
