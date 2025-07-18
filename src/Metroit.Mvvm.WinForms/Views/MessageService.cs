using Metroit.Mvvm.Interfaces;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Views
{
    /// <summary>
    /// メッセージのサービスを提供します。
    /// </summary>
    public class MessageService : IMessageService<DialogResultType>
    {
        /// <summary>
        /// メッセージを表示するオーナーを取得します。
        /// </summary>
        public Func<object> OwnerFormProvider { get; set; }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmOkCancel(string message)
        {
            return ConfirmOkCancel(message, GetOwnerTitle(), MessageBoxDefaultButtonType.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmOkCancel(string message, MessageBoxDefaultButtonType defaultButton)
        {
            return ConfirmOkCancel(message, GetOwnerTitle(), defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmOkCancel(string message, string title)
        {
            return ConfirmOkCancel(message, title, MessageBoxDefaultButtonType.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmOkCancel(string message, string title, MessageBoxDefaultButtonType defaultButton)
        {
            return WinFormsDialogResultToGeneralDialogResult(MessageBox.Show(message, title,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                GeneralDefaultButtonToWinFormsDefaultButton(defaultButton)));
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNo(string message)
        {
            return ConfirmYesNo(message, GetOwnerTitle(), MessageBoxDefaultButtonType.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNo(string message, MessageBoxDefaultButtonType defaultButton)
        {
            return ConfirmYesNo(message, GetOwnerTitle(), defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNo(string message, string title)
        {
            return ConfirmYesNo(message, title, MessageBoxDefaultButtonType.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNo(string message, string title, MessageBoxDefaultButtonType defaultButton)
        {
            return WinFormsDialogResultToGeneralDialogResult(MessageBox.Show(message, title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                GeneralDefaultButtonToWinFormsDefaultButton(defaultButton)));
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNoCancel(string message)
        {
            return ConfirmYesNoCancel(message, GetOwnerTitle(), MessageBoxDefaultButtonType.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNoCancel(string message, MessageBoxDefaultButtonType defaultButton)
        {
            return ConfirmYesNoCancel(message, GetOwnerTitle(), defaultButton);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNoCancel(string message, string title)
        {
            return ConfirmYesNoCancel(message, title, MessageBoxDefaultButtonType.Button1);
        }

        /// <summary>
        /// 確認メッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="title">タイトル。</param>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns>指示結果。</returns>
        public DialogResultType ConfirmYesNoCancel(string message, string title, MessageBoxDefaultButtonType defaultButton)
        {
            return WinFormsDialogResultToGeneralDialogResult(MessageBox.Show(message, title,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                GeneralDefaultButtonToWinFormsDefaultButton(defaultButton)));
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public void Error(string message)
        {
            Error(message, GetOwnerTitle());
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
            Information(message, GetOwnerTitle());
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
            Warning(message, GetOwnerTitle());
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

        /// <summary>
        /// オーナーのタイトルを取得する。
        /// </summary>
        /// <returns></returns>
        private string GetOwnerTitle()
        {
            var owner = (Form)OwnerFormProvider?.Invoke();
            return owner?.Text ?? FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;
        }
        /// <summary>
        /// WinFormsの既定のボタンを取得する。
        /// </summary>
        /// <param name="defaultButton">既定のボタン。</param>
        /// <returns></returns>
        private MessageBoxDefaultButton GeneralDefaultButtonToWinFormsDefaultButton(MessageBoxDefaultButtonType defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButtonType.Button1:
                    return MessageBoxDefaultButton.Button1;

                case MessageBoxDefaultButtonType.Button2:
                    return MessageBoxDefaultButton.Button2;

                case MessageBoxDefaultButtonType.Button3:
                    return MessageBoxDefaultButton.Button3;

#if NET6_0_OR_GREATER
                case MessageBoxDefaultButtonType.Button4:
                    return MessageBoxDefaultButton.Button4;
#endif

                default:
                    return MessageBoxDefaultButton.Button1;

            }
        }

        /// <summary>
        /// WinFormsのDialogResultを一般的なDialogResultに変換する。
        /// </summary>
        /// <param name="dialogResult">WinFormsのDialogResult。</param>
        /// <returns></returns>
        private DialogResultType WinFormsDialogResultToGeneralDialogResult(DialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case DialogResult.None:
                    return DialogResultType.None;

                case DialogResult.OK:
                    return DialogResultType.OK;

                case DialogResult.Cancel:
                    return DialogResultType.Cancel;

                case DialogResult.Abort:
                    return DialogResultType.Abort;

                case DialogResult.Retry:
                    return DialogResultType.Retry;

                case DialogResult.Ignore:
                    return DialogResultType.Ignore;

                case DialogResult.Yes:
                    return DialogResultType.Yes;

                case DialogResult.No:
                    return DialogResultType.No;

                default:
                    return DialogResultType.None;
            }
        }
    }
}
