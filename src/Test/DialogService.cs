using Metroit.Mvvm.Interfaces;

namespace Metroit.Mvvm.WinForms.Test
{
    public class TestDialogRequest : IDialogRequest
    {
        public string RequestValue { get; set; }
    }

    public class TestDialogResponse : IDialogResponse
    {
        public string ResponseValue { get; set; }
    }

    public class DialogService : IDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        // TODO: DI 用に用意する
        //public DialogService(IServiceProvider serviceProvider)
        //{
        //    _serviceProvider = serviceProvider;
        //}

        public DialogService()
        {

        }

        public void Show(string windowKey)
        {
            if (windowKey == "Form2")
            {
                (new Form2()).Show();
            }
        }

        public void Show(string windowKey, IDialogRequest request)
        {
            if (windowKey == "Form2")
            {
                var f = new Form2();
                f.Request = request;
                f.Show();
            }
        }

        public IDialogResponse ShowDialog(string windowKey)
        {
            if (windowKey == "Form2")
            {
                var f = new Form2();
                var r = f.ShowDialog();
                return (TestDialogResponse)f.Response;
            }

            return null;
        }

        public IDialogResponse ShowDialog(string windowKey, IDialogRequest request)
        {
            if (windowKey == FormName.Form2.ToString())
            {
                var f = new Form2();
                f.Request = request;
                var r = f.ShowDialog();
                return (TestDialogResponse)f.Response;
            }

            return null;
        }
    }
}
