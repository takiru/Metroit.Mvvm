using Metroit.Mvvm.Interfaces;

namespace Metroit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// View に関する制御用のサービスを提供します。
    /// </summary>
    public class WinFormsViewService
    {
        /// <summary>
        /// ダイアログサービスを提供します。
        /// </summary>
        public IWinFormsDialogService Dialog { get; }

        /// <summary>
        /// メッセージサービスを提供します。
        /// </summary>
        public IMessageService<DialogResultType> Message { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="dialog">ダイアログサービス。</param>
        /// <param name="message">メッセージサービス。</param>
        public WinFormsViewService(IWinFormsDialogService dialog, IMessageService<DialogResultType> message)
        {
            Dialog = dialog;
            Message = message;
        }
    }
}
