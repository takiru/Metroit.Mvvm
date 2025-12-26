using Metroit.Contracts;
using Metroit.Mvvm.Interfaces;
using Metroit.Mvvm.Views;
using Metroit.Mvvm.WinForms.ViewModels;
using System.Diagnostics;

namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form2 : Form, IViewModelProvider<Form1ViewModel>, IDialogRequest<TestDialogRequest>, IDialogResponse<TestDialogResponse>, IDialogActivateAction<TestDialogRequest>
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
            var viewService = new WinFormsViewService(new WinFormsDialogService(), new WinFormsMessageService(() => this));
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

        private void button2_Click(object sender, EventArgs e)
        {
            ViewModel.Show();
        }

        public void ExecuteActivateAction(TestDialogRequest param)
        {
            Debug.WriteLine("アクティブになったときの制御。Activatedイベントの後に発生する。");
        }
    }
}
