using Metroit.Mvvm.Abstractions.Interfaces;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Views
{
    /// <summary>
    /// メッセージのサービスを提供します。
    /// </summary>
    public class MessageService : IMessageService<DialogResult>
    {
        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmOkCancel(string message)
        {
            return ConfirmOkCancel(message, Form.ActiveForm.Text, (int)MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmOkCancel(string message, int defaultButton)
        {
            return ConfirmOkCancel(message, Form.ActiveForm.Text, defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmOkCancel(string message, string title)
        {
            return ConfirmOkCancel(message, title, (int)MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmOkCancel(string message, string title, int defaultButton)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, (MessageBoxDefaultButton)defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNo(string message)
        {
            return ConfirmYesNo(message, Form.ActiveForm.Text, (int)MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNo(string message, int defaultButton)
        {
            return ConfirmYesNo(message, Form.ActiveForm.Text, defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNo(string message, string title)
        {
            return ConfirmYesNo(message, title, (int)MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNo(string message, string title, int defaultButton)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, (MessageBoxDefaultButton)defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNoCancel(string message)
        {
            return ConfirmYesNoCancel(message, Form.ActiveForm.Text, (int)MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNoCancel(string message, int defaultButton)
        {
            return ConfirmYesNoCancel(message, Form.ActiveForm.Text, defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNoCancel(string message, string title)
        {
            return ConfirmYesNoCancel(message, title, (int)MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResult ConfirmYesNoCancel(string message, string title, int defaultButton)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, (MessageBoxDefaultButton)defaultButton);
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Error(string message)
        {
            Error(message, Form.ActiveForm.Text);
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        public void Error(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 情報メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Information(string message)
        {
            Information(message, Form.ActiveForm.Text);
        }

        /// <summary>
        /// 情報メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        public void Information(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 警告メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Warning(string message)
        {
            Warning(message, Form.ActiveForm.Text);
        }

        /// <summary>
        /// 警告メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        public void Warning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
