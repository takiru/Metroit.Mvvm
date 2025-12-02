using Metroit.Contracts;
using Metroit.Mvvm.Views;
using Metroit.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Test
{
    public partial class Form4 : MetForm, IDialogRequest<HogeRequest>, IViewModelProvider<HogeViewModel>, IDialogResponse<HogeRequest>
    {
        public HogeViewModel ViewModel { get; set; }

        public HogeRequest Request { get; set; } = new HogeRequest();

        private HogeRequest _response = new HogeRequest();

        HogeRequest IDialogResponse<HogeRequest>.Response { get => _response; set => _response = value; }

        /// <summary>
        /// 
        /// </summary>
        public HogeRequest Response { get => _response; private set => _response = value; }

        public Form4()
        {
            InitializeComponent();

            Response.StringValue = "これはテスト";
            ViewModel = new HogeViewModel();
        }
    }

    public class HogeViewModel
    {
        public string ViewModelValue { get; set; }
    }

    public class HogeRequest
    {
        public string StringValue { get; set; }
    }
}
