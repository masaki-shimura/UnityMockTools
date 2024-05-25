using UnityEditor;

namespace MSLib.Editor.Tools.StartupWindow
{
    /// <summary>
    /// スタートアップウィンドウをUnityEditor上で起動した直後に起動出来るようにイベントの登録を行なう
    /// NOTE:毎回最初からインスタンスが呼び出される形なのでクラスの変数では値を保持出来ない
    /// </summary>
    [InitializeOnLoad]
    public sealed class StartupWindowFactory
    {
        private const string EditorKey = "StartupWindow";

        static StartupWindowFactory()
        {
            //エディタの状態管理の為に「EditorPrefs」を活用し、起動、終了にフラグを更新する。
            //それによって「HasKey」の状態で開閉を判断する
            EditorApplication.update += Startup;
            EditorApplication.quitting += () => EditorPrefs.DeleteKey(EditorKey);
        }

        private static void Startup()
        {
            // エディタ起動時かどうかをチェックしてもしも開いていなかったら開く
            if (EditorPrefs.HasKey(EditorKey) == false)
            {
                StartupWindow.ShowWindow();
                EditorPrefs.SetBool(EditorKey, true);
            }

            EditorApplication.update -= Startup;
        }
    }
}