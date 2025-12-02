namespace Metroit.Mvvm.WinForms.ViewModels
{
    /// <summary>
    /// ダイアログがアクティブになったときに発行するアクションを提供します。
    /// </summary>
    public interface IDialogActivateAction
    {
        /// <summary>
        /// アクティブになったときにアクションを実行します。
        /// </summary>
        /// <param name="param">パラメーター。</param>
        void ExecuteActivateAction(object param);
    }
}
