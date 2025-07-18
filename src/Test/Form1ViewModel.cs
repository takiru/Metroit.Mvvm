using Metroit.Mvvm;
using Metroit.Mvvm.ViewModels;
using Metroit.Mvvm.WinForms.Test;
using System.Diagnostics;

namespace Test
{
    public class Form1ViewModel : ViewModelBase
    {
        public Form1ViewModel(ViewService viewService) : base(viewService)
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
            result = ViewService.Message.ConfirmYesNoCancel("YesNoCancel確認", "YesHoCancelタイトル");
            Debug.WriteLine($"{result}");

            ViewService.Message.Warning("警告");
            ViewService.Message.Warning("警告", "警告タイトル");

            ViewService.Message.Error("エラー");
            ViewService.Message.Error("エラー", "エラータイトル");
        }

        public void DialogTestShow()
        {
            ViewService.Dialog.Show("Form2");
        }

        public void DialogTestShowWithParam()
        {
            var req = new TestDialogRequest()
            {
                RequestValue = "Form2へのリクエスト値です。"
            };
            ViewService.Dialog.Show("Form2", req);
        }

        public void DialogTestShowDialog()
        {
            var r = ViewService.Dialog.ShowDialog("Form2");
            ViewService.Message.Information(((TestDialogResponse)r).ResponseValue);
        }

        public void DialogTestShowDialogWithParam()
        {
            var req = new TestDialogRequest()
            {
                RequestValue = "Form2へのリクエスト値です。"
            };
            var r = ViewService.Dialog.ShowDialog(FormName.Form2.ToString(), req);
            ViewService.Message.Information(((TestDialogResponse)r).ResponseValue);
        }
    }
}
