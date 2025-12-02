using Metroit.Mvvm.ViewModels;
using Metroit.Mvvm.WinForms.ViewModels;
using System.Diagnostics;

namespace Metroit.Mvvm.WinForms.Test
{
    public class Form1ViewModel : WinFormsViewModelBase
    {
        public Form1ViewModel(WinFormsViewService viewService) : base(viewService)
        {

        }

        public void MessageTest()
        {
            DialogResultType result;

            ViewService.Message.Information("インフォメーション");
            ViewService.Message.Information("インフォメーション", "インフォメーションタイトル");

            result = ViewService.Message.ConfirmYesNo("YesNo確認");
            Debug.WriteLine($"{result}");
            result = ViewService.Message.ConfirmYesNo("YesNo確認", "YesNoタイトル");
            Debug.WriteLine($"{result}");

            result = ViewService.Message.ConfirmOkCancel("OkCancel確認");
            Debug.WriteLine($"{result}");
            result = ViewService.Message.ConfirmOkCancel("OkCancel確認", "OkCancelタイトル");
            Debug.WriteLine($"{result}");

            result = ViewService.Message.ConfirmYesNoCancel("YesNoCancel確認");
            Debug.WriteLine($"{result}");
            result = ViewService.Message.ConfirmYesNoCancel("YesNoCancel確認", "YesNoCancelタイトル");
            Debug.WriteLine($"{result}");

            ViewService.Message.Warning("警告");
            ViewService.Message.Warning("警告", "警告タイトル");

            ViewService.Message.Error("エラー");
            ViewService.Message.Error("エラー", "エラータイトル");
        }

        public Func<Form> OwnerProvider;

        public void Show()
        {
            if (ViewService.Dialog.IsOpened<Form2>())
            {
                ViewService.Dialog.ActivateWithAction<Form2>();
                return;
            }

            ViewService.Dialog.Show<Form2>();
        }

        public void ShowWithRequest()
        {
            var req = new TestDialogRequest()
            {
                RequestValue = "Form2へのリクエスト値です。"
            };
            ViewService.Dialog.Show<Form2, TestDialogRequest>(req, OwnerProvider);
        }

        public void ShowDialog()
        {
            ViewService.Dialog.ShowDialog<Form2>();
        }

        public void ShowDialogWithRequest()
        {
            var req = new TestDialogRequest()
            {
                RequestValue = "Form2へのリクエスト値です。"
            };
            ViewService.Dialog.ShowDialog<Form2, TestDialogRequest>(req);
        }

        public void ShowDialogWithResponse()
        {
            var r = ViewService.Dialog.ShowDialog<Form2, TestDialogResponse>();
            ViewService.Message.Information(r.ResponseValue);
        }

        public void ShowDialogWithRequestAndResponse()
        {
            var req = new TestDialogRequest()
            {
                RequestValue = "Form2へのリクエスト値です。"
            };
            var r = ViewService.Dialog.ShowDialog<Form2, TestDialogRequest, TestDialogResponse>(req);
            ViewService.Message.Information(r.ResponseValue);
        }
    }
}
