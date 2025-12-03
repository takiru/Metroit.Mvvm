using Metroit.Annotations;
using Metroit.ChangeTracking;
using Metroit.ChangeTracking.Generic;
using Reactive.Bindings;
using System.Reflection;

namespace Metroit.ReactiveProperty
{
    /// <summary>
    /// オブジェクト内にある<see cref="ReactiveProperty{T}"/>を実装したプロパティおよびフィールドの変更追跡を提供します。<br/>
    /// <see cref="NoTrackingAttribute"/>または<see cref="PropertyChangeTracker.NoTrackings"/>が設定されたプロパティまたはフィールドは変更追跡をしません。<br/>
    /// 追跡を必要とするプロパティまたはフィールドは get アクセサーが必要です。
    /// </summary>
    /// <typeparam name="T">変更追跡を行うクラス。</typeparam>
    public class ReactivePropertyChangeTracker<T> : PropertyChangeTracker<T> where T : class
    {
        /// <summary>
        /// 変更追跡しているプロパティまたはフィールドの値を取得します。
        /// </summary>
        /// <param name="propertyInfo">変更追跡対象のプロパティまたはフィールド。</param>
        /// <param name="instance">変更追跡を行うオブジェクト。</param>
        /// <returns>変更追跡しているプロパティまたはフィールドの値。</returns>
        protected override object GetPropertyValue(PropertyInfo propertyInfo, object instance)
        {
            var rp = propertyInfo.GetValue(instance) as IReactiveProperty;
            return rp?.Value ?? null;
        }
    }
}
