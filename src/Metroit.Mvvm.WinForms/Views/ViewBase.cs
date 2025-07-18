using Metroit.Mvvm.ViewModels;
using System;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Views
{
    /// <summary>
    /// View の基底となる操作を提供します。
    /// </summary>
    public class ViewBase : Form
    {
        /// <summary>
        /// 認識済みのViewModel。
        /// </summary>
        private ViewModelBase _viewModel;

        /// <summary>
        /// 新たな ViewModel を生成します。
        /// </summary>
        /// <typeparam name="T">ViewModel の具体的な型。</typeparam>
        /// <returns>ViewModel。</returns>
        protected T NewViewModel<T>(params object[] args) where T : ViewModelBase
        {
            _viewModel = (T)Activator.CreateInstance(typeof(T), args);
            return (T)_viewModel;
        }

        /// <summary>
        /// ViewModel を取得します。
        /// </summary>
        /// <typeparam name="T">ViewModel の具体的な型。</typeparam>
        /// <returns>ViewModel。</returns>
        protected T GetViewModel<T>() where T : ViewModelBase
        {
            return (T)_viewModel;
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public ViewBase() : base() { }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="viewModel">ViewModel。</param>
        public ViewBase(ViewModelBase viewModel) : base()
        {
            _viewModel = viewModel;
        }
    }
}
