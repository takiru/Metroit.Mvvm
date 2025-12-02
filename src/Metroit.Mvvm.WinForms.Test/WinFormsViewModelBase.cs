namespace Metroit.Mvvm.WinForms.Test
{
    /// <summary>
    /// ViewModel の基底となる操作を提供します。
    /// </summary>
    public abstract class WinFormsViewModelBase
    {
        /// <summary>
        /// View制御サービスを提供します。
        /// </summary>
        public WinFormsViewService ViewService { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public WinFormsViewModelBase() { }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="viewService">View制御サービス。</param>
        public WinFormsViewModelBase(WinFormsViewService viewService)
        {
            ViewService = viewService;
        }
    }
}
