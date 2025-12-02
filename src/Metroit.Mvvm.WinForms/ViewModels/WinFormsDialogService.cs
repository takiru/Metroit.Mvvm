using Metroit.Contracts;
using Metroit.Mvvm.Interfaces;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Metroit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// WinForms 用ダイアログサービスを提供します。
    /// </summary>
    public class WinFormsDialogService : IDialogService, IWinFormsDialogService
    {
        /// <summary>
        /// 指定したウィンドウの表示状態を設定します。
        /// </summary>
        /// <param name="hWnd">ウィンドウへのハンドル。</param>
        /// <param name="nCmdShow">ウィンドウの表示方法。</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// ウィンドウをアクティブにして表示します。
        /// </summary>
        private const int SW_RESTORE = 9;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public WinFormsDialogService()
        {

        }

        /// <summary>
        /// 指定したダイアログが開かれているかどうかを取得します。
        /// </summary>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <returns>開かれている場合は true, それ以外は false を返却します。</returns>
        bool IDialogService.IsOpened<T>()
        {
            EnsureFormType<T>();
            return IsOpenedInternal(typeof(T));
        }

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <exception cref="NotSupportedException"><typeparamref name="T"/>が<see cref="Form"/>ではありません。</exception>
        void IDialogService.Show<T>()
        {
            EnsureFormType<T>();
            ShowInternal(typeof(T), null);
        }

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        void IDialogService.Show<T>(Func<object> ownerProvider)
        {
            EnsureFormType<T>();
            ShowInternal(typeof(T), (Func<Form>)ownerProvider);
        }

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">扱っているオブジェクト。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <exception cref="NotSupportedException"><typeparamref name="T1"/>が<see cref="Form"/>ではありません。</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>を実装していません。</exception>
        void IDialogService.Show<T1, T2>(T2 request)
        {
            EnsureFormType<T1>();
            ShowWithRequestInternal(typeof(T1), request, null);
        }

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">扱っているオブジェクト。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        /// <exception cref="NotSupportedException"><typeparamref name="T1"/>が<see cref="Form"/>ではありません。</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>を実装していません。</exception>
        void IDialogService.Show<T1, T2>(T2 request, Func<object> ownerProvider)
        {
            EnsureFormType<T1>();
            ShowWithRequestInternal(typeof(T1), request, (Func<Form>)ownerProvider);
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        void IDialogService.Activate<T>()
        {
            EnsureFormType<T>();
            ActivateInternal(typeof(T));
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/>が<see cref="IDialogActivateAction"/>を実装していません。</exception>
        void IDialogService.ActivateWithAction<T>()
        {
            EnsureFormType<T>();
            ActivateWithActionInternal(typeof(T), null);
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <param name="param">パラメーター。</param>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/>が<see cref="IDialogActivateAction"/>を実装していません。</exception>
        void IDialogService.ActivateWithAction<T>(object param)
        {
            EnsureFormType<T>();
            ActivateWithActionInternal(typeof(T), param);
        }

        /// <summary>
        /// モーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <exception cref="NotSupportedException"><typeparamref name="T"/>が<see cref="Form"/>ではありません。</exception>
        void IDialogService.ShowDialog<T>()
        {
            EnsureFormType<T>();
            ShowDialogInternal(typeof(T));
        }

        /// <summary>
        /// リクエストを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">扱っているオブジェクト。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <exception cref="NotSupportedException"><typeparamref name="T1"/>が<see cref="Form"/>ではありません。</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>を実装していません。</exception>
        void IDialogService.ShowDialog<T1, T2>(T2 request)
        {
            EnsureFormType<T1>();
            ShowDialogWithRequestInternal(typeof(T1), request);
        }

        /// <summary>
        /// レスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">扱っているオブジェクト。</typeparam>
        /// <typeparam name="T2">レスポンス。</typeparam>
        /// <returns>レスポンス。</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="T1"/>が<see cref="Form"/>ではありません。</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogResponse{T}"/>を実装していません。</exception>
        T2 IDialogService.ShowDialog<T1, T2>()
        {
            EnsureFormType<T1>();
            return ShowDialogWithResponseInternal<T2>(typeof(T1));
        }

        /// <summary>
        /// リクエストとレスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">扱っているオブジェクト。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <typeparam name="T3">レスポンス。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <returns>レスポンス。</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="T1"/>が<see cref="Form"/>ではありません。</exception>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>と<see cref="IDialogResponse{T}"/>を実装していません。</exception>
        T3 IDialogService.ShowDialog<T1, T2, T3>(T2 request)
        {
            EnsureFormType<T1>();
            return ShowDialogWithRequestAndResponseInternal<T2, T3>(typeof(T1), request);
        }

        /// <summary>
        /// 指定したダイアログが開かれているかどうかを取得します。
        /// </summary>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <returns>開かれている場合は true, それ以外は false を返却します。</returns>
        public bool IsOpened<T>() where T : Form, new()
        {
            return IsOpenedInternal(typeof(T));
        }

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        public void Show<T>() where T : Form, new()
        {
            ShowInternal(typeof(T), null);
        }

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        public void Show<T>(Func<Form> ownerProvider) where T : Form, new()
        {
            ShowInternal(typeof(T), ownerProvider);
        }

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        public void Show<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new()
        {
            ShowWithRequestInternal(typeof(T1), request, null);
        }

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        public void Show<T1, T2>(T2 request, Func<Form> ownerProvider) where T1 : Form, IDialogRequest<T2>, new()
        {
            ShowWithRequestInternal(typeof(T1), request, ownerProvider);
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        public void Activate<T>() where T : Form, new()
        {
            ActivateInternal(typeof(T));
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/>が<see cref="IDialogActivateAction"/>を実装していません。</exception>
        public void ActivateWithAction<T>() where T : Form, IDialogActivateAction, new()
        {
            ActivateWithAction<T>(null);
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <param name="param">パラメーター。</param>
        /// <typeparam name="T">扱っているオブジェクト。</typeparam>
        /// <exception cref="InvalidOperationException"><typeparamref name="T"/>が<see cref="IDialogActivateAction"/>を実装していません。</exception>
        public void ActivateWithAction<T>(object param) where T : Form, IDialogActivateAction, new()
        {
            ActivateWithActionInternal(typeof(T), param);
        }

        /// <summary>
        /// モーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">フォーム。</typeparam>
        public void ShowDialog<T>() where T : Form, new()
        {
            ShowDialogInternal(typeof(T));
        }

        /// <summary>
        /// リクエストを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>を実装していません。</exception>
        public void ShowDialog<T1, T2>(T2 request) where T1 : Form, IDialogRequest<T2>, new()
        {
            ShowDialogWithRequestInternal(typeof(T1), request);
        }

        /// <summary>
        /// レスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">レスポンス。</typeparam>
        /// <returns>レスポンス。</returns>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogResponse{T}"/>を実装していません。</exception>
        public T2 ShowDialog<T1, T2>() where T1 : Form, IDialogResponse<T2>, new()
        {
            return ShowDialogWithResponseInternal<T2>(typeof(T1));
        }

        /// <summary>
        /// リクエストとレスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">フォーム。</typeparam>
        /// <typeparam name="T2">リクエスト。</typeparam>
        /// <typeparam name="T3">レスポンス。</typeparam>
        /// <param name="request">リクエスト。</param>
        /// <returns>レスポンス。</returns>
        /// <exception cref="InvalidOperationException"><typeparamref name="T1"/>が<see cref="IDialogRequest{T}"/>と<see cref="IDialogResponse{T}"/>を実装していません。</exception>
        public T3 ShowDialog<T1, T2, T3>(T2 request) where T1 : Form, IDialogRequest<T2>, IDialogResponse<T3>, new()
        {
            return ShowDialogWithRequestAndResponseInternal<T2, T3>(typeof(T1), request);
        }

        /// <summary>
        /// フォーム型であることを保証します。
        /// </summary>
        /// <typeparam name="T">検証する型。</typeparam>
        /// <exception cref="NotSupportedException"><typeparamref name="T"/>が<see cref="Form"/>を継承していません。</exception>
        private static void EnsureFormType<T>()
        {
            if (!typeof(T).IsSubclassOf(typeof(Form)))
            {
                throw new NotSupportedException("Use IWinFormsDialogService for WinForms dialogs.");
            }
        }

        /// <summary>
        /// フォームインスタンスを作成します。
        /// </summary>
        /// <param name="formType">フォームタイプ。</param>
        /// <returns>作成されたフォーム。</returns>
        private static Form CreateFormInstance(Type formType)
        {
            return (Form)Activator.CreateInstance(formType);
        }

        /// <summary>
        /// 対象フォームが開かれているかどうかを取得します。
        /// </summary>
        /// <param name="formType">フォームタイプ。</param>
        /// <returns>開かれている場合は true, それ以外は false を返却します。</returns>
        private bool IsOpenedInternal(Type formType)
        {
            var form = Application.OpenForms
                .OfType<Form>()
                .FirstOrDefault(x => x.GetType() == formType);

            return form != null;
        }

        /// <summary>
        /// モーダレスダイアログを表示します。
        /// </summary>
        /// <param name="formType">フォームタイプ。</param>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        private void ShowInternal(Type formType, Func<Form> ownerProvider)
        {
            var form = CreateFormInstance(formType);

            if (ownerProvider?.Invoke() is Form ownerForm)
            {
                form.Show(ownerForm);
                return;
            }

            form.Show();
        }

        /// <summary>
        /// リクエストを持つモーダレスダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">リクエスト。</typeparam>
        /// <param name="formType">フォームタイプ。</param>
        /// <param name="request">リクエスト。</param>
        /// <param name="ownerProvider">オーナープロバイダー。</param>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogRequest{T}"/>を実装していない。</exception>
        private static void ShowWithRequestInternal<T>(Type formType, T request, Func<Form> ownerProvider)
        {
            EnsureRequestInterface<T>(formType);

            var form = CreateFormInstance(formType);
            var dialogRequest = (IDialogRequest<T>)form;
            dialogRequest.Request = request;

            if (ownerProvider?.Invoke() is Form ownerForm)
            {
                form.Show(ownerForm);
                return;
            }

            form.Show();
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <param name="formType">フォームタイプ。</param>
        private static void ActivateInternal(Type formType)
        {
            var form = Application.OpenForms
                .OfType<Form>()
                .FirstOrDefault(x => x.GetType() == formType);

            if (form == null)
            {
                return;
            }
            if (!form.Visible)
            {
                return;
            }

            if (form.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(form.Handle, SW_RESTORE);
            }

            form.Activate();
        }

        /// <summary>
        /// モーダレスダイアログをアクティブ化して制御を実施します。
        /// アクティブ化するダイアログが開かれていないとき、または非表示のときは何も行いません。
        /// </summary>
        /// <param name="formType">フォームタイプ。</param>
        /// <param name="param">パラメーター。</param>
        /// <exception cref="InvalidOperationException"><paramref name="param"/>が<see cref="IDialogActivateAction"/>を実装していない。</exception>
        private static void ActivateWithActionInternal(Type formType, object param)
        {
            var form = Application.OpenForms
                .OfType<Form>()
                .FirstOrDefault(x => x.GetType() == formType);

            if (form == null)
            {
                return;
            }
            if (!form.Visible)
            {
                return;
            }

            EnsureDialogActivateActionInterface(form.GetType());

            if (form.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(form.Handle, SW_RESTORE);
            }

            form.Activate();
            var activateAction = (IDialogActivateAction)form;
            activateAction.ExecuteActivateAction(param);
        }

        /// <summary>
        /// モーダルダイアログを表示します。
        /// </summary>
        /// <param name="formType">フォームタイプ。</param>
        private static void ShowDialogInternal(Type formType)
        {
            var form = CreateFormInstance(formType);
            form.ShowDialog();
        }

        /// <summary>
        /// リクエストを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">リクエスト。</typeparam>
        /// <param name="formType">フォームタイプ。</param>
        /// <param name="request">リクエスト。</param>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogRequest{T}"/>を実装していない。</exception>
        private static void ShowDialogWithRequestInternal<T>(Type formType, T request)
        {
            EnsureRequestInterface<T>(formType);

            var form = CreateFormInstance(formType);
            var dialogRequest = (IDialogRequest<T>)form;
            dialogRequest.Request = request;
            form.ShowDialog();
        }

        /// <summary>
        /// レスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T">レスポンス。</typeparam>
        /// <param name="formType">フォームタイプ。</param>
        /// <returns>レスポンス。</returns>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogResponse{T}"/>を実装していない。</exception>
        private static T ShowDialogWithResponseInternal<T>(Type formType)
        {
            EnsureResponseInterface<T>(formType);

            var form = CreateFormInstance(formType);
            var dialogResponse = (IDialogResponse<T>)form;
            form.ShowDialog();
            return dialogResponse.Response;
        }

        /// <summary>
        /// リクエストとレスポンスを持つモーダルダイアログを表示します。
        /// </summary>
        /// <typeparam name="T1">リクエスト。</typeparam>
        /// <typeparam name="T2">レスポンス。</typeparam>
        /// <param name="formType">フォームタイプ。</param>
        /// <param name="request">リクエスト。</param>
        /// <returns>レスポンス。</returns>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogRequest{T}"/>と<see cref="IDialogResponse{T}"/>を実装していない。</exception>
        private static T2 ShowDialogWithRequestAndResponseInternal<T1, T2>(Type formType, T1 request)
        {
            EnsureRequestInterface<T1>(formType);
            EnsureResponseInterface<T2>(formType);

            var form = CreateFormInstance(formType);
            var dialogRequest = (IDialogRequest<T1>)form;
            var dialogResponse = (IDialogResponse<T2>)form;

            dialogRequest.Request = request;
            form.ShowDialog();
            return dialogResponse.Response;
        }

        /// <summary>
        /// <see cref="IDialogRequest{T}"/>の実装を保証します。
        /// </summary>
        /// <typeparam name="T">リクエスト型。</typeparam>
        /// <param name="formType">検証するフォームタイプ。</param>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogRequest{T}"/>を実装していない。</exception>
        private static void EnsureRequestInterface<T>(Type formType)
        {
            var interfaces = formType.GetInterfaces();
            if (!IsImplementedRequest<T>(interfaces))
            {
                throw new InvalidOperationException(
                    $"{formType.Name} does not implement IDialogRequest<{typeof(T).Name}>");
            }
        }

        /// <summary>
        /// <see cref="IDialogResponse{T}"/>の実装を保証します。
        /// </summary>
        /// <typeparam name="T">レスポンス型。</typeparam>
        /// <param name="formType">検証するフォームタイプ。</param>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogResponse{T}"/>を実装していない。</exception>
        private static void EnsureResponseInterface<T>(Type formType)
        {
            var interfaces = formType.GetInterfaces();
            if (!IsImplementedResponse<T>(interfaces))
            {
                throw new InvalidOperationException(
                    $"{formType.Name} does not implement IDialogResponse<{typeof(T).Name}>");
            }
        }

        /// <summary>
        /// <see cref="IDialogActivateAction"/>の実装を保証します。
        /// </summary>
        /// <param name="formType">検証するフォームタイプ。</param>
        /// <exception cref="InvalidOperationException"><paramref name="formType"/>が<see cref="IDialogActivateAction"/>を実装していない。</exception>
        private static void EnsureDialogActivateActionInterface(Type formType)
        {
            var interfaces = formType.GetInterfaces();
            if (!IsImplementedDialogActivateAction(interfaces))
            {
                throw new InvalidOperationException(
                    $"{formType.Name} does not implement IDialogActivateAction");
            }
        }

        /// <summary>
        /// 指定されたインターフェイス群に<see cref="IDialogRequest{T}"/>が含まれるか確認する。
        /// </summary>
        /// <typeparam name="T">リクエスト。</typeparam>
        /// <param name="interfaces">インターフェース。</param>
        /// <returns><see cref="IDialogRequest{T}"/>が含まれるときは<see langword="true"/>, それ以外は<see langword="false"/>を返却する。</returns>
        private static bool IsImplementedRequest<T>(Type[] interfaces)
        {
            return interfaces.Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeof(IDialogRequest<>) &&
                x.GetGenericArguments()[0] == typeof(T));
        }

        /// <summary>
        /// 指定されたインターフェイス群に<see cref="IDialogResponse{T}"/>が含まれるか確認する。
        /// </summary>
        /// <typeparam name="T">レスポンス。</typeparam>
        /// <param name="interfaces">インターフェース。</param>
        /// <returns><see cref="IDialogResponse{T}"/>が含まれるときは<see langword="true"/>, それ以外は<see langword="false"/>を返却する。</returns>
        private static bool IsImplementedResponse<T>(Type[] interfaces)
        {
            return interfaces.Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeof(IDialogResponse<>) &&
                x.GetGenericArguments()[0] == typeof(T));
        }

        /// <summary>
        /// 指定されたインターフェイス群に<see cref="IDialogActivateAction"/>が含まれるか確認する。
        /// </summary>
        /// <param name="interfaces">インターフェース。</param>
        /// <returns><see cref="IDialogActivateAction"/>が含まれるときは<see langword="true"/>, それ以外は<see langword="false"/>を返却する。</returns>
        private static bool IsImplementedDialogActivateAction(Type[] interfaces)
        {
            return interfaces.Any(x =>
                x == typeof(IDialogActivateAction));
        }
    }
}
