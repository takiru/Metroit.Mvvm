namespace Metroit.Mvvm.Interfaces
{
    /// <summary>
    /// ダイアログがアクティブになったときに発行するアクションを提供します。
    /// </summary>
    public interface IDialogActivateAction<T>
    {
        /// <summary>
        /// アクティブになったときにアクションを実行します。
        /// </summary>
        /// <param name="param">パラメーター。</param>
        void ExecuteActivateAction(T param);
    }
}
