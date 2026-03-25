using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Input;

namespace Metroit.Mvvm.WinForms.Extensions
{
    /// <summary>
    /// ツールストリップアイテムのバインドを行う拡張メソッドを提供します。
    /// </summary>
    public static class ToolStripItemExtensions
    {
        /// <summary>
        /// クリックをバインドします。
        /// </summary>
        /// <param name="toolStripItem">ツールストリップアイテムオブジェクト。</param>
        /// <param name="command">コマンド。</param>
        public static void BindClick(this ToolStripItem toolStripItem, ICommand command)
        {
#if NET7_0_OR_GREATER
            toolStripItem.Command = command;
#else
            command.CanExecuteChanged += (sender, args) => toolStripItem.Enabled = command.CanExecute(null);
            toolStripItem.Click += (sender, args) => command.Execute(null);

            // 初期状態を決定
            toolStripItem.Enabled = command.CanExecute(null);
#endif
        }

        /// <summary>
        /// 活性状態をバインドします。
        /// </summary>
        /// <typeparam name="T">バインドする型。</typeparam>
        /// <param name="toolStripItem">ツールストリップアイテムオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindEnabled<T>(this ToolStripItem toolStripItem, Expression<Func<T>> expression)
        {
            var expressionInfo = ExpressionAnalyzer.GetExpressionInfo(expression);

            // UI -> VM
            toolStripItem.EnabledChanged += (sender, e) => expressionInfo.Info.SetValue(expressionInfo.Value, toolStripItem.Enabled);

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
                    if (toolStripItem.Enabled != newValue)
                    {
                        toolStripItem.Enabled = newValue;
                    }
                };
            }

            // 初期値をVMから反映
            toolStripItem.Enabled = (bool)expressionInfo.Info.GetValue(expressionInfo.Value);
        }

        /// <summary>
        /// 表示状態をバインドします。
        /// </summary>
        /// <typeparam name="T">バインドする型。</typeparam>
        /// <param name="toolStripItem">ツールストリップアイテムオブジェクト。</param>
        /// <param name="expression">バインドする値の式木。</param>
        public static void BindVisible<T>(this ToolStripItem toolStripItem, Expression<Func<T>> expression)
        {
            var expressionInfo = ExpressionAnalyzer.GetExpressionInfo(expression);

            // UI -> VM
            toolStripItem.VisibleChanged += (sender, e) => expressionInfo.Info.SetValue(expressionInfo.Value, toolStripItem.Visible);

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
                    if (toolStripItem.Visible != newValue)
                    {
                        toolStripItem.Visible = newValue;
                    }
                };
            }

            // 初期値をVMから反映
            toolStripItem.Visible = (bool)expressionInfo.Info.GetValue(expressionInfo.Value);
        }
    }
}
