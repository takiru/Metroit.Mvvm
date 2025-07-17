using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Metroit.Mvvm.ChangeTracking
{
    /// <summary>
    /// オブジェクト内にあるプロパティおよびフィールドの変更追跡を提供します。
    /// 変更追跡が行われるのは public のプロパティまたはフィールドです。
    /// プロパティは get アクセサーが必要です。
    /// </summary>
    /// <typeparam name="T">変更追跡を行うクラス。</typeparam>
    public class PropertyChangeTracker<T> where T : class
    {
        /// <summary>
        /// 公開しているすべてのプロパティまたはフィールドの既定値。
        /// </summary>
        public Dictionary<string, object> OriginalValues { get; } = new Dictionary<string, object>();

        /// <summary>
        /// 変更されたすべてのプロパティまたはフィールドの値。
        /// </summary>
        public Dictionary<string, object> ChangedValues { get; } = new Dictionary<string, object>();

        /// <summary>
        /// 公開しているすべてのプロパティまたはフィールドの既定値をリセットします。
        /// </summary>
        public virtual void ResetOriginalValues(T obj)
        {
            OriginalValues.Clear();
            var properties = obj.GetType().GetProperties(System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField)
                .Where(x => !typeof(ICommand).IsAssignableFrom(x.PropertyType));

            foreach (var property in properties)
            {
                OriginalValues.Add(property.Name, property.GetValue(this));
            }
        }

        /// <summary>
        /// プロパティまたはフィールドを追跡します。
        /// </summary>
        /// <param name="propertyName">変更通知が行われたプロパティ名。</param>
        public void TrackingProperty(string propertyName)
        {
            if (propertyName == nameof(IsSomethingValueChanged))
            {
                return;
            }

            var defaultValue = OriginalValues[propertyName];
            var changedValue = GetType().GetProperty(propertyName)?.GetValue(this);

            // 既定値に戻ったときには変更値から除去する
            if (object.Equals(changedValue, defaultValue))
            {
                ChangedValues.Remove(propertyName);
                if (ChangedValues.Count == 0)
                {
                    IsSomethingValueChanged = false;
                }
                return;
            }

            if (ChangedValues.ContainsKey(propertyName))
            {
                ChangedValues[propertyName] = changedValue;
            }
            else
            {
                ChangedValues.Add(propertyName, changedValue);
            }
            IsSomethingValueChanged = true;
        }

        private bool _isSomethingValueChanged = false;

        /// <summary>
        /// プロパティまたはフィールドの値に変更があったかを取得します。
        /// </summary>
        protected bool IsSomethingValueChanged
        {
            get => _isSomethingValueChanged;
            private set
            {
                if (_isSomethingValueChanged != value)
                {
                    _isSomethingValueChanged = value;
                    SomethingValueChanged.Invoke(value);
                }
            }
        }

        /// <summary>
        /// 変更状態に変化があったときに走行します。
        /// 何らかの変更があった場合は true, すべてのプロパティおよびフィールドが既定値だった場合は false を提供します。
        /// </summary>
        public Action<bool> SomethingValueChanged;

        /// <summary>
        /// プロパティまたはフィールドが変更されたかどうかを取得します。
        /// </summary>
        /// <param name="propertyName">プロパティ名またはフィールド名。</param>
        /// <returns>プロパティまたはフィールドが変更されていた場合は true, それ以外は false を返却します。</returns>
        public bool ContainsChangedProperty(string propertyName)
        {
            return ChangedValues.ContainsKey(propertyName);
        }

        /// <summary>
        /// 変更されたプロパティまたはフィールドのコレクションを取得します。
        /// </summary>
        /// <returns>変更されたプロパティまたはフィールドのコレクション。</returns>
        public IEnumerable<string> GetChangedProperties()
        {
            foreach (var changedValue in ChangedValues)
            {
                yield return changedValue.Key;
            }
        }
    }
}
