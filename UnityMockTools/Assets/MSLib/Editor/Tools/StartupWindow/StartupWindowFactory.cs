using UnityEditor;

namespace MSLib.Editor.Tools.StartupWindow
{
    /// <summary>
    /// スタートアップウィンドウをUnityEditor上で起動した直後に起動出来るようにイベントの登録を行なう
    /// </summary>
    [InitializeOnLoad]
    public sealed class StartupWindowFactory
    {
        static StartupWindowFactory()
        {
            EditorApplication.update += Startup;
        }

        private static void Startup()
        {
            StartupWindow.ShowWindow();
            EditorApplication.update -= Startup;
        }
    }
}