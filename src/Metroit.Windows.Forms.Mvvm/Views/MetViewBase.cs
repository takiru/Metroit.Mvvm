using Metroit.Mvvm.ViewModels;
using System;

namespace Metroit.Windows.Forms.Mvvm.Views
{
    /// <summary>
    /// View の基底となる操作を提供します。
    /// </summary>
    public class MetViewBase : MetForm
    {
        /// <summary>
        /// 認識済みのViewModel。
        /// </summary>
        private IViewModel _viewModel;

        /// <summary>
        /// 新たな ViewModel を生成します。
        /// </summary>
        /// <typeparam name="T">ViewModel の具体的な型。</typeparam>
        /// <returns>ViewModel。</returns>
        protected T NewViewModel<T>(params object[] args) where T : IViewModel
        {
            _viewModel = (T)Activator.CreateInstance(typeof(T), args);
            return (T)_viewModel;
        }

        /// <summary>
        /// ViewModel を取得します。
        /// </summary>
        /// <typeparam name="T">ViewModel の具体的な型。</typeparam>
        /// <returns>ViewModel。</returns>
        protected T GetViewModel<T>() where T : IViewModel
        {
            return (T)_viewModel;
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public MetViewBase() : base() { }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="viewModel">ViewModel。</param>
        public MetViewBase(IViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
    }
}
