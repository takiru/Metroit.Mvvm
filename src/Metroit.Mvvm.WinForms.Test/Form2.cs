using Metroit.Contracts;
using Metroit.Mvvm.Interfaces;
using Metroit.Mvvm.Views;
using Metroit.Mvvm.WinForms.Views;

namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form2 : Form, IViewModelProvider<Form1ViewModel>, IDialogRequest<TestDialogRequest>,
        IDialogResponse<TestDialogResponse>, IDialogActivateAction<TestDialogRequest>
    {
        public Form1ViewModel ViewModel { get; set; }
        public TestDialogRequest Request { get; set; }

        public TestDialogResponse Response { get; set; }

        public Form2()
        {
            InitializeComponent();
            var viewService = WinFormsViewService.Create(this);
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
            MessageBox.Show($"アクティブになったときの制御。Activatedイベントの後に発生する。\r\nリクエスト値＝{param.RequestValue}");
        }
    }
}
