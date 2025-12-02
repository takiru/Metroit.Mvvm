using Metroit.Mvvm.ViewModels;
using Metroit.Mvvm.WinForms.ViewModels;

namespace Metroit.Mvvm.WinForms.Test
{
    /// <summary>
    /// View に関する制御用のサービスを提供します。
    /// </summary>
    public class WinFormsViewService : DefaultViewService<Form>
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="dialog">ダイアログサービス。</param>
        /// <param name="message">メッセージサービス。</param>
        public WinFormsViewService(IWinFormsDialogService dialog, WinFormsMessageService message)
            : base(dialog, message)
        {
        }
    }
}
