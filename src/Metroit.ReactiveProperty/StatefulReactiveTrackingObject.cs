using Metroit.Annotations;
using Metroit.ChangeTracking.Generic;
using System.Runtime.CompilerServices;

namespace Metroit.ReactiveProperty
{
    /// <summary>
    /// 状態を持つ変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    public abstract class StatefulReactiveTrackingObject<T1, T2> : ReactiveTrackingObject<T1, T2> where T1 : class where T2 : PropertyChangeTracker<T1>, new()
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
        public StatefulReactiveTrackingObject() : base()
        {

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
        /// 値変更の通知を行います。
        /// </summary>
        /// <param name="propertyName">プロパティ名。</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            ChangeStateOnPropertyChanged();
            base.OnPropertyChanged(propertyName);
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
                if(!ChangeTracker.IsSomethingValueChanged)
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
