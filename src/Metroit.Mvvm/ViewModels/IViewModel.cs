namespace Metroit.Mvvm.ViewModels
{
    /// <summary>
    /// ViewModel を構成する基底となるインターフェースを提供します。
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// View制御サービスを提供します。
        /// </summary>
        ViewService ViewService { get; }
    }
}
