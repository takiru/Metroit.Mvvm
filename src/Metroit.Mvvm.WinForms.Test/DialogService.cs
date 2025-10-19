using Metroit.Contracts;
using Metroit.Mvvm.Interfaces;

namespace Metroit.Mvvm.WinForms.Test
{
    public class TestDialogRequest
    {
        public string RequestValue { get; set; }
    }

    public class TestDialogResponse
    {
        public string ResponseValue { get; set; }
    }

    public class DialogService : IDialogService
    {
        public DialogService()
        {

        }

        //// この方法が一番いいかな

        /// <summary>
        /// リクエストなし、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public void Show<T>() where T : Form, new()
        {
            var form = new T();
            form.Show();
        }

        /// <summary>
        /// リクエストあり、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public void Show<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new()
        {
            var form = new T1();
            form.Request = request;
            form.Show();
        }

        /// <summary>
        /// リクエストなし、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public void ShowDialog<T>() where T : Form, new()
        {
            var form = new T();
            form.ShowDialog();
        }

        /// <summary>
        /// リクエストあり、レスポンスなしモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public void ShowDialog<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new()
        {
            var form = new T1();
            form.Request = request;
            form.ShowDialog();
        }

        /// <summary>
        /// リクエストなし、レスポンスありモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public T2 ShowDialog<T1, T2>() where T1 : Form, IDialogResponse<T2>, new()
        {
            var form = new T1();
            form.ShowDialog();
            return form.Response;
        }

        /// <summary>
        /// リクエストあり、レスポンスありモーダルダイアログ。
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : Form, IDialogRequest<T2>, IDialogResponse<T3>, new()
        {
            var form = new T1();
            form.Request = request;
            form.ShowDialog();
            return form.Response;
        }






        //public void Show(string windowKey)
        //{
        //    if (windowKey == "Form2")
        //    {
        //        (new Form2()).Show();
        //    }
        //}

        //public void Show<T>(string windowKey, T request)
        //{
        //    if (windowKey == "Form2")
        //    {
        //        var f = new Form2();
        //        ((IDialogRequest<T>)f).Request = request;
        //        f.Show();
        //    }
        //}

        //public T ShowDialog<T>(string windowKey)
        //{
        //    if (windowKey == "Form2")
        //    {
        //        var f = new Form2();
        //        var r = f.ShowDialog();
        //        return ((IDialogResponse<T>)f).Response;
        //    }

        //    return default(T);
        //}

        //public T2 ShowDialog<T1, T2>(string windowKey, T1 request)
        //{
        //    if (windowKey == FormName.Form2.ToString())
        //    {
        //        var f = new Form2();
        //        ((IDialogRequest<T1>)f).Request = request;
        //        var r = f.ShowDialog();
        //        return ((IDialogResponse<T2>)f).Response;
        //    }

        //    return default(T2);
        //}
    }
}
