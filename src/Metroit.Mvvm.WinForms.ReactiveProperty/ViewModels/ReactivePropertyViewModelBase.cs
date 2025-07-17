using Metroit.Mvvm.WinForms.ViewModels;
using System.ComponentModel;

namespace Metroit.Mvvm.WinForms.ReactiveProperty.ViewModels
{
    /// <summary>
    /// ViewModel の基底となる操作を提供します。
    /// </summary>
    public class ReactivePropertyViewModelBase : WinForms.ViewModels.ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// 値が変更されたときに発生します。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="viewService">View制御サービス。</param>
        public ReactivePropertyViewModelBase(ViewService viewService) : base(viewService) { }
    }
}
