using Metroit.Mvvm.Interfaces.Generic;

namespace Metroit.Mvvm.ViewModels
{
    /// <summary>
    /// View に関する制御用のサービスを提供します。
    /// ダイアログに既定の<see cref="DialogResultType"/>を用います。
    /// </summary>
    public class DefaultViewService<T1> : ViewService<T1, DialogResultType> where T1 : class
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="dialog">ダイアログサービス。</param>
        /// <param name="message">メッセージサービス。</param>
        public DefaultViewService(IDialogService<T1> dialog, IMessageService<DialogResultType> message)
            : base(dialog, message)
        {

        }
    }
}
