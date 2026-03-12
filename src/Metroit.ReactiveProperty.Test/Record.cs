using Metroit.ReactiveProperty.ChangeTracking;
using Reactive.Bindings;
using System.ComponentModel;
using System.Diagnostics;

namespace Metroit.ReactiveProperty.Test
{
    public class Record : StatefulReactiveTrackingObject<Record, ReactivePropertyChangeTracker<Record>>
    {
        public ReactiveProperty<string> Name { get; private set; } = new ReactiveProperty<string>();

        public ReactiveProperty<int> Age { get; set; } = new ReactiveProperty<int>();

        private string _hoge = "default";
        public string Hoge { get => _hoge; set => SetProperty(ref _hoge, value); }

        public Record()
        {
            InitializePropertyTracking();
            ChangeTracker.Reset();

            PropertyChanged += (sender, e) =>
            {
                Debug.WriteLine($"{State}, {Name}, {Age}, {Hoge}");
            };
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
    }
}