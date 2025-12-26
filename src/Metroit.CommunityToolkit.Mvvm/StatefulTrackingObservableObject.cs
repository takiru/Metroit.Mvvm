using Metroit.Annotations;

namespace Metroit.CommunityToolkit.Mvvm
{
    /// <summary>
    /// 状態を持つ変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    /// <typeparam name="T">状態管理と変更追跡を行うクラス。</typeparam>
    public class StatefulTrackingObservableObject<T> : TrackingObservableObject<T>, IStateObject where T : class
    {
        private ItemState _state = ItemState.New;

        /// <summary>
        /// 現在の状態を取得します。
        /// </summary>
        [NoTracking]
        public ItemState State => _state;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StatefulTrackingObservableObject() : base()
        {
            ChangeTracker.TrackingPropertyValueChanged += ChangeTracker_TrackingPropertyValueChanged;
        }

        /// <summary>
        /// 状態を変更します。
        /// </summary>
        /// <param name="state">状態。</param>
        public void ChangeState(ItemState state)
        {
            _state = state;
        }

        /// <summary>
        /// 変更追跡のプロパティ値変更によるステート変更を行う。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTracker_TrackingPropertyValueChanged(object sender, ChangeTracking.PropertyChangedTrackingEventArgs e)
        {
            ChangeStateOnPropertyChanged();
        }

        /// <summary>
        /// プロパティ変更時に状態を変更します。
        /// </summary>
        private void ChangeStateOnPropertyChanged()
        {
            // 新規行の値を変更したとき
            if (State == ItemState.New)
            {
                ChangeState(ItemState.NewModified);
                return;
            }

            // 無変更行の値を変更したとき
            if (State == ItemState.NotModified)
            {
                ChangeState(ItemState.Modified);
                return;
            }

            // 新規行の値を編集して元の値に戻ったとき
            if (State == ItemState.NewModified)
            {
                if (!ChangeTracker.IsSomethingValueChanged)
                {
                    ChangeState(ItemState.New);
                }
                return;
            }

            // 無変更行の値を編集して元の値に戻ったとき
            if (State == ItemState.Modified)
            {
                if (!ChangeTracker.IsSomethingValueChanged)
                {
                    ChangeState(ItemState.NotModified);
                }
                return;
            }
        }
    }
}