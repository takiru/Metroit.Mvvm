using Metroit.ChangeTracking;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reflection;
using Metroit.Annotations;

namespace Metroit.ReactiveProperty.ChangeTracking
{
    /// <summary>
    /// 変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    /// <typeparam name="T1">変更追跡対象オブジェクト。</typeparam>
    /// <typeparam name="T2">トラッカー。</typeparam>

    public class ReactiveTrackingObject<T1, T2> : TrackingObject<T1, T2> where T1 : class where T2 : ReactivePropertyChangeTracker<T1>, new()
    {
        private CompositeDisposable _disposables;
        private readonly Dictionary<string, PropertyTrackingInfo> _propertyTracking = new Dictionary<string, PropertyTrackingInfo>();

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public ReactiveTrackingObject() : base() { }

        /// <summary>
        /// <see cref="NoTrackingAttribute"/> が指定されていないすべての<see cref="IReactiveProperty{T}"/>プロパティを購読し、変更時に<see cref="TrackingObject{T, T2}.PropertyChanged"/>を発行するように設定します。<br/>
        /// このメソッドを呼び出した後、プロパティは自動的に監視され、必ず<see cref="TrackingObject{T, T2}.PropertyChanged"/>が発生するようになります。<br/>
        /// </summary>
        /// <remarks>
        /// コンストラクタの購読を開始したいタイミングで呼び出してください。<br/>
        /// 個別に設定する<see cref="IObservable{T}.Subscribe(IObserver{T})"/>よりも前に呼び出す必要があります。
        /// </remarks>
        protected void InitializePropertyTracking()
        {
            // 購読済みのプロパティをすべて購読解除する
            _disposables?.Dispose();
            _disposables = new CompositeDisposable();
            _propertyTracking.Clear();

            var properties = GetType().GetProperties(BindingFlags.Instance |
                                                              BindingFlags.Public | BindingFlags.NonPublic | 
                                                              BindingFlags.GetProperty)
                .Where(x => IsTrackingProperty(x));

            foreach (var property in properties)
            {
                // ジェネリッククラスではないものは対象外
                if (!property.PropertyType.IsGenericType)
                {
                    continue;
                }

                // IReactiveProperty<>を実装していないものは対象外
                if (property.PropertyType.GetInterfaces().All(x => x.GetGenericTypeDefinition() != typeof(IReactiveProperty<>)))
                {
                    continue;
                }

                var reactiveProperty = property.GetValue(this);
                if (reactiveProperty == null)
                {
                    continue;
                }
                if (_propertyTracking.ContainsKey(property.Name))
                {
                    continue;
                }

                // NOTE: プロパティ値がnullのときに型推論ができないため、SubscribeReactiveProperty をリフレクションで呼び出す。
                var valueType = property.PropertyType.GetGenericArguments()[0];
                var subscribeMethod = typeof(ReactiveTrackingObject<T1, T2>)
                    .GetMethod(nameof(SubscribeReactiveProperty),
                               BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(valueType);
                subscribeMethod.Invoke(this, new[] { reactiveProperty, property.Name });
            }
        }

        /// <summary>
        /// 変更追跡を行うプロパティかどうかを取得する。
        /// </summary>
        /// <param name="pi">プロパティ情報。</param>
        /// <returns>変更追跡を行うプロパティの場合は true, それ以外は false を返却する。</returns>
        private bool IsTrackingProperty(PropertyInfo pi)
        {
            if (pi.GetCustomAttribute(typeof(NoTrackingAttribute)) != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 指定した<see cref="ReactiveProperty{T}"/> を購読し、変更時に<see cref="TrackingObject{T, T2}.PropertyChanged"/>を発行するように設定します。
        /// </summary>
        /// <typeparam name="T">プロパティの型。</typeparam>
        /// <param name="property">購読を行うプロパティ。</param>
        /// <param name="propertyName">購読を行うプロパティ名。</param>
        private void SubscribeReactiveProperty<T>(IReactiveProperty<T> property, string propertyName)
        {
            // 購読後の変更時にトラッキングおよびPropertyChangedを発行することを購読する
            property
                .Subscribe(_ =>
                {
                    // 購読直後はトラッキングしていないので何もしない
                    if (!_propertyTracking.TryGetValue(propertyName, out var trackingInfo))
                    {
                        return;
                    }

                    // トラッキングを停止しているなら何もしない
                    if (!trackingInfo.Enabled)
                    {
                        return;
                    }

                    ChangeTracker.TrackingProperty(propertyName);
                    OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
                })
                .AddTo(_disposables);

            _propertyTracking[propertyName] = new PropertyTrackingInfo
            {
                ReactiveProperty = property,
                Enabled = true
            };
        }

        /// <summary>
        /// 指定したプロパティのトラッキングと PropertyChanged 通知を停止します。
        /// </summary>
        /// <param name="propertyName">通知を停止するプロパティ名。</param>
        protected void DisablePropertyNotification(string propertyName)
        {
            if (_propertyTracking.TryGetValue(propertyName, out var info))
            {
                info.Enabled = false;
            }
        }

        /// <summary>
        /// 指定したプロパティのトラッキングと PropertyChanged 通知を再開します。
        /// </summary>
        /// <param name="propertyName">通知を再開するプロパティ名。</param>
        protected void EnablePropertyNotification(string propertyName)
        {
            if (_propertyTracking.TryGetValue(propertyName, out var info))
            {
                info.Enabled = true;
            }
        }

        /// <summary>
        /// すべてのプロパティのトラッキングと PropertyChanged 通知を停止します。
        /// </summary>
        protected void DisableAllPropertiesNotification()
        {
            foreach (var info in _propertyTracking.Values)
            {
                info.Enabled = false;
            }
        }

        /// <summary>
        /// すべてのプロパティのトラッキングと PropertyChanged 通知を再開します。
        /// </summary>
        protected void EnableAllPropertiesNotification()
        {
            foreach (var info in _propertyTracking.Values)
            {
                info.Enabled = true;
            }
        }

        /// <summary>
        /// リソースを解放します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// リソースを解放します。
        /// </summary>
        /// <param name="disposing">マネージドリソースを解放する場合はtrue。</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposables?.Dispose();
            }
        }
    }
}
