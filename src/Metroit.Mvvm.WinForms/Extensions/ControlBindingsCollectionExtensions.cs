using System.Linq;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.Extensions
{
    /// <summary>
    /// バインドコレクションの拡張メソッドを提供します。
    /// </summary>
    public static class ControlBindingsCollectionExtensions
    {
        /// <summary>
        /// バインドコレクションの中から、<paramref name="propertyName"/> に合致するバインドを解除します。該当するバインドがないときは何もしません。
        /// </summary>
        /// <param name="collection">バインドコレクション。</param>
        /// <param name="propertyName">プロパティ名。</param>
        public static void ClearBind(this ControlBindingsCollection collection, string propertyName)
        {
            var binding = collection.OfType<Binding>().FirstOrDefault((x) => x.PropertyName == propertyName);

            if (binding == null)
            {
                return;
            }

            collection.Remove(binding);
        }
    }
}
