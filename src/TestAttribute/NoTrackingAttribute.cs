using System;
using System.ComponentModel.DataAnnotations;

namespace TestAttribute
{
    /// <summary>
    /// <see cref="PropertyChangeTracker{T}"/> クラスで変更追跡を行わないプロパティまたはフィールドに設定する属性です。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class NoTrackingAttribute : ValidationAttribute
    {

    }
}
