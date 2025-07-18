using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Metroit.Annotations;
using Metroit.Mvvm.ViewModels;

namespace Metroit.CommunityToolkit.Mvvm.Test
{
    public partial class Form1ViewModel : TrackingObservableObjectViewModelBase
    {
        public Form1ViewModel()
        {
            ChangeTracker.NoTrackings = new string[] {
                nameof(IsChanged)
            };
            ChangeTracker.SomethingValueChanged = (isChanged) => IsChanged = isChanged;
            ChangeTracker.Reset();
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ExecuteMethodCommand))]
        public string _text = "123";

        [ObservableProperty]
        public string _text2 = "1234";

        [RelayCommand(CanExecute = nameof(CanExecuteMethod))]
        public void ExecuteMethod()
        {
            var a = Text;
            MessageBox.Show($"{ChangeTracker.ContainsChangedProperty(nameof(Text))}");

        }

        [NoTracking]
        private bool CanExecuteMethod => Text.Length >= 3;


        [ObservableProperty]
        private bool _isChanged;
    }
}
