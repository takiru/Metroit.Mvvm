namespace Metroit.Mvvm.WinForms.Test
{
    /// <summary>
    /// アクティブなフォームの追跡を提供します。
    /// </summary>
    public static class ActiveFormTracker
    {
        private static Form _lastActiveForm;

        /// <summary>
        /// アクティブなフォームを取得します。
        /// </summary>
        public static Form ActiveForm => _lastActiveForm;

        /// <summary>
        /// アクティブなフォームの追跡を開始します。
        /// </summary>
        public static void StartTracking()
        {
            Application.Idle += (s, e) =>
            {
                if (Form.ActiveForm != null)
                {
                    _lastActiveForm = Form.ActiveForm;
                }
            };
        }
    }
}
