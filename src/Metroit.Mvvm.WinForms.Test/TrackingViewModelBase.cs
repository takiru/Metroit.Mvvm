using Metroit.Annotations;
using Metroit.CommunityToolkit.Mvvm;

namespace Metroit.Mvvm.WinForms.Test
{
    /// <summary>
    /// ViewModel の基底となる操作を提供します。
    /// </summary>
    /// <typeparam name="T">変更追跡を行うクラス。</typeparam>
    public abstract class TrackingViewModelBase<T> : TrackingObservableObject<T> where T : class
    {
        /// <summary>
        /// View制御サービスを提供します。
        /// </summary>
        [NoTracking]
        public WinFormsViewService ViewService { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackingViewModelBase(WinFormsViewService viewService) : base()
        {
            ViewService = viewService;
        }
    }
}
