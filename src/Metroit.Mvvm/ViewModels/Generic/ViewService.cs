using Metroit.Mvvm.Interfaces.Generic;

namespace Metroit.Mvvm.ViewModels.Generic
{
    /// <summary>
    /// View に関する制御用のサービスを提供します。
    /// </summary>
    public class ViewService<T1, T2> where T1 : class
    {
        /// <summary>
        /// ダイアログサービスを提供します。
        /// </summary>
        public IDialogService<T1> Dialog { get; }

        /// <summary>
        /// メッセージサービスを提供します。
        /// </summary>
        public IMessageService<T2> Message { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="dialog">ダイアログサービス。</param>
        /// <param name="message">メッセージサービス。</param>
        public ViewService(IDialogService<T1> dialog, IMessageService<T2> message)
        {
            Dialog = dialog;
            Message = message;
        }
    }
}
