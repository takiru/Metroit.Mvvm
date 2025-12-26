using Metroit.Contracts;
using System;

namespace Metroit.Mvvm.Interfaces
{
    /// <summary>
    /// ダイアログのサービスを提供します。
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// 指定したダイアログが開かれているかどうかを取得します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        /// <returns>開かれている場合は true, それ以外は false を返却します。</returns>
        bool IsOpened<T>() where T : new();

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void Show<T>() where T : new();

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        void Show<T>(Func<object> ownerProvider) where T : new();

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        void Show<T1, T2>(T2 request) where T1 : IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        void Show<T1, T2>(T2 request, Func<object> ownerProvider) where T1 : new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void Activate<T>() where T : new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">ダイアログへ渡すパラメーターの型。</typeparam>
        /// <param name="param">パラメーター。</param>
        void ActivateWithAction<T1, T2>(T2 param) where T1 : IDialogActivateAction<T2>, new();

        /// <summary>
        /// モーダレスダイアログを閉じます。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void Close<T>();

        /// <summary>
        /// モーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void ShowDialog<T>() where T : new();

        /// <summary>
        /// リクエストを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        void ShowDialog<T1, T2>(T2 request) where T1 : IDialogRequest<T2>, new();

        /// <summary>
        /// レスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">レスポンス。</typeparam>
        /// <returns>レスポンス。</returns>
        T2 ShowDialog<T1, T2>() where T1 : IDialogResponse<T2>, new();

        /// <summary>
        /// リクエストとレスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <typeparam name="T3">レスポンス。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <returns>レスポンス。</returns>
        T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : IDialogRequest<T2>, IDialogResponse<T3>, new();
    }
}
