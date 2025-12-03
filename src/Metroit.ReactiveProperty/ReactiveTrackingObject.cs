using Metroit.ChangeTracking;
using Metroit.ChangeTracking.Generic;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Metroit.ReactiveProperty
{
    /// <summary>
    /// 変更追跡が可能なオブジェクトを提供します。
    /// </summary>
    public abstract class ReactiveTrackingObject<T1, T2> : TrackingObject<T1, T2>, IDisposable where T1 : class where T2 : PropertyChangeTracker<T1>, new()
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        private Dictionary<string, PropertyTrackingInfo> _propertyTracking = new Dictionary<string, PropertyTrackingInfo>();

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public ReactiveTrackingObject() : base()
        {

        }

        /// <summary>
        /// すべての<see cref="ReactiveProperty{T}"/> を購読し、変更時に<see cref="TrackingObject{T, T2}.PropertyChanged"/>を発行するように設定します。<br/>
        /// このメソッドを呼び出した後、プロパティは自動的に監視され、必ず<see cref="TrackingObject{T, T2}.PropertyChanged"/>が発生するようになります。<br/>
        /// コンストラクタの購読を開始したいタイミングで呼び出してください。<br/>
        /// 個別に設定する<see cref="ReactiveProperty{T}.Subscribe(IObserver{T})"/>よりも前に呼び出す必要があります。
        /// </summary>
        protected void InitializePropertyTracking()
        {
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                if (!property.PropertyType.IsGenericType)
                {
                    continue;
                }
                if (property.PropertyType.GetGenericTypeDefinition() != typeof(ReactiveProperty<>))
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

                // NOTE: プロパティ値がnullのときに型推論ができないため、SubscribeReactivePropertyをリフレクションで呼び出す。
                var valueType = property.PropertyType.GetGenericArguments()[0];
                var subscribeMethod = typeof(ReactiveTrackingObject<T1, T2>)
                    .GetMethod(nameof(SubscribeReactiveProperty),
                               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .MakeGenericMethod(valueType);
                subscribeMethod.Invoke(this, new[] { reactiveProperty, property.Name });
            }
        }

        /// <summary>
        /// 指定した<see cref="ReactiveProperty{T}"/> を購読し、変更時に<see cref="TrackingObject{T, T2}.PropertyChanged"/>を発行するように設定します。
        /// </summary>
        /// <typeparam name="T">プロパティの型。</typeparam>
        /// <param name="property">購読を行うプロパティ。</param>
        /// <param name="propertyName">購読を行うプロパティ名。</param>
        private void SubscribeReactiveProperty<T>(ReactiveProperty<T> property, string propertyName)
        {
            // 既に登録済みの場合はスキップ
            if (_propertyTracking.ContainsKey(propertyName))
            {
                return;
            }

            // 購読後の変更時にPropertyChangedを発行することを購読する
            property
                .Skip(1)
                .Subscribe(_ =>
                {
                    if (_propertyTracking.TryGetValue(propertyName, out var info) && info.Enabled)
                    {
                        ChangeTracker.TrackingProperty(propertyName);
                        OnPropertyChanged(propertyName);
                    }
                })
                .AddTo(_disposables);

            _propertyTracking[propertyName] = new PropertyTrackingInfo
            {
                ReactiveProperty = property,
                Enabled = true
            };
        }

        /// <summary>
        /// 指定したプロパティのPropertyChanged通知を停止します。
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
        /// 指定したプロパティのPropertyChanged通知を再開します。
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
        /// すべてのプロパティのPropertyChanged通知を停止します。
        /// </summary>
        protected void DisableAllPropertiesNotification()
        {
            foreach (var info in _propertyTracking.Values)
            {
                info.Enabled = false;
            }
        }

        /// <summary>
        /// すべてのプロパティのPropertyChanged通知を再開します。
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
            _disposables?.Dispose();
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
