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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (State == ItemState.New)
            {
                ChangeState(ItemState.NewModified);
            }
            if (State == ItemState.NotModified)
            {
                ChangeState(ItemState.Modified);
            }

            base.OnPropertyChanged(propertyName);
        }
    }
}
