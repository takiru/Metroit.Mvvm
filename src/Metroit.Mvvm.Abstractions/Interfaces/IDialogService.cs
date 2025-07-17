namespace Metroit.Mvvm.Abstractions.Interfaces
{
    /// <summary>
    /// ダイアログのサービスを提供します。
    /// </summary>
    public interface IDialogService<T, U> where T : IDialogRequest where U : IDialogResponse
    {
        /// <summary>
        /// ダイアログをモーダレスで表示します。
        /// </summary>
        void Show();

        /// <summary>
        /// ダイアログをモーダレスで表示します。
        /// </summary>
        /// <param name="request">リクエスト情報。</param>
        void Show(T request);

        /// <summary>
        /// ダイアログをモーダルで表示します。
        /// </summary>
        /// <returns>レスポンス情報。</returns>
        T ShowDialog();

        /// <summary>
        /// ダイアログをモーダルで表示します。
        /// </summary>
        /// <param name="request">リクエスト情報。</param>
        /// <returns>レスポンス情報。</returns>
        U ShowDialog(T request);
    }
}
