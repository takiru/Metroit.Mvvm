using Metroit.Contracts;
using Metroit.Mvvm.ViewModels;
using Metroit.Mvvm.Views;
using Metroit.Mvvm.WinForms.Views;
using Test;

namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form2 : Form, IViewModelProvider<Form1ViewModel>, IDialogRequest<TestDialogRequest>, IDialogResponse<TestDialogResponse>
    {
        public Form1ViewModel ViewModel { get; set; }
        public TestDialogRequest Request { get; set; }

        private TestDialogResponse _response = new TestDialogResponse();

        TestDialogResponse IDialogResponse<TestDialogResponse>.Response { get => _response; set => _response = value; }

        /// <summary>
        /// 
        /// </summary>
        public TestDialogResponse Response { get => _response; private set => _response = value; }


        public Form2()
        {
            InitializeComponent();
            var viewService = new ViewService(new DialogService(), new MessageService() { OwnerFormProvider = () => ActiveFormTracker.ActiveForm });
            ViewModel = new Form1ViewModel(viewService);
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

            MessageBox.Show($"リクエスト値＝{Request.RequestValue}");
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
