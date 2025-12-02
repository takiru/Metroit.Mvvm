using Metroit.Contracts;
using Metroit.Mvvm.Interfaces;
using System;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// WinForms用のダイアログサービスを提供します。
    /// </summary>
    public interface IWinFormsDialogService
    {
        /// <summary>
        /// 指定したダイアログが開かれているかどうかを取得します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <returns>開かれている場合は true, それ以外は false を返却します。</returns>
        bool IsOpened<T>() where T : Form, new();

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        void Show<T>() where T : Form, new();

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        void Show<T>(Func<Form> ownerProvider) where T : Form, new();

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>を実装していません。</exception>
        void Show<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        void Show<T1, T2>(T2 request, Func<Form> ownerProvider) where T1 : Form, IDialogRequest<T2>, new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        void Activate<T>() where T : Form, new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/>が<see cref="IDialogActivateAction"/>を実装していません。</exception>
        void ActivateWithAction<T>() where T : Form, IDialogActivateAction, new();

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <param name="param">パラメーター。</param>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/>が<see cref="IDialogActivateAction"/>を実装していません。</exception>
        void ActivateWithAction<T>(object param) where T : Form, IDialogActivateAction, new();

        /// <summary>
        /// モーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        void ShowDialog<T>() where T : Form, new();

        /// <summary>
        /// リクエストを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>を実装していません。</exception>
        void ShowDialog<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new();

        /// <summary>
        /// レスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">レスポンス。</typeparam>
        /// <returns>レスポンス。</returns>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogResponse{T}"/>を実装していません。</exception>
        T2 ShowDialog<T1, T2>() where T1 : Form, IDialogResponse<T2>, new();

        /// <summary>
        /// リクエストとレスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <typeparam name="T3">レスポンス。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <returns>レスポンス。</returns>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>と<see cref="IDialogResponse{T}"/>を実装していません。</exception>
        T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : Form, IDialogRequest<T2>, IDialogResponse<T3>, new();
    }
}
