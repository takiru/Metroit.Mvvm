using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Metroit.Annotations;
using System.ComponentModel;
using System.Diagnostics;

namespace Metroit.CommunityToolkit.Mvvm.Test
{
    public partial class Form1ViewModel : TrackingViewModelBase<Form1ViewModel>
    {
        public Form1ViewModel(WinFormsViewService viewService) : base(viewService)
        {
            ChangeTracker.NoTrackings = new string[] {
                nameof(IsChanged)
            };
            ChangeTracker.SomethingValueChanged = (isChanged) => IsChanged = isChanged;
            ChangeTracker.Reset();

            PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine($"{Text}, {Text2}");
            };
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
            MessageBox.Show($"{ChangeTracker.HasChanged(nameof(Text))}");

        }

        [NoTracking]
        private bool CanExecuteMethod => Text.Length >= 3;


        [ObservableProperty]
        private bool _isChanged;

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
    }
}
