using System;
using Metroit.Mvvm.ChangeTracking;

namespace Metroit.Mvvm.Annotations
{
    /// <summary>
    /// <see cref="PropertyChangeTracker{T}"/> クラスで変更追跡を行わないプロパティまたはフィールドに設定する属性です。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class NoTrackingAttribute : Attribute
    {
        public NoTrackingAttribute()
        {
            
        }
    }
}
