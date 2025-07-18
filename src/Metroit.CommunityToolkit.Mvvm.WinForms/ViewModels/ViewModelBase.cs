using Metroit.Mvvm.WinForms.ViewModels;

namespace Metroit.CommunityToolkit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// ViewModel の基底となる操作を提供します。
    /// </summary>
    public class ViewModelBase : TrackingObservableObject
    {
        /// <summary>
        /// メッセージを提供します。
        /// </summary>
        public MessageProvider MessageProvider { get; } = new MessageProvider();
    }
}
