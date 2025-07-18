using Metroit.Mvvm.Abstractions.Interfaces;
using WinForm = System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Views
{
    /// <summary>
    /// メッセージのサービスを提供します。
    /// </summary>
    public class MessageService : IMessageService<WinForm.DialogResult>
    {
        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmOkCancel(string message)
        {
            return ConfirmOkCancel(message, WinForm.Form.ActiveForm.Text, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmOkCancel(string message, MessageBoxDefaultButton defaultButton)
        {
            return ConfirmOkCancel(message, WinForm.Form.ActiveForm.Text, defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmOkCancel(string message, string title)
        {
            return ConfirmOkCancel(message, title, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmOkCancel(string message, string title, MessageBoxDefaultButton defaultButton)
        {
            return WinForm.MessageBox.Show(message, title, WinForm.MessageBoxButtons.OKCancel,
                WinForm.MessageBoxIcon.Question, GetWinFormsDefaultButton(defaultButton));
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNo(string message)
        {
            return ConfirmYesNo(message, WinForm.Form.ActiveForm.Text, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNo(string message, MessageBoxDefaultButton defaultButton)
        {
            return ConfirmYesNo(message, WinForm.Form.ActiveForm.Text, defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNo(string message, string title)
        {
            return ConfirmYesNo(message, title, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNo(string message, string title, MessageBoxDefaultButton defaultButton)
        {
            return WinForm.MessageBox.Show(message, title, WinForm.MessageBoxButtons.YesNo,
                WinForm.MessageBoxIcon.Question, GetWinFormsDefaultButton(defaultButton));
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNoCancel(string message)
        {
            return ConfirmYesNoCancel(message, WinForm.Form.ActiveForm.Text, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNoCancel(string message, MessageBoxDefaultButton defaultButton)
        {
            return ConfirmYesNoCancel(message, WinForm.Form.ActiveForm.Text, defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNoCancel(string message, string title)
        {
            return ConfirmYesNoCancel(message, title, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public WinForm.DialogResult ConfirmYesNoCancel(string message, string title, MessageBoxDefaultButton defaultButton)
        {
            return WinForm.MessageBox.Show(message, title, WinForm.MessageBoxButtons.YesNoCancel,
                WinForm.MessageBoxIcon.Question, GetWinFormsDefaultButton(defaultButton));
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Error(string message)
        {
            Error(message, WinForm.Form.ActiveForm.Text);
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        public void Error(string message, string title)
        {
            WinForm.MessageBox.Show(message, title, WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Error);
        }

        /// <summary>
        /// 情報メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Information(string message)
        {
            Information(message, WinForm.Form.ActiveForm.Text);
        }

        /// <summary>
        /// 情報メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        public void Information(string message, string title)
        {
            WinForm.MessageBox.Show(message, title, WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 警告メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Warning(string message)
        {
            Warning(message, WinForm.Form.ActiveForm.Text);
        }

        /// <summary>
        /// 警告メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        public void Warning(string message, string title)
        {
            WinForm.MessageBox.Show(message, title, WinForm.MessageBoxButtons.OK, WinForm.MessageBoxIcon.Warning);
        }

        /// <summary>
        /// WinFormsの既定のボタンを取得する。
        /// </summary>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns></returns>
        private WinForm.MessageBoxDefaultButton GetWinFormsDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    return WinForm.MessageBoxDefaultButton.Button1;

                case MessageBoxDefaultButton.Button2:
                    return WinForm.MessageBoxDefaultButton.Button2;

                case MessageBoxDefaultButton.Button3:
                    return WinForm.MessageBoxDefaultButton.Button3;

#if NET6_0_OR_GREATER
                case MessageBoxDefaultButton.Button4:
                    return WinForm.MessageBoxDefaultButton.Button4;
#endif

                default:
                    return WinForm.MessageBoxDefaultButton.Button1;

            }
        }
    }
}
