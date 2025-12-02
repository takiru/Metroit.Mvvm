namespace Metroit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// ViewModel を構成する基底となるインターフェースを提供します。
    /// </summary>
    public interface IWinFormsViewModel
    {
        /// <summary>
        /// View制御サービスを提供します。
        /// </summary>
        WinFormsViewService ViewService { get; }
    }
}
