using CommunityToolkit.Mvvm.ComponentModel;
using Metroit.Annotations;
using Metroit.ChangeTracking.Generic;
using System.ComponentModel;

namespace Metroit.CommunityToolkit.Mvvm
{
    /// <summary>
    /// 変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    /// <typeparam name="T">変更追跡を行うクラス。</typeparam>
    public class TrackingObservableObject<T> : ObservableObject, IPropertyChangeTrackerProvider<TrackingObservableObject<T>> where T : class
    {
        private PropertyChangeTracker<TrackingObservableObject<T>> _changeTracker;

        /// <summary>
        /// 変更追跡を取得します。
        /// </summary>
        [NoTracking]
        public PropertyChangeTracker<TrackingObservableObject<T>> ChangeTracker => _changeTracker;

        /// <summary>
        /// 変更追跡を取得します。
        /// </summary>
        [NoTracking]
        ChangeTracking.PropertyChangeTracker ChangeTracking.IPropertyChangeTrackerProvider.ChangeTracker => ChangeTracker;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackingObservableObject() : base()
        {
            _changeTracker = new PropertyChangeTracker<TrackingObservableObject<T>>(this);
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