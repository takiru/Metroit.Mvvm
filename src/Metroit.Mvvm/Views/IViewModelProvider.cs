namespace Metroit.Mvvm.Views
{
    /// <summary>
    /// ビューモデルの供給を提供します。
    /// </summary>
    /// <typeparam name="T">ビューモデルの型。</typeparam>
    public interface IViewModelProvider<T> where T : class
    {
        /// <summary>
        /// ビューモデルの取得または設定を行います。
        /// </summary>
        T ViewModel { get; }
    }
}
