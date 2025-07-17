using Metroit.Mvvm.Abstractions.Interfaces;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// View に関する制御用のサービスを提供します。
    /// </summary>
    public class ViewService
    {
        /// <summary>
        /// ダイアログ生成サービスを提供します。
        /// </summary>
        public IDialogServiceFactory DialogServiceFactory { get; }

        /// <summary>
        /// メッセージサービスを提供します。
        /// </summary>
        public IMessageService<DialogResult> MessageService { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="dialogServiceFactory">ダイアログ生成サービス。</param>
        /// <param name="messageService">メッセージサービス。</param>
        public ViewService(IDialogServiceFactory dialogServiceFactory, IMessageService<DialogResult> messageService)
        {
            DialogServiceFactory = dialogServiceFactory;
            MessageService = messageService;
        }
    }
}
