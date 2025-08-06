using Metroit.Annotations;
using Metroit.Mvvm.ViewModels;

namespace Metroit.CommunityToolkit.Mvvm
{
    /// <summary>
    /// ViewModel の基底となる操作を提供します。
    /// </summary>
    /// <typeparam name="T">状態管理と変更追跡を行うクラス。</typeparam>
    public abstract class StatefulTrackingObservableRecipientViewModelBase<T> : StatefulTrackingObservableRecipient<T>, IViewModel where T : class
    {
        /// <summary>
        /// View制御サービスを提供します。
        /// </summary>
        [NoTracking]
        public ViewService ViewService { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StatefulTrackingObservableRecipientViewModelBase() : base() { }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="viewService">View制御サービス。</param>
        public StatefulTrackingObservableRecipientViewModelBase(ViewService viewService) : base()
        {
            ViewService = viewService;
        }
    }
}
