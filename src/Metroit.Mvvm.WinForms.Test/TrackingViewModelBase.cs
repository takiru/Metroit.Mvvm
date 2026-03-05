using Metroit.Annotations;
using Metroit.ChangeTracking.Generic;
using Metroit.CommunityToolkit.Mvvm.ChangeTracking;
using Metroit.Mvvm.WinForms.Views;

namespace Metroit.Mvvm.WinForms.Test
{
    /// <summary>
    /// ViewModel の基底となる操作を提供します。
    /// </summary>
    /// <typeparam name="T1">変更追跡対象オブジェクト。</typeparam>
    /// <typeparam name="T2">トラッカー。</typeparam>
    public abstract class TrackingViewModelBase<T1, T2> : TrackingObservableObject<T1, T2> where T1 : class where T2 : PropertyChangeTracker<T1>, new()
    {
        /// <summary>
        /// View制御サービスを提供します。
        /// </summary>
        [NoTracking]
        public Views.WinFormsViewService ViewService { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        protected TrackingViewModelBase(WinFormsViewService viewService) : base()
        {
            ViewService = viewService;
        }
    }
}
