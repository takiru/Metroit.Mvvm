using Metroit.Mvvm.WinForms.ViewModels;
using Metroit.Mvvm.WinForms.Views;
using Test;

namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form2 : ViewBase
    {
        private Form1ViewModel ViewModel;

        public object Request { get; set; }

        public object Response { get; set; }

        public Form2()
        {
            InitializeComponent();
            var viewService = new ViewService(new DialogService(), new MessageService() { OwnerFormProvider = () => ActiveFormTracker.ActiveForm });
            ViewModel = NewViewModel<Form1ViewModel>(viewService);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewModel.MessageTest();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            if (Request == null)
            {
                MessageBox.Show("リクエスト値はありません。");
                return;
            }

            MessageBox.Show($"リクエスト値＝{((TestDialogRequest)Request).RequestValue}");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            var r = new TestDialogResponse()
            {
                ResponseValue = "Form2からの応答値です。"
            };
            Response = r;
        }


    }
}
