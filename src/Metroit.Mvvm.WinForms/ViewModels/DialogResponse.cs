using Metroit.Mvvm.Abstractions.Interfaces;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.ViewModels
{
    public class DialogResponse : IDialogResponse
    {
        public DialogResult DialogResult { get; }

        public DialogResponse(DialogResult dialogResult)
        {
            DialogResult = dialogResult;
        }
    }
}
