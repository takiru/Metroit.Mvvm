using Metroit.Mvvm.WinForms.ViewModels;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Views
{
    /// <summary>
    /// メイン画面の操作を提供します。
    /// </summary>
    public class ViewBase : Form
    {
        /// <summary>
        /// ViewModel を取得します。
        /// </summary>
        protected ViewModelBase ViewModel { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public ViewBase() : base()
        {

        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="viewModel">ViewModel。</param>
        public ViewBase(ViewModelBase viewModel) : base()
        {
            ViewModel = viewModel;

            ViewModel.MessageProvider.ExecuteInformationMessage = message =>
            {
                MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            ViewModel.MessageProvider.ExecuteConfirmMessage = (message, buttons) =>
            {
                return MessageBox.Show(message, Text, buttons, MessageBoxIcon.Question);
            };
            ViewModel.MessageProvider.ExecuteWarningMessage = message =>
            {
                MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
            ViewModel.MessageProvider.ExecuteErrorMessage = message =>
            {
                MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
