using CommunityToolkit.Mvvm.ComponentModel;
using Metroit.Mvvm.Annotations;
using Metroit.Mvvm.ChangeTracking;
using System.ComponentModel;

namespace Metroit.CommunityToolkit.Mvvm
{
    /// <summary>
    /// 変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    public partial class TrackingObservableObject : ObservableObject
    {
        private PropertyChangeTracker<TrackingObservableObject> _propertyValueTracker;

        /// <summary>
        /// 変更追跡を取得します。
        /// </summary>
        [NoTracking]
        public PropertyChangeTracker<TrackingObservableObject> ChangeTracker => _propertyValueTracker;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackingObservableObject()
        {
            _propertyValueTracker = new PropertyChangeTracker<TrackingObservableObject>(this);

            PropertyChanged += ChangesObservableObject_PropertyChanged;
        }

        /// <summary>
        /// 変更通知が行われたプロパティまたはフィールドを追跡する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangesObservableObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _propertyValueTracker.TrackingProperty(e.PropertyName);
        }
    }
}
