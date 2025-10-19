using Metroit.Contracts;

namespace Metroit.Mvvm.Interfaces
{
    /// <summary>
    /// ダイアログのサービスを提供します。
    /// </summary>
    public interface IDialogService
    {
        ///// <summary>
        ///// ダイアログをモーダレスで表示します。
        ///// </summary>
        ///// <param name="windowKey">識別キー。</param>
        //void Show(string windowKey);

        ///// <summary>
        ///// ダイアログをモーダレスで表示します。
        ///// </summary>
        ///// <param name="windowKey">識別キー。</param>
        ///// <param name="request">リクエスト情報。</param>
        //void Show<T>(string windowKey, T request);

        ///// <summary>
        ///// ダイアログをモーダルで表示します。
        ///// </summary>
        ///// <param name="windowKey">識別キー。</param>
        ///// <returns>レスポンス情報。</returns>
        //T ShowDialog<T>(string windowKey);

        ///// <summary>
        ///// ダイアログをモーダルで表示します。
        ///// </summary>
        ///// <param name="windowKey">識別キー。</param>
        ///// <param name="request">リクエスト情報。</param>
        ///// <returns>レスポンス情報。</returns>
        //T2 ShowDialog<T1, T2>(string windowKey, T1 request);



        /// <summary>
        /// リクエストなし、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void Show<T>() where T : Form, new();

        /// <summary>
        /// リクエストあり、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        void Show<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストなし、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void ShowDialog<T>() where T : Form, new();

        /// <summary>
        /// リクエストあり、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        void ShowDialog<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストなし、レスポンスありモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        T2 ShowDialog<T1, T2>() where T1 : Form, IDialogResponse<T2>, new();

        /// <summary>
        /// リクエストあり、レスポンスありモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : Form, IDialogRequest<T2>, IDialogResponse<T3>, new();
    }
}
