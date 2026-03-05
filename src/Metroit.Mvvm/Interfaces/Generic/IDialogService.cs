using Metroit.Contracts;
using System;

namespace Metroit.Mvvm.Interfaces.Generic
{
    /// <summary>
    /// ダイアログのサービスを提供します。
    /// <typeparam name="TDialog">ダイアログ。</typeparam>
    /// </summary>
    public interface IDialogService<TDialog> where TDialog : class
    {
        /// <summary>
        /// ダイアログを表示するオーナーを取得します。
        /// </summary>
        object Owner { get; }

        /// <summary>
        /// 指定したダイアログが開かれているかどうかを取得します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        /// <returns>開かれている場合は true, それ以外は false を返却します。</returns>
        bool IsOpened<T>() where T : TDialog, new();

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void Show<T>() where T : TDialog, new();

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void ShowWithOwner<T>() where T : TDialog, new();

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        void Show<T1, T2>(T2 request) where T1 : TDialog, IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        void ShowWithOwner<T1, T2>(T2 request) where T1 : TDialog, IDialogRequest<T2>, new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void Activate<T>() where T : TDialog, new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">パラメーターの型。</typeparam>
        /// <param name="param">パラメーター。</param>
        void ActivateWithAction<T1, T2>(T2 param) where T1 : TDialog, IDialogActivateAction<T2>, new();

        /// <summary>
        /// モーダレスダイアログを閉じます。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void Close<T>() where T : TDialog;

        /// <summary>
        /// モーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">ダイアログ。</typeparam>
        void ShowDialog<T>() where T : TDialog, new();

        /// <summary>
        /// リクエストを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        void ShowDialog<T1, T2>(T2 request) where T1 : TDialog, IDialogRequest<T2>, new();

        /// <summary>
        /// レスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">レスポンス。</typeparam>
        /// <returns>レスポンス。</returns>
        T2 ShowDialog<T1, T2>() where T1 : TDialog, IDialogResponse<T2>, new();

        /// <summary>
        /// リクエストとレスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">ダイアログ。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <typeparam name="T3">レスポンス。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <returns>レスポンス。</returns>
        T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : TDialog, IDialogRequest<T2>, IDialogResponse<T3>, new();
    }
}
