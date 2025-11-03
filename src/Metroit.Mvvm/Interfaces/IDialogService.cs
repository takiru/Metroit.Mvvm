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
        /// リクエストなし、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void Show<T>() where T : new();

        /// <summary>
        /// リクエストあり、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        void Show<T1, T2>(T2 request) where T1 : IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストなし、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void ShowDialog<T>() where T : new();

        /// <summary>
        /// リクエストあり、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        void ShowDialog<T1, T2>(T2 request) where T1 : IDialogRequest<T2>, new();

        /// <summary>
        /// リクエストなし、レスポンスありモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        T2 ShowDialog<T1, T2>() where T1 : IDialogResponse<T2>, new();

        /// <summary>
        /// リクエストあり、レスポンスありモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : IDialogRequest<T2>, IDialogResponse<T3>, new();
    }
}
