using System;

namespace Metroit.Mvvm.Abstractions.Interfaces
{
    /// <summary>
    /// ダイアログサービスの生成を提供します。
    /// </summary>
    public interface IDialogServiceFactory
    {
        /// <summary>
        /// サービスプロバイダーを取得します。
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 識別キーからダイアログサービスを生成します。
        /// </summary>
        /// <param name="windowKey">識別キー。</param>
        /// <returns>ダイアログサービス。</returns>
        IDialogService CreateDialog(string windowKey);

        /// <summary>
        /// 識別キーからダイアログサービスを生成します。
        /// </summary>
        /// <typeparam name="T">列挙型。</typeparam>
        /// <param name="windowKey">列挙型の識別キー。</param>
        /// <returns>ダイアログサービス。</returns>
        IDialogService CreateDialog<T>(T windowKey) where T : Enum;
    }
}
