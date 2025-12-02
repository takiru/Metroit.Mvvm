using Metroit.Mvvm.WinForms.Extensions;
using Metroit.Mvvm.WinForms.ViewModels;

namespace Metroit.CommunityToolkit.Mvvm.Test
{
    public partial class Form1 : Form
    {
        private Form1ViewModel ViewModel = new Form1ViewModel(new WinFormsViewService(new WinFormsDialogService(), new WinFormsMessageService()));

        public Form1()
        {
            InitializeComponent();

            textBox1.BindText(() => ViewModel.Text);
            textBox3.BindText(() => ViewModel.Text2);
            button1.BindClick(ViewModel.ExecuteMethodCommand);
            textBox2.BindText(() => ViewModel.IsChanged);
        }
    }
}
