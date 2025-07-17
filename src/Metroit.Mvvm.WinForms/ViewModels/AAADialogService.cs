using Metroit.Mvvm.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metroit.Mvvm.WinForms.ViewModels
{
    class AAADialogService : IDialogService<IDialogRequest, IDialogResponse>
    {
        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Show(IDialogRequest request)
        {
            throw new NotImplementedException();
        }

        public IDialogRequest ShowDialog()
        {
            throw new NotImplementedException();
        }

        public IDialogResponse ShowDialog(IDialogRequest request)
        {
            throw new NotImplementedException();
        }
    }

    class Hoge
    {
        public Hoge(string a)
        {
        }
    }

    public class Request : IDialogRequest
    {

    }

    public class HogeRequest : Request
    {

    }

    public class FugaResponse : IDialogResponse
    {

    }
}
