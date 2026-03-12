using CommunityToolkit.Mvvm.ComponentModel;
using Metroit.Annotations;
using Metroit.ChangeTracking;
using Metroit.ChangeTracking.Generic;
using System.ComponentModel;

namespace Metroit.CommunityToolkit.Mvvm.ChangeTracking
{
    /// <summary>
    /// 変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    /// <typeparam name="T1">変更追跡対象オブジェクト。</typeparam>
    /// <typeparam name="T2">トラッカー。</typeparam>
    public class TrackingObservableObject<T1, T2> : ObservableObject, IPropertyChangeTrackerProvider<T1> where T1 : class where T2 : PropertyChangeTracker<T1>, new()
    {
        private readonly T2 _changeTracker;

        /// <summary>
        /// 変更追跡を取得します。
        /// </summary>
        [NoTracking]
        public PropertyChangeTracker<T1> ChangeTracker => _changeTracker;

        /// <summary>
        /// 変更追跡を取得します。
        /// </summary>
        [NoTracking]
        PropertyChangeTracker IPropertyChangeTrackerProvider.ChangeTracker => ChangeTracker;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackingObservableObject() : base()
        {
            _changeTracker = new T2();
            _changeTracker.SetInstance(this);
        }

        /// <summary>
        /// 変更通知が行われたプロパティまたはフィールドを追跡する。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            _changeTracker.TrackingProperty(e.PropertyName);
            base.OnPropertyChanged(e);
        }
    }
}