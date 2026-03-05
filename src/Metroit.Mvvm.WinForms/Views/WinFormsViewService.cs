using Metroit.Mvvm.ViewModels;
using Metroit.Mvvm.WinForms.ViewModels;
using System;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Views
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

        /// <summary>
        /// WinForms で利用する既定の ViewService を生成します。
        /// </summary>
        /// <param name="ownerFormProvider">メッセージサービスに利用するオーナーを決定するデリゲート。</param>
        /// <returns>WinFormsViewService オブジェクト。</returns>
        public static WinFormsViewService Create(Func<Form> ownerFormProvider)
        {
            return new WinFormsViewService(
                new WinFormsDialogService(ownerFormProvider),
                new WinFormsMessageService(ownerFormProvider));
        }

        /// <summary>
        /// WinForms で利用する既定の ViewService を生成します。
        /// </summary>
        /// <param name="owner">メッセージサービスに利用するオーナー。</param>
        /// <returns>WinFormsViewService オブジェクト。</returns>
        public static WinFormsViewService Create(Form owner)
        {
            return new WinFormsViewService(
                new WinFormsDialogService(() => owner),
                new WinFormsMessageService(() => owner));
        }
    }
}
