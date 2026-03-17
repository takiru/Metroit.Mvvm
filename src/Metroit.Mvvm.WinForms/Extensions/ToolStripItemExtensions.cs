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
    }
}
