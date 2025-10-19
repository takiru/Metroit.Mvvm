using Metroit.Mvvm.ViewModels;
using Metroit.Mvvm.Views;
using Metroit.Mvvm.WinForms;
using Metroit.Mvvm.WinForms.Test;
using Metroit.Mvvm.WinForms.Views;
using Metroit.Windows.Forms.Mvvm;

namespace Test
{
    public partial class Form1 : Form, IViewModelProvider<Form1ViewModel>
    {
        public Form1ViewModel ViewModel { get; set; }

        public Form1()
        {
            InitializeComponent();

            // TODO: DI で MessageService をインスタンス化してシングルトンで登録する
            var viewService = new ViewService(new DialogService(), new MessageService() { OwnerFormProvider = () => ActiveFormTracker.ActiveForm });
            ViewModel = new Form1ViewModel(viewService);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewModel.MessageTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewModel.DialogTestShow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewModel.DialogTestShowWithParam();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewModel.DialogTestShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewModel.DialogTestShowDialogWithParam();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = new Form3();
        }
    }
}
