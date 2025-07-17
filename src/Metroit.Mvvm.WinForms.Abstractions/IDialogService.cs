using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Abstractions
{
    /// <summary>
    /// ダイアログのサービスを提供します。
    /// </summary>
    public interface IDialogService : Mvvm.Abstractions.IDialogService
    {
        /// <summary>
        /// ダイアログをモーダレスで表示します。
        /// </summary>
        /// <typeparam name="T">フォームの型。</typeparam>
        /// <param name="windowKey">識別キー。</param>
        void Show<T>(string windowKey) where T : Form;

        /// <summary>
        /// ダイアログをモーダレスで表示します。
        /// </summary>
        /// <typeparam name="T">フォームの型。</typeparam>
        /// <typeparam name="U">リクエスト情報の型。</typeparam>
        /// <param name="windowKey">識別キー。</param>
        /// <param name="request">リクエスト情報。</param>
        void Show<T, U>(string windowKey, U request) where T : Form;

        /// <summary>
        /// ダイアログをモーダルで表示します。
        /// </summary>
        /// <typeparam name="T">レスポンス情報の型。</typeparam>
        /// <param name="windowKey">識別キー。</param>
        /// <returns>レスポンス情報。</returns>
        T ShowDialog<T>(string windowKey) where T : class;

        /// <summary>
        /// ダイアログをモーダルで表示します。
        /// </summary>
        /// <typeparam name="T">リクエスト情報の型。</typeparam>
        /// <typeparam name="U">レスポンス情報の型。</typeparam>
        /// <param name="windowKey">識別キー。</param>
        /// <param name="request">リクエスト情報。</param>
        /// <returns>レスポンス情報。</returns>
        U ShowDialog<T, U>(string windowKey, T request) where U : class;

        void ShowDialog<T>() where T : Form;
    }
}
