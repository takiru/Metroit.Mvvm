using Reactive.Bindings;

namespace Metroit.ReactiveProperty.ChangeTracking
{
    /// <summary>
    /// プロパティの変更追跡情報を提供します。
    /// </summary>
    internal class PropertyTrackingInfo
    {
        /// <summary>
        /// 追跡するReactivePropertyを取得または設定します。
        /// </summary>
        public IReactiveProperty ReactiveProperty { get; set; }

        /// <summary>
        /// 追跡が有効かどうかを取得または設定します。
        /// </summary>
        public bool Enabled { get; set; } = true;
    }
}
