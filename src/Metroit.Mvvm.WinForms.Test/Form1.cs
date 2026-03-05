using Metroit.Mvvm.Views;
using Metroit.Mvvm.WinForms.Views;

namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form1 : Form, IViewModelProvider<Form1ViewModel>
    {
        public Form1ViewModel ViewModel { get; }

        public Form1()
        {
            InitializeComponent();

            var viewService = WinFormsViewService.Create(this);
            ViewModel = new Form1ViewModel(viewService);
        }

        private void MessageButton_Click(object sender, EventArgs e)
        {
            ViewModel.MessageTest();
        }

        private void DialogShowButton_Click(object sender, EventArgs e)
        {
            ViewModel.Show();
        }

        private void DialogShowWithRequestButton_Click(object sender, EventArgs e)
        {
            ViewModel.ShowWithRequest();
        }

        private void DialogShowDialogButton_Click(object sender, EventArgs e)
        {
            ViewModel.ShowDialog();
        }

        private void DialogShowDialogWithRequestButton_Click(object sender, EventArgs e)
        {
            ViewModel.ShowDialogWithRequest();
        }

        private void DialogShowDialogWithResponseButton_Click(object sender, EventArgs e)
        {
            ViewModel.ShowDialogWithResponse();
        }

        private void DialogShowDialogWithRequestAndResponseButton_Click(object sender, EventArgs e)
        {
            ViewModel.ShowDialogWithRequestAndResponse();
        }

        private void DialogCloseButton_Click(object sender, EventArgs e)
        {
            ViewModel.Close();
        }
    }
}
