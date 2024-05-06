using UnityEditor;

namespace MSLib
{
    public sealed class DebugFileFocusWindow : EditorWindow
    {
        private EditorWindowTaskManager _editorWindowTaskManager = new EditorWindowTaskManager();

        [MenuItem("Tools/Debug/DebugFileFocusWindow")]
        static void Initialize()
        {
            var window = (DebugFileFocusWindow)EditorWindow.GetWindow(typeof(DebugFileFocusWindow));
            window.Show();
        }

        private void OnGUI()
        {
            _editorWindowTaskManager.Draw();
        }

        private void OnEnable()
        {
            _editorWindowTaskManager.AddTask("ファイルフォーカス", new EditorWindowFileFocusTask());

            _editorWindowTaskManager.Init();
        }

        private void OnDisable()
        {
            _editorWindowTaskManager.UnInit();
        }
    }
}